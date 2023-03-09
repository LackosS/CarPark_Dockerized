import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CompanyAdminService } from '../services/company-admin.service';
import { CurrentUser, Level, ParkingHouse, Slot } from '../services/models';

@Component({
  selector: 'app-slots',
  templateUrl: './slots.component.html',
  styleUrls: ['./slots.component.css']
})
export class SlotsComponent {
  currUser !: CurrentUser | null;
  parkingHouses : ParkingHouse[] = [];
  levels: Level[] = [];
  slots: Slot[] = [];
  editSlots: Slot[] = [];
  selectedDivs: HTMLDivElement[] = [];

  constructor(private companyAdminService: CompanyAdminService, private authService: AuthService) { }
  ngOnInit():void{
    this.currUser = this.authService.getCurrentUser();
    this.companyAdminService.getParkingHousesByCompanyId(this.currUser?.companyId).subscribe(
      (data) => {
        this.parkingHouses = data;
      }
    );
  }
  getLevelsByParkingHouseId(id: HTMLSelectElement) {
    if(id.value == "-1") return;
    this.companyAdminService.getLevelsByParkingHouseId(+id.value).subscribe(
      (data) => {
        this.levels = data;
        this.levels.sort((a, b) => a.levelNumber - b.levelNumber);
      }
    );
  }
  getSlotsByLevelId(id: HTMLSelectElement) {
    if(id.value == "-1") return;
    this.companyAdminService.getSlotsByLevelId(+id.value).subscribe(
      (data) => {
        this.slots = data;
         this.slots.sort((a, b) => a.slotNumber - b.slotNumber);
      }
    );
  }
  selectSlots(slot: Slot, div: HTMLDivElement){
    if(this.editSlots.includes(slot)){
      this.editSlots.splice(this.editSlots.indexOf(slot), 1);
      div.style.border="none";
    }else{
      this.editSlots.push(slot);
      this.selectedDivs.push(div);
      div.style.border = "3px solid #ffbb00";
    }
  }
  deleteSlotsUpdate(){
    this.editSlots.forEach(element => {
      this.slots.splice(this.slots.indexOf(element), 1);
    });
    this.editSlots = [];
  }
  editSlotsUpdate(){
    this.selectedDivs.forEach(element => {
      element.style.border="none";
    });
    this.editSlots=[];
    this.slots.sort((a, b) => a.slotNumber - b.slotNumber);
  }
}
