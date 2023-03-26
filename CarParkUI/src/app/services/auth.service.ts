import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  RegisterCompany,
  ChangePasswordModel,
  CurrentUser,
  Login,
  RegisterUser,
} from './models';
import { Constans } from '../utilities/constans';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(login: Login): Observable<any> {
    return this.http.post<any>(Constans.loginUrl, login);
  }
  getToken(): string | null {
    return sessionStorage.getItem('carParkUserToken') || localStorage.getItem('carParkUserToken');
  }
  isLoggedIn() {
    const currUser = this.getCurrentUser();
    return currUser !== null && currUser.exp > Date.now() / 1000;
  }
  isActivated(){
    const currUser = this.getCurrentUser();
    if(currUser !== null && currUser.isValid==0){
      sessionStorage.removeItem('carParkUserToken');
      localStorage.removeItem('carParkUserToken');
      return false;
    }
    return true;
  }
  logout() {
    sessionStorage.removeItem('carParkUserToken');
    localStorage.removeItem('carParkUserToken');
  }
  register(company: RegisterCompany): Observable<any> {
    return this.http.post<any>(Constans.registerUrl, company);
  }
  changePassword(ChangePasswordModel: ChangePasswordModel) {
    return this.http.post<any>(Constans.changePasswordUrl, ChangePasswordModel);
  }
  registerUser(user: RegisterUser){
    return this.http.post<any>(Constans.registerUserUrl, user);
  }
  getCurrentUser(): CurrentUser | null {
    const token =
      localStorage.getItem('carParkUserToken') ||
      sessionStorage.getItem('carParkUserToken');
    if (token) {
      const decodedToken = jwt_decode(token) as CurrentUser;
      return decodedToken;
    }
    return null;
  }
  registerSystemAdmin(){
    return this.http.post<any>(Constans.registerSysAdminUrl, {});
  }
}
