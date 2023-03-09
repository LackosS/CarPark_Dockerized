import { Component, OnInit } from '@angular/core';
import { SysAdminService } from '../../services/sys-admin.service';
import { Company, CurrentUser, Reservation, User } from '../../services/models';
import { forkJoin, Observable } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { CompanyAdminService } from 'src/app/services/company-admin.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ChartComponent implements OnInit {
  currUser !: CurrentUser | null;
  
  chartCompaniesOptions: any;
  companiesDataPoints: any = [];

  chartUsersOptions: any;
  usersDataPoints: any = [];

  constructor(private sysAdminService: SysAdminService, private authService: AuthService, private companyAdminService: CompanyAdminService) {

  }

  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();
    if(this.currUser?.role == "SystemAdmin"){
    this.generateCompaniesDataPoints();
    this.generateCompaniesChartOptions();
    }
    else if(this.currUser?.role == "CompanyAdmin"){
    this.generateUsersDataPoints();
    this.generateUsersChartOptions();
    }

  }

  generateCompaniesDataPoints(): void {
    let companies :Observable<Company[]> = this.sysAdminService.getCompanies();
    let users :Observable<User[]> = this.sysAdminService.getUsers();

    forkJoin([companies, users]).subscribe(
      (data) => {
        let companies: Company[] = data[0];
        let users: User[] = data[1];
        for (let i = 0; i < companies.length; i++) {
          let company: Company = companies[i];
          let totalUsers: number = 0;
          for (let j = 0; j < users.length; j++) {
            let user: User = users[j];
            if (user.companyId == company.id) {
              totalUsers++;
            }
          }
          this.companiesDataPoints.push({ label: company.name, y: totalUsers });
          this.chartCompaniesOptions.data.dataPoints = this.companiesDataPoints;
        }
        this.generateCompaniesChartOptions();
      }
    );

  }
  generateCompaniesChartOptions(): void {
    this.chartCompaniesOptions = {
      backgroundColor: "#252525",
      creditText: "",
      title: {
        text: "Total Users by Companies",
        fontColor: "#ffbb00",
        fontFamily: "Nunito",
      },
      animationEnabled: true,

      axisY: {
        includeZero: true,
        suffix: "",
        labelFontColor: "white",
        labelFontFamily: "Nunito",
        labelFontSize: 10,
      },
      axisX: {
        labelFontColor: "white",
        labelFontFamily: "Nunito",
        labelFontSize: 10,
      },
      data: [{
        type: "column",
        indexLabelFontColor: "white",
        indexLabelFontFamily: "Nunito",
        indexLabelFontSize: 8,
        color: "#ffbb00",
        indexLabel: "{y}",
        yValueFormatString: "#,####",
        dataPoints: this.companiesDataPoints
      }]
    }
  }

  generateUsersDataPoints(): void {
    let users :Observable<User[]> = this.companyAdminService.getUsersByCompanyId(this.currUser?.companyId!);
    let reservations :Observable<Reservation[]> = this.companyAdminService.getReservationsByUserId(this.currUser?.userId!);

    forkJoin([users, reservations]).subscribe(
      (data) => {
        let users: User[] = data[0];
        let reservations: any[] = data[1];
        for (let i = 0; i < users.length; i++) {
          let user: User = users[i];
          let totalReservations: number = 0;
          for (let j = 0; j < reservations.length; j++) {
            let reservation: any = reservations[j];
            if (reservation.userId == user.id) {
              totalReservations++;
            }
          }
          this.usersDataPoints.push({ label: user.fullName, y: totalReservations });
          this.chartUsersOptions.data.dataPoints = this.usersDataPoints;
        }
        this.generateUsersChartOptions();
      }
    );
  }
  generateUsersChartOptions(): void {
    this.chartUsersOptions = {
      backgroundColor: "#252525",
      creditText: "",
      title: {
        text: "Total Reservations by Users",
        fontColor: "#ffbb00",
        fontFamily: "Nunito",
      },
      animationEnabled: true,

      axisY: {
        includeZero: true,
        suffix: "",
        labelFontColor: "white",
        labelFontFamily: "Nunito",
        labelFontSize: 10,
      },
      axisX: {
        labelFontColor: "white",
        labelFontFamily: "Nunito",
        labelFontSize: 10,
      },
      data: [{
        type: "column",
        indexLabelFontColor: "white",
        indexLabelFontFamily: "Nunito",
        indexLabelFontSize: 8,
        color: "#ffbb00",
        indexLabel: "{y}",
        yValueFormatString: "#,####",
        dataPoints: this.usersDataPoints
      }]
    }
  }

}
