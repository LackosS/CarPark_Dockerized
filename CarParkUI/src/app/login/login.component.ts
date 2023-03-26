import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { delay } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { CurrentUser, Login } from '../services/models';
import { ToastService } from '../services/toast.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild('errorToastTemplate') public errorToastTemplate!: TemplateRef<any>;
  form!: FormGroup;
  currUser !: CurrentUser | null;
  constructor(private authService: AuthService, private fb: FormBuilder, private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.authService.registerSystemAdmin().subscribe();
    this.currUser = this.authService.getCurrentUser();
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    if (this.authService.isLoggedIn()) {
      if(this.currUser?.role == 'Boss' || this.currUser?.role == 'Employee'){
        this.router.navigate(['/myreservations']);
      }
      else{
        this.router.navigate(['/admin/home']);
      }
    }
  }

  authorize(signup: HTMLButtonElement, submit: HTMLButtonElement) {
    if (this.form.valid) {

      const login: Login = { username: this.form.value.username, password: this.form.value.password };
      this.form.disable();
      signup.disabled = true;
      submit.disabled = true;

      this.authService.login(login).subscribe(res => {
        localStorage.setItem('carParkUserToken', res.token);
        const currUser = this.authService.getCurrentUser();
        this.toastService.show('Welcome ' + currUser?.name + '!', { classname: 'bg-success text-light', delay: 3000 });
        if (currUser?.role == 'Boss' || currUser?.role == 'Employee') {
          setTimeout(() => { this.router.navigate(['/myreservations']); }, 3000);
        }
        else {
          setTimeout(() => { this.router.navigate(['/admin/home']); }, 3000);
        }

      }, err => {
        this.toastService.show(err.error.message, { classname: 'bg-danger text-light', delay: 3000 });

        this.form.enable();
        signup.disabled = false;
        submit.disabled = false;
      },
      );
    }
  }
}
