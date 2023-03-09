import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { ToastService } from '../services/toast.service';

@Injectable({
  providedIn: 'root'
})
export class ActivatedAccountGuard implements CanActivate {
  constructor(private authService: AuthService, private router : Router, private toastService: ToastService) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree { 
    const currUser = this.authService.getCurrentUser();
    if(!currUser || currUser.isValid==0 || currUser.companyIsValid==0){
      this.toastService.show('Your account must be activated!', { classname: 'bg-danger text-light', delay: 5000 });
      this.authService.logout();
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }
  
}
