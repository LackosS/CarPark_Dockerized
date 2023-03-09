import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { ParkingHouse } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-delete-parkinghouse-modal',
  templateUrl: './delete-parkinghouse-modal.component.html',
  styleUrls: ['./delete-parkinghouse-modal.component.css'],
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None
})
export class DeleteParkinghouseModalComponent {
  @Input() parkingHouses: ParkingHouse[] = [];
  @Input() viewParkingHouses: ParkingHouse[] = [];
  @Input() parkingHouseId: number = 0;
  @Output() handleParkingHousePageChangesEvent = new EventEmitter<number>();

  modalOptions: NgbModalOptions | undefined;
  constructor(private modalService: NgbModal, private companyAdminService: CompanyAdminService,private toastService:ToastService) { }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  deleteParkinghouse(id: number) {
    const deletedParkinghouse = this.parkingHouses.findIndex(parkinghouse => parkinghouse.id == id);
    if (deletedParkinghouse != -1) {
      this.parkingHouses.splice(deletedParkinghouse, 1);
      this.viewParkingHouses.splice(deletedParkinghouse, 1);
      this.companyAdminService.deleteParkingHouse(id).subscribe();
      this.handleParkingHousePageChangesEvent.emit();
      this.toastService.show('Parkinghouse deleted successfully!', { classname: 'bg-success text-light', delay: 3000 });
    }
    else{
      this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
    }
  }
}
