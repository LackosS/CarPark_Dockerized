import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { CurrentUser, Level, ParkingHouse } from 'src/app/services/models';

@Component({
  selector: 'app-parkinghouse-table',
  templateUrl: './parkinghouse-table.component.html',
  styleUrls: ['./parkinghouse-table.component.css']
})
export class ParkinghouseTableComponent implements OnInit{
  currUser !: CurrentUser | null;
  parkingHouses : ParkingHouse[] = [];
  viewParkingHouses : ParkingHouse[] = [];
  pageNumbersParkingHouse : number[] = [];
  pageNumberParkingHouse : number = 1;

  levels: Level[] = [];
  viewLevels: Level[] = [];
  pageNumbersLevels: number[] = [];
  pageNumberLevel: number = 1;
  
  constructor(private companyAdminService: CompanyAdminService, private authService: AuthService) { }
  
  ngOnInit():void{
    this.currUser = this.authService.getCurrentUser();
    this.pageNumbersParkingHouse = [];
    this.companyAdminService.getParkingHousesByCompanyId(this.currUser?.companyId).subscribe(
      (data) => {
        this.parkingHouses = data;
        let i = 0;
        while (i < Math.ceil(this.parkingHouses.length / 5)) {
          this.pageNumbersParkingHouse.push(++i);
        }
        this.viewParkingHouses = this.parkingHouses.slice(0, 5);
      }
    );
  }
  /* ParkingHouse */
  handleParkingHouseChanges(id: number) {
    const changedParkingHouse = this.parkingHouses.findIndex(parkingHouses => parkingHouses.id == id);
    if (changedParkingHouse != -1) {
      this.parkingHouses[changedParkingHouse].isActive = this.parkingHouses[changedParkingHouse].isActive == 1 ? 0 : 1;
      this.companyAdminService.updateParkingHouse(this.parkingHouses[changedParkingHouse]).subscribe();
    }
  }
  handleParkingHousePageChanges(pageNumber: number) {
    if(Math.ceil(this.parkingHouses.length / 5)>this.pageNumbersParkingHouse.length){
      this.pageNumbersParkingHouse.push(this.pageNumbersParkingHouse.length+1);
    }
    else if(Math.ceil(this.parkingHouses.length / 5)<this.pageNumbersParkingHouse.length){
      this.pageNumbersParkingHouse.pop();
    }
    this.viewParkingHouses = this.parkingHouses.slice((pageNumber - 1) * 5, pageNumber * 5);
    this.pageNumberParkingHouse = pageNumber;
  }
  filterParkingHouses(search: HTMLInputElement) {
    if (search.value == "") { this.viewParkingHouses = this.parkingHouses.slice(0, 5); return; }
    this.viewParkingHouses = this.parkingHouses.filter(parkingHouses => parkingHouses.name.toLowerCase().includes(search.value.toLowerCase()));
  }
  /* Level */
  getLevelsByParkingHouseId(id: HTMLSelectElement) {
    if(id.value == "-1") return;
    this.companyAdminService.getLevelsByParkingHouseId(+id.value).subscribe(
      (data) => {
        this.pageNumbersLevels = [];
        this.levels = data;
        let i = 0;
        while (i < Math.ceil(this.levels.length / 5)) {
          this.pageNumbersLevels.push(++i);
        }
        this.viewLevels = this.levels.slice(0, 5);
        this.viewLevels.sort((a, b) => a.levelNumber - b.levelNumber);
      }
    );
  }
  handleLevelChanges(id: number) {
    const changedLevel = this.levels.findIndex(level => level.id == id);
    if (changedLevel != -1) {
      this.levels[changedLevel].isActive = this.levels[changedLevel].isActive == 1 ? 0 : 1;
      this.companyAdminService.updateLevel(this.levels[changedLevel]).subscribe();
    }
  }
  handleLevelPageChanges(pageNumber: number) {
    if(Math.ceil(this.levels.length / 5)>this.pageNumbersLevels.length){
      this.pageNumbersLevels.push(this.pageNumbersLevels.length+1);
    }
    else if(Math.ceil(this.levels.length / 5)<this.pageNumbersLevels.length){
      this.pageNumbersLevels.pop();
    }
    this.viewLevels = this.levels.slice((pageNumber - 1) * 5, pageNumber * 5);
    this.pageNumberLevel = pageNumber;
    this.viewLevels.sort((a, b) => a.levelNumber - b.levelNumber);
  } 
}
