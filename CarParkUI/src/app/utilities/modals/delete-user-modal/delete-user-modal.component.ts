import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { User } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-delete-user-modal',
  templateUrl: './delete-user-modal.component.html',
  styleUrls: ['./delete-user-modal.component.css'],
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class DeleteUserModalComponent {
  @Input() users: User[] = [];
  @Input() viewUsers: User[] = [];
  @Input() userId: string = '';
  @Output() handleUserPageChangesEvent = new EventEmitter<number>();

  modalOptions: NgbModalOptions | undefined;
  constructor(private modalService: NgbModal, private companyAdminService: CompanyAdminService, private toastService: ToastService) { }

  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  deleteUser(id: string) {
    const deletedUser = this.users.findIndex(user => user.id == id);
    if (deletedUser != -1) {
      this.users.splice(deletedUser, 1);
      this.viewUsers.splice(deletedUser, 1);
      this.companyAdminService.deleteUser(id).subscribe();
      this.handleUserPageChangesEvent.emit();
      this.toastService.show('User deleted successfully!', { classname: 'bg-success text-light', delay: 3000 });
    }
    else{
      this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
    }
  }
}
