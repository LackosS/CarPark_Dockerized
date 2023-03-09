import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { Slot } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-add-slot-modal',
  templateUrl: './add-slot-modal.component.html',
  styleUrls: ['./add-slot-modal.component.css'],
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class AddSlotModalComponent {
  formAddSlot!: FormGroup;
  modalOptions: NgbModalOptions | undefined;
  @Input() slots: Slot[] = [];
  @Input() select!: HTMLSelectElement;

  constructor(private modalService: NgbModal,
    private fb: FormBuilder,
    private toastService: ToastService,
    private companyAdminService: CompanyAdminService,) {
    this.modalOptions = {
      modalDialogClass: 'modal-bg',
      windowClass: 'backdrop-blur',
    }
  }
  ngOnInit(): void {
    this.initialFrom();
  }
  addSlot(select: HTMLSelectElement) {
    if (this.formAddSlot.valid) {
      const Slot : Slot = {
        id: 0,
        levelId: parseInt(select.value),
        slotNumber: this.formAddSlot.value.slotnumber,
        type: this.formAddSlot.value.type,
        initialNumber: 0,
        isFree: false,
      }
      this.formAddSlot.disable();
      this.companyAdminService.addSlot(Slot).subscribe(
        (data) => {
          this.toastService.show('Slot added successfully!',{ classname: 'bg-success text-light', delay: 3000 });
          this.formAddSlot.enable();
          this.modalService.dismissAll();
          this.initialFrom();
          Slot.id = data;
          this.slots.push(Slot);
          this.slots.sort((a, b) => (a.slotNumber > b.slotNumber) ? 1 : -1);
        },
        (error) => {
          this.toastService.show('Something went wrong!',{ classname: 'bg-danger text-light', delay: 3000 });
          this.formAddSlot.enable();
        }
      );
    }
    else{
      if(this.formAddSlot.get('slotnumber')?.hasError('required') || this.formAddSlot.get('type')?.hasError('required')){
        this.toastService.show('Please fill all the fields!',{ classname: 'bg-danger text-light', delay: 3000 });
      }
    }
  }
      
        
  initialFrom() {
    this.formAddSlot = this.fb.group({
      slotnumber: ['', Validators.required],
      type: ['Default',Validators.required],
    });
  }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
}
