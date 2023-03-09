import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/services/auth.service';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { ParkingHouse } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-add-parkinghouse-modal',
  templateUrl: './add-parkinghouse-modal.component.html',
  styleUrls: ['./add-parkinghouse-modal.component.css'],
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class AddParkinghouseModalComponent implements OnInit {
  formAddParkinghouse!: FormGroup;
  modalOptions: NgbModalOptions | undefined;
  @Input() Parkinghouses: ParkingHouse[] = [];
  @Input() viewParkinghouses: ParkingHouse[] = [];
  @Output() handleParkingHousePageChangesEvent = new EventEmitter<number>();
  
  constructor(private modalService: NgbModal,
    private fb: FormBuilder,
    private toastService: ToastService,
    private authService: AuthService,
    private companyAdminService: CompanyAdminService,) {
    this.modalOptions = {
      modalDialogClass: 'modal-bg',
      windowClass: 'backdrop-blur',
    }
  }
  ngOnInit(): void {
    this.initialFrom();
  }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  addParkingHouse() {
    const currUser = this.authService.getCurrentUser();
    if (this.formAddParkinghouse.valid) {
      const parkinghouse : ParkingHouse = {
        companyId: currUser?.companyId,
        name: this.formAddParkinghouse.value.name,
        level: this.formAddParkinghouse.value.levels,
        slots: this.formAddParkinghouse.value.slots,
        id: 0,
        isActive: 0
      };
      this.formAddParkinghouse.disable();
      this.companyAdminService.addParkingHouse(parkinghouse).subscribe(
        (res) => {
          this.toastService.show('Parkinghouse added successfully!',{ classname: 'bg-success text-light', delay: 3000 });
          this.formAddParkinghouse.enable();
          this.modalService.dismissAll();
          this.initialFrom();
          parkinghouse.id=res;
          this.viewParkinghouses.push(parkinghouse);
          this.Parkinghouses.push(parkinghouse);
          this.handleParkingHousePageChangesEvent.emit();
        },
        (err) => {
          this.toastService.show('Something went wrong!',{ classname: 'bg-danger text-light', delay: 3000 });
          this.formAddParkinghouse.enable();
        }
      );
    }
    else{
      if(this.formAddParkinghouse.get('name')?.hasError('required') || this.formAddParkinghouse.get('levels')?.hasError('required') || this.formAddParkinghouse.get('slots')?.hasError('required')){
        this.toastService.show('Please fill all the fields!',{ classname: 'bg-danger text-light', delay: 3000 });
      }
    }
  }
  initialFrom() {
    this.formAddParkinghouse = this.fb.group({
      name: ['', Validators.required],
      levels: ['', Validators.required],
      slots: ['', Validators.required],
    });
  }

}
