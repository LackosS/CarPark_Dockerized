import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { delay, timeout } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { ChangePasswordModel, CurrentUser } from '../services/models';
import { ToastService } from '../services/toast.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit{
  form!: FormGroup;
  currUser !: CurrentUser | null;
  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private toastService: ToastService
  ) {}

  passwordValidator = (form: FormGroup) => {
    const password = form.get('newpassword');
    const confirmPassword = form.get('passwordcheck');
    return password &&
      confirmPassword &&
      password.value === confirmPassword.value
      ? null
      : { mismatchedPasswords: true };
  };
  
  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();
    this.form = this.fb.group(
      {
        username: ['', Validators.required],
        oldpassword: ['', Validators.required],
        newpassword: [
          '',
          [
            Validators.required,
            Validators.minLength(8),
            Validators.pattern(new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/)),
          ],
        ],
        passwordcheck: ['', Validators.required],
      },
      { validator: this.passwordValidator }
    );
  }
  changePassword(confirm: HTMLButtonElement,back: HTMLButtonElement){
    if(this.form.valid){
      this.form.disable();
      back.disabled = true;
      confirm.disabled = true;
      
      const changePw : ChangePasswordModel = {UserName:this.form.value.username, OldPassword:this.form.value.oldpassword, NewPassword:this.form.value.newpassword};

      this.authService.changePassword(changePw).subscribe(
        (res) => {
          this.currUser = this.authService.getCurrentUser();
          switch(this.currUser?.role){
            case 'CompanyAdmin':
              this.toastService.show('Password changed successfully!', { classname: 'bg-success text-light', delay: 2500 });
              setTimeout(() => {this.router.navigate(['/admin/home']);}, 2500);
              break;
            case 'SystemAdmin':
              this.toastService.show('Password changed successfully!', { classname: 'bg-success text-light', delay: 3000 });
              setTimeout(() => {this.router.navigate(['/admin/home']);}, 3000);
              break;
            default:
              this.toastService.show('Password changed successfully!', { classname: 'bg-success text-light', delay: 3000 });
              setTimeout(() => {this.router.navigate(['/myreservations']);}, 3000);
          }
        },
        (error) => {
          this.toastService.show(error.error.message, { classname: 'bg-danger text-light', delay: 3000 });
          confirm.disabled = false;
          back.disabled = false;
          this.form.enable();
        }
      );
    }
    else{
      if(this.form.get('username')?.hasError('required') || this.form.get('oldpassword')?.hasError('required') || this.form.get('newpassword')?.hasError('required') || this.form.get('passwordcheck')?.hasError('required')){
        this.toastService.show('Please fill all fields!', { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.form.get('newpassword')?.hasError('minlength') || this.form.get('newpassword')?.hasError('pattern')){
        this.toastService.show('Password has to be min. 8 characters and contain at least one upper letter and number!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.form.hasError('mismatchedPasswords')){
        this.toastService.show('Passwords do not match!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
    }
  }
}
