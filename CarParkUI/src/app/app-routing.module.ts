import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CompanyRegisterComponent } from './company-register/company-register.component';
import { HomeComponent } from './home/home.component';
import { SysAdminGuard } from './guards/sys-admin.guard';
import { CompanyAdminGuard } from './guards/company-admin.guard';
import { LoggedInGuard } from './guards/logged-in.guard';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { UsersComponent } from './users/users.component';
import { CompaniesComponent } from './companies/companies.component';
import { ParkinghousesComponent } from './parkinghouses/parkinghouses.component';
import { SlotsComponent } from './slots/slots.component';
import { ReserveComponent } from './reserve/reserve.component';
import { ReservationsComponent } from './reservations/reservations.component';
import { ActivatedAccountGuard } from './guards/activated-account.guard';
import { AdminGuard } from './guards/admin.guard';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent, },
  { path: 'company-register', component: CompanyRegisterComponent },
  {
    path: 'change-password', component: ChangePasswordComponent,
    canActivate: [LoggedInGuard]
  },
  {
    path: 'admin/home', component: HomeComponent,
    canActivate: [LoggedInGuard, ActivatedAccountGuard, AdminGuard]
  },
  {
    path: 'admin/system/companies', component: CompaniesComponent,
    canActivate: [LoggedInGuard, SysAdminGuard, ActivatedAccountGuard]
  },
  {
    path: 'admin/company/users', component: UsersComponent,
    canActivate: [LoggedInGuard, CompanyAdminGuard, ActivatedAccountGuard]
  },
  {
    path: 'admin/company/parkinghouses', component: ParkinghousesComponent,
    canActivate: [LoggedInGuard, CompanyAdminGuard, ActivatedAccountGuard]
  },
  {
    path: 'admin/company/slots', component: SlotsComponent
    , canActivate: [LoggedInGuard, CompanyAdminGuard, ActivatedAccountGuard]
  },
  {
    path: 'myreservations', component: ReservationsComponent,
    canActivate: [LoggedInGuard, ActivatedAccountGuard]
  },
  {
    path: 'reserve', component: ReserveComponent,
    canActivate: [LoggedInGuard, ActivatedAccountGuard]
  },
    {
    path: '**', component: LoginComponent,
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
