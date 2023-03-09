import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CompanyAdminService } from '../services/company-admin.service';
import { DefaultUserService } from '../services/default-user.service';
import { CurrentUser, Level, ParkingHouse, Reservation, Slot } from '../services/models';
import { DateTime } from 'luxon';
import { concat, forkJoin } from 'rxjs';
import { ToastService } from '../services/toast.service';

@Component({
  selector: 'app-reserve',
  templateUrl: './reserve.component.html',
  styleUrls: ['./reserve.component.css']
})
export class ReserveComponent implements OnInit {
  currUser !: CurrentUser | null;
  parkingHouses: ParkingHouse[] = [];
  levels: Level[] = [];
  slots: Slot[] = [];
  selectedSlot: Slot | null = null;
  selectedDiv: HTMLDivElement | null = null;

  constructor(private companyAdminService: CompanyAdminService, private authService: AuthService, private defaultUserService: DefaultUserService, private toastService: ToastService) { }
  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();
    this.companyAdminService.getParkingHousesByCompanyId(this.currUser?.companyId).subscribe(
      (data) => {
        this.parkingHouses = data.filter(x => x.isActive === 1);
      }
    );
  }
  getLevelsByParkingHouseId(id: HTMLSelectElement) {
    if (id.value == "-1") return;
    this.companyAdminService.getLevelsByParkingHouseId(+id.value).subscribe(
      (data) => {
        this.levels = data.filter(x => x.isActive === 1);
        this.levels.sort((a, b) => a.levelNumber - b.levelNumber);
      }
    );
  }
  getSlotsByLevelId(id: HTMLSelectElement) {
    if (id.value == "-1") return;
    this.companyAdminService.getSlotsByLevelId(+id.value).subscribe(
      (slots) => {
        this.slots = slots;
        this.slots.sort((a, b) => a.slotNumber - b.slotNumber);
        const date = DateTime.now().plus({ days: 1 }).toISODate();
        this.slots.forEach(element => {
          this.defaultUserService.isSlotFree(element.id, date).subscribe(
            (data) => {
              if (data) {
                element.isFree = true;
              }
              else {
                element.isFree = false;
              }
            }
          );
        });
      }
    );
  }
  isSlotFree(id: number, date: string) {
    return this.defaultUserService.isSlotFree(id, date);
  }
  selectSlot(slot: Slot, div: HTMLDivElement) {
    if (this.selectedSlot && this.selectedDiv) {
      if (this.selectedSlot.id != slot.id) {
        this.selectedSlot = slot;
        this.selectedDiv.style.border = "none";
        div.style.border = "3px solid #ffbb00";
        this.selectedDiv = div;
      }
    }
    else {
      this.selectedSlot = slot;
      div.style.border = "3px solid #ffbb00";
      this.selectedDiv = div;
    }
  }
  reserve(parkingHouseId: HTMLSelectElement, levelId: HTMLSelectElement) {
    const reservation: Reservation = {
      id: 0,
      userId: this.currUser?.userId,
      parkingHouseId: +parkingHouseId.value,
      levelId: +levelId.value,
      slotId: this.selectedSlot?.id,
      parkingHouseName: "",
      levelNumber: 0,
      slotNumber: 0,
      date: DateTime.now().plus({ days: 1 }).toISODate(),
    };
    let hasReservation = false;
    if (this.selectedSlot?.type == "VIP" && this.currUser?.role != "Boss") {
      this.toastService.show("You do not have permission to reserve VIP slots!", { classname: 'bg-danger text-light', delay: 3000 });
      return;
    }
    if(this.selectedSlot?.isFree == false){
      this.toastService.show("The slot is already reserved!", { classname: 'bg-danger text-light', delay: 3000 });
      return;
    }
    this.defaultUserService.isUserHasReservation(this.currUser?.userId, reservation.date).subscribe(
      (data) => {
        if (!data) {
          this.defaultUserService.addReservation(reservation).subscribe(
            (data) => {
              if(this.selectedDiv) this.selectedDiv.style.backgroundColor = "#6d6d6d";
              this.toastService.show("Reservation successful!", { classname: 'bg-success text-light', delay: 3000 });
            }
          );
        }
        else {
          this.toastService.show("You already have a reservation for tomorrow!", { classname: 'bg-danger text-light', delay: 3000 });
        }
      }
    )
  }
}
