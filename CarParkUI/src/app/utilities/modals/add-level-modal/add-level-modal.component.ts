import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/services/auth.service';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { Level, Slot } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-add-level-modal',
  templateUrl: './add-level-modal.component.html',
  styleUrls: ['./add-level-modal.component.css'],
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class AddLevelModalComponent implements OnInit {
  formAddLevel!: FormGroup;
  modalOptions: NgbModalOptions | undefined;
  @Input() levels: Level[] = [];
  @Input() viewLevels: Level[] = [];
  @Input() select! : HTMLSelectElement;
  @Output() handleLevelsPageChangesEvent = new EventEmitter<number>();

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
  addLevel(select : HTMLSelectElement) {
    if(this.formAddLevel.valid){
      const Level: Level = {
        id:0,
        parkingHouseId: parseInt(select.value),
        parkingHouseName:'',
        levelNumber: this.formAddLevel.value.name,
        isActive: 0,
        slot: this.formAddLevel.value.slots,
      }
      this.formAddLevel.disable();
      this.companyAdminService.addLevel(Level).subscribe((res)=>{
        this.toastService.show('Level added successfully!',{ classname: 'bg-success text-light', delay: 3000 });
        this.modalService.dismissAll();
        this.formAddLevel.enable();
        this.initialFrom();
        Level.id=res;
        this.levels.push(Level);
        this.viewLevels.push(Level);
        this.handleLevelsPageChangesEvent.emit();
        const Slot : Slot ={
          id:0,
          levelId:Level.id,
          slotNumber:0,
          type:'Default',
          initialNumber:Level.slot,
          isFree:false
        }
        this.companyAdminService.addSlots(Slot).subscribe((res)=>{
          this.toastService.show('Slots added successfully!',{ classname: 'bg-success text-light', delay: 3000 });
        }
        ,(err)=>{
          this.toastService.show('Something went wrong!',{ classname: 'bg-danger text-light', delay: 3000 });
        }
        );
      },
      (err)=>{
        this.toastService.show('Something went wrong!',{ classname: 'bg-danger text-light', delay: 3000 });
        this.formAddLevel.enable();
      });
    }
    else{
      if(this.formAddLevel.get('name')?.hasError('required') || this.formAddLevel.get('slots')?.hasError('required'))
        this.toastService.show('Please fill all the fields!',{ classname: 'bg-danger text-light', delay: 3000 });
    }
  }
  initialFrom() {
    this.formAddLevel = this.fb.group({
      name: ['', Validators.required],
      slots: ['', Validators.required],
    });
  }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
}
