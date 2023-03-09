import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { CurrentUser } from 'src/app/services/models';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
  currUser! : CurrentUser | null;
  
 constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();
  }

 logout() {
   this.authService.logout();
   this.router.navigate(['/login']);
 }
}
