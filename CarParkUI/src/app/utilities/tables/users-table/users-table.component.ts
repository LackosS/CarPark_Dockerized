import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { CurrentUser, User } from 'src/app/services/models';

@Component({
  selector: 'app-users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit{
  currUser !: CurrentUser | null;
  users: User[] = [];
  viewUsers: User[] = [];
  pageNumbersUsers: number[] = [];
  pageNumberUser: number = 1;

  constructor(private companyAdminService: CompanyAdminService,private authService: AuthService){

  }
  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();
    this.companyAdminService.getUsersByCompanyId(this.currUser?.companyId).subscribe(
      (data) => {
        this.users = data;
        let i = 0;
        while (i < Math.ceil(this.users.length / 15)) {
          this.pageNumbersUsers.push(++i);
        }
        this.viewUsers = this.users.slice(0, 15);
        this.viewUsers.splice(this.viewUsers.findIndex(user => user.id == this.currUser?.userId), 1);
      }
    );
  }
  handleUserChanges(id: string) {
    const changedUser = this.users.findIndex(user => user.id == id);
    if (changedUser != -1) {
      this.users[changedUser].isValid = this.users[changedUser].isValid == 1 ? 0 : 1;
      this.companyAdminService.updateUser(this.users[changedUser]).subscribe();
    }
  }
  handleUserPageChanges(pageNumber: number) {
    if(Math.ceil(this.users.length / 15)>this.pageNumbersUsers.length){
      this.pageNumbersUsers.push(this.pageNumbersUsers.length+1);
    }
    else if(Math.ceil(this.users.length / 15)<this.pageNumbersUsers.length){
      this.pageNumbersUsers.pop();
    }
    this.viewUsers = this.users.slice((pageNumber - 1) * 15, pageNumber * 15);
    this.pageNumberUser = pageNumber;
  }
  filterUsers(search: HTMLInputElement) {
    if (search.value == "") { this.viewUsers = this.users.slice(0, 15); return; }
    this.viewUsers = this.users.filter(user => user.fullName.toLowerCase().includes(search.value.toLowerCase()));
  }
}
