import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { RegisterCompany } from '../services/models';
import { ToastService } from '../services/toast.service';

@Component({
  selector: 'app-register',
  templateUrl: './company-register.component.html',
  styleUrls: ['./company-register.component.css'],
})
export class CompanyRegisterComponent implements OnInit {
  form!: FormGroup;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router,
    private toastService: ToastService
  ) {}

  passwordValidator = (form: FormGroup) => {
    const password = form.get('password');
    const confirmPassword = form.get('passwordcheck');
    return password &&
      confirmPassword &&
      password.value === confirmPassword.value
      ? null
      : { mismatchedPasswords: true };
  };

  ngOnInit(): void {
    this.form = this.fb.group(
      {
        companyname: ['', Validators.required],
        fullname: ['', Validators.required],
        username: ['', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(8),
            Validators.pattern(new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/)),
          ],
        ],
        passwordcheck: ['', Validators.required],
        agree: [null, Validators.required],
      },
      { validator: this.passwordValidator }
    );
  }

  register(signup:HTMLButtonElement) {
    if (this.form.valid) {

      const company: RegisterCompany = {
        CompanyName: this.form.value.companyname,
        Name: this.form.value.fullname,
        UserName: this.form.value.username,
        Password: this.form.value.password,
      };

      signup.disabled = true;
      this.form.disable();

      this.authService.register(company).subscribe((res) => {
        this.toastService.show('Successful registration!', { classname: 'bg-success text-light', delay: 3000 });
        setTimeout(() => {this.router.navigate(['/login']);}, 3000);
      },
      err=>{
        this.toastService.show(err.error.message, { classname: 'bg-danger text-light', delay: 3000 });
        signup.disabled = false;
        this.form.enable();
      });
    }
    else{
      if(this.form.get('companyname')?.hasError('required') || this.form.get('fullname')?.hasError('required') || this.form.get('username')?.hasError('required') || this.form.get('password')?.hasError('required') || this.form.get('passwordcheck')?.hasError('required')){
        this.toastService.show('Please fill all the fields!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.form.get('password')?.hasError('minlength') || this.form.get('password')?.hasError('pattern')){
        this.toastService.show('Password has to be min. 8 characters and contain at least one upper letter and number!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.form.hasError('mismatchedPasswords')){
        this.toastService.show('Passwords do not match!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.form.get('agree')?.hasError('required')){
        this.toastService.show('You must agree to the terms and conditions!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
    }
  }
}
