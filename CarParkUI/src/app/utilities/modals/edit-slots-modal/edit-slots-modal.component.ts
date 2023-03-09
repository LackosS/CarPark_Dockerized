import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { Slot } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-edit-slots-modal',
  templateUrl: './edit-slots-modal.component.html',
  styleUrls: ['./edit-slots-modal.component.css'],
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class EditSlotsModalComponent implements OnInit {
  formEditSlots!: FormGroup;
  modalOptions: NgbModalOptions | undefined;
  @Input() slots: Slot[] = [];
  @Input() editSlots: Slot[] = [];
  @Output() editSlotsChange = new EventEmitter<void>();
  @Output() deleteSlotsChange = new EventEmitter<void>();

  constructor(private modalService: NgbModal,
    private fb: FormBuilder,
    private toastService: ToastService,
    private companyAdminService: CompanyAdminService) {
    this.modalOptions = {
      modalDialogClass: 'modal-bg',
      windowClass: 'backdrop-blur',
    }
  }
  ngOnInit(): void {
    this.initialForm();
  }
  deleteSlots(){
    if(this.editSlots.length == 0) {this.toastService.show('No slots selected!', { classname: 'bg-danger text-light', delay: 3000 }); return;}
    this.companyAdminService.deleteSlots(this.editSlots).subscribe(
      (data) => {
        this.toastService.show('Slots deleted succesfully!', { classname: 'bg-success text-light', delay: 3000 });
        this.deleteSlotsChange.emit();
      },
      (error) => {
        this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
      }
    );
  }
  updateSlots(){
    if(this.editSlots.length == 0) {this.toastService.show('No slots selected!', { classname: 'bg-danger text-light', delay: 3000 }); return;}
    this.editSlots.forEach(element => {
      element.type=this.formEditSlots.value.type;
    });
    this.companyAdminService.updateSlots(this.editSlots).subscribe(
      (data) => {
        this.toastService.show('Slots updated succesfully!', { classname: 'bg-success text-light', delay: 3000 });
        this.editSlotsChange.emit();
      },
      (error) => {
        this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
      }
    );
  }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  initialForm() {
    this.formEditSlots = this.fb.group({
      type: ['Default',],
    });
  }
}
