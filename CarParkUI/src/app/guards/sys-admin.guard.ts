import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { ToastService } from '../services/toast.service';

@Injectable({
  providedIn: 'root'
})
export class SysAdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router : Router, private toastService: ToastService) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const currUser = this.authService.getCurrentUser();
    if(!currUser || currUser.role !== 'SystemAdmin'){
      this.router.navigate(['/login']);
      setTimeout(() => {
      this.toastService.show('You do not have a permission to visit this site!', { classname: 'bg-danger text-light', delay: 3000 });
      }, 1000);
      return false;
    }
    return true;
  }
  
}
