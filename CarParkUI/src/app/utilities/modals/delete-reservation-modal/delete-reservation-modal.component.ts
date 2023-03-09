import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { DateTime } from 'luxon';
import { DefaultUserService } from 'src/app/services/default-user.service';
import { Reservation } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-delete-reservation-modal',
  templateUrl: './delete-reservation-modal.component.html',
  styleUrls: ['./delete-reservation-modal.component.css'],
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None
})
export class DeleteReservationModalComponent {
  @Input() reservations: Reservation[] = [];
  @Input() viewReservations: Reservation[] = [];
  @Input() reservationId: number = 0;
  @Output() handleReservationsPageChangesEvent = new EventEmitter<number>();

  modalOptions: NgbModalOptions | undefined;
  constructor(private toastService: ToastService,private modalService: NgbModal,private defaultUserService: DefaultUserService) { }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  deleteReservation(id: number) {
    const deletedReservation = this.reservations.findIndex(reservation => reservation.id == id);
    if (deletedReservation != -1) {
      if(this.reservations[deletedReservation].date <= DateTime.now().toISODate()) { this.toastService.show('You can\'t delete a reservation that has already passed!', { classname: 'bg-danger text-light', delay: 3000 }); return;}
      this.reservations.splice(deletedReservation, 1);
      this.viewReservations.splice(deletedReservation, 1);
      this.defaultUserService.deleteReservation(id).subscribe();
      this.handleReservationsPageChangesEvent.emit();
      this.toastService.show('Reservation deleted successfully!', { classname: 'bg-success text-light', delay: 3000 });
    }
    else{
      this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
    }
  }
}
