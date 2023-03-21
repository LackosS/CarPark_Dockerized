import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CompanyRegisterComponent } from './company-register/company-register.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './utilities/nav/nav.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastComponent } from './utilities/toast/toast.component';
import { ToastGlobalComponent } from './utilities/toast-global/toast-global.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { BaseComponent } from './base/base.component';
import { ChartComponent } from './utilities/chart/chart.component';
 
import * as CanvasJSAngularChart from '../assets/charts/canvasjs.angular.component';
import { UsersComponent } from './users/users.component';
var CanvasJSChart = CanvasJSAngularChart.CanvasJSChart;
import { NgCircleProgressModule } from 'ng-circle-progress';
import { CompaniesComponent } from './companies/companies.component';
import { DeleteCompanyModalComponent } from './utilities/modals/delete-company-modal/delete-company-modal.component';
import { RegisterUserModalComponent } from './utilities/modals/register-user-modal/register-user-modal.component';
import { DeleteUserModalComponent } from './utilities/modals/delete-user-modal/delete-user-modal.component';
import { ParkinghousesComponent } from './parkinghouses/parkinghouses.component';
import { AddParkinghouseModalComponent } from './utilities/modals/add-parkinghouse-modal/add-parkinghouse-modal.component';
import { DeleteParkinghouseModalComponent } from './utilities/modals/delete-parkinghouse-modal/delete-parkinghouse-modal.component';
import { AddLevelModalComponent } from './utilities/modals/add-level-modal/add-level-modal.component';
import { DeleteLevelModalComponent } from './utilities/modals/delete-level-modal/delete-level-modal.component';
import { CompaniesTableComponent } from './utilities/tables/companies-table/companies-table.component';
import { UsersTableComponent } from './utilities/tables/users-table/users-table.component';
import { ParkinghouseTableComponent } from './utilities/tables/parkinghouse-table/parkinghouse-table.component';
import { EditSlotsModalComponent } from './utilities/modals/edit-slots-modal/edit-slots-modal.component';
import { AddSlotModalComponent } from './utilities/modals/add-slot-modal/add-slot-modal.component';
import { SlotsComponent } from './slots/slots.component';
import { ReservationsTableComponent } from './utilities/tables/reservations-table/reservations-table.component';
import { ReserveComponent } from './reserve/reserve.component';
import { DeleteReservationModalComponent } from './utilities/modals/delete-reservation-modal/delete-reservation-modal.component';
import { ReservationsComponent } from './reservations/reservations.component';
import { TokenInterceptor } from './services/token.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    CompanyRegisterComponent,
    LoginComponent,
    HomeComponent,
    NavComponent,
    ChangePasswordComponent,
    BaseComponent,
    ChartComponent,
    CanvasJSChart,
    UsersComponent,
    CompaniesComponent,
    ParkinghousesComponent,
    CompaniesTableComponent,
    UsersTableComponent,
    ParkinghouseTableComponent,
    SlotsComponent,
    ReservationsTableComponent,
    ReserveComponent,
    ReservationsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    ToastComponent,
    ToastGlobalComponent,
    NgCircleProgressModule.forRoot({}),
    DeleteCompanyModalComponent,
    RegisterUserModalComponent,
    DeleteUserModalComponent,
    AddParkinghouseModalComponent,
    DeleteParkinghouseModalComponent,
    AddLevelModalComponent,
    DeleteLevelModalComponent,
    EditSlotsModalComponent,
    AddSlotModalComponent,
    DeleteReservationModalComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
