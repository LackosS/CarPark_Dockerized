import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/services/auth.service';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { RegisterUser, User } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-register-user-modal',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
  templateUrl: './register-user-modal.component.html',
  styleUrls: ['./register-user-modal.component.css']
})
export class RegisterUserModalComponent {
  formUserRegister!: FormGroup;
  modalOptions: NgbModalOptions | undefined;
  @Input() users: User[] = [];
  @Input() viewUsers: User[] = [];
  @Output() handleUserPageChangesEvent = new EventEmitter<number>();
  
  constructor(private modalService: NgbModal,
    private fb: FormBuilder,
    private toastService: ToastService,
    private authService: AuthService) {
    this.modalOptions = {
      modalDialogClass: 'modal-bg',
      windowClass: 'backdrop-blur',
    }
  }
  ngOnInit() {
   this.initialFrom();
  }
  passwordValidator = (form: FormGroup) => {
    const password = form.get('password');
    const confirmPassword = form.get('confirmPassword');
    return password &&
      confirmPassword &&
      password.value === confirmPassword.value
      ? null
      : { mismatchedPasswords: true };
  };
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  registerUser() {
    const currUser = this.authService.getCurrentUser();
    if (this.formUserRegister.valid) {
      const user : RegisterUser = {
        companyId: currUser?.companyId,
        fullName: this.formUserRegister.value.fullname,
        userName: this.formUserRegister.value.username,
        post: this.formUserRegister.value.role,
        password: this.formUserRegister.value.password
      };
      this.formUserRegister.disable();
      this.authService.registerUser(user).subscribe((res: any) => {
        this.toastService.show('User registered successfully!', { classname: 'bg-success text-light', delay: 3000 });
        this.modalService.dismissAll();
        this.initialFrom();
        const usr : User ={
          id : '',
          companyId: user.companyId,
          fullName: user.fullName,
          role: user.post,
          isValid: 0,
        }
        usr.id = res.id;
        this.users.push(usr);
        this.viewUsers.push(usr); 
        this.handleUserPageChangesEvent.emit();
      },
        (err: any) => {
          this.toastService.show(err.error.message, { classname: 'bg-danger text-light', delay: 3000 })
          this.formUserRegister.enable();
        });
    }
    else{
      if(this.formUserRegister.get('fullname')?.hasError('required') || this.formUserRegister.get('username')?.hasError('required') || this.formUserRegister.get('password')?.hasError('required') || this.formUserRegister.get('confirmPassword')?.hasError('required')){
        this.toastService.show('Please fill all the fields!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.formUserRegister.get('password')?.hasError('minlength') || this.formUserRegister.get('password')?.hasError('pattern')){
        this.toastService.show('Password has to be min. 8 characters and contain at least one upper letter and number!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
      else if(this.formUserRegister.hasError('mismatchedPasswords')){
        this.toastService.show('Passwords do not match!',  { classname: 'bg-danger text-light', delay: 3000 });
      }
    }
  }
  initialFrom(){
    this.formUserRegister = this.fb.group({
      fullname: ['', Validators.required],
      username: ['', Validators.required],
      role:['Employee'],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/)),
        ],
      ],
      confirmPassword: ['', Validators.required],
    },
      { validator: this.passwordValidator }
    );
  }
}
