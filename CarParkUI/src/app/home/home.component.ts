import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CompanyAdminService } from '../services/company-admin.service';
import { CurrentUser } from '../services/models';
import { SysAdminService } from '../services/sys-admin.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  currUser !: CurrentUser | null;
  
  totalCompanies: number = 0;
  totalUsers: number = 0;
  totalParkinghouses: number = 0;
  totalReservations: number = 0;
  activeCompanies: number = 0;
  inactiveCompanies: number = 0;

  totalUsersByCompany: number = 0;
  totalParkinghousesByCompany: number = 0;
  totalLevels: number = 0;
  totalSlots: number = 0;
  activeUsers: number = 0;
  inactiveUsers: number = 0;

  constructor(private sysAdminService: SysAdminService,private authService:AuthService,private companyAdminService:CompanyAdminService) {

  }
  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();

    if(this.currUser?.role == "SystemAdmin"){
    this.getNumberOfCompanies();
    this.getNumberOfUsers();
    this.getNumberOfParkingHouses();
    this.getNumberOfReservations();
    }
    else if(this.currUser?.role == "CompanyAdmin"){
    this.getNumberOfUsersByCompany();
    this.getNumberOfParkingHousesByCompany();
    }
  }
  getNumberOfCompanies(): void {
    this.sysAdminService.getCompanies().subscribe(
      (data) => {
        this.totalCompanies = data.length;
        data.forEach((company) => {
          if (company.isValid == 1) {
            this.activeCompanies++;
          } else {
            this.inactiveCompanies++;
          }
        }
        );
      }
    );
  }
  getNumberOfUsers(): void {
    this.sysAdminService.getUsers().subscribe(
      (data) => {
        this.totalUsers = data.length;
        data.forEach((user) => {
          if (user.isValid == 1) {
            this.activeUsers++;
          } else {
            this.inactiveUsers++;
          }
        }
        );
      }
    );
  }
  getNumberOfParkingHouses(): void {
    this.sysAdminService.getParkingHouses().subscribe(
      (data) => {
        this.totalParkinghouses = data.length;
      }
    );
  }
  getNumberOfReservations(): void {
    this.sysAdminService.getReservations().subscribe(
      (data) => {
        this.totalReservations = data.length;
      }
    );
  }

  getNumberOfUsersByCompany(): void {
    this.companyAdminService.getUsersByCompanyId(this.currUser?.companyId).subscribe(
      (data) => {
        this.totalUsersByCompany = data.length;
        data.forEach((user) => {
          if (user.isValid == 1) {
            this.activeUsers++;
          } else {
            this.inactiveUsers++;
          }
        }
        );
      }
    );
  }
  getNumberOfParkingHousesByCompany(): void {
    this.companyAdminService.getParkingHousesByCompanyId(this.currUser?.companyId).subscribe(
      (data) => {
        this.totalParkinghousesByCompany = data.length;
        data.forEach((parkinghouse) => {
          this.totalLevels += parkinghouse.level;
          this.totalSlots += parkinghouse.slots;
        }
        );
      }
    );
  }

}
