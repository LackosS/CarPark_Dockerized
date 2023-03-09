import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { DefaultUserService } from 'src/app/services/default-user.service';
import { CurrentUser, Reservation } from 'src/app/services/models';

@Component({
  selector: 'app-reservations-table',
  templateUrl: './reservations-table.component.html',
  styleUrls: ['./reservations-table.component.css']
})
export class ReservationsTableComponent implements OnInit{
  currUser !: CurrentUser | null;
  reservations: Reservation[] = [];
  pageNumbersReservations: number[] = [];
  viewReservations: Reservation[] = [];
  pageNumberReservations: number = 1;
  constructor(private defaultUserService: DefaultUserService,private authService: AuthService){}
  ngOnInit(): void {
    this.currUser = this.authService.getCurrentUser();
    this.defaultUserService.getReservationsByUserId(this.currUser?.userId).subscribe(
      (data) => {
        this.reservations = data;
        let i = 0;
        while (i < Math.ceil(this.reservations.length / 15)) {
          this.pageNumbersReservations.push(++i);
        }
        this.viewReservations = this.reservations.slice(0, 15);
        this.viewReservations.sort((a, b) => (a.date > b.date) ? 1 : -1);
      }
    );
  }
  handleReservationsPageChanges(pageNumber: number) {
    if(Math.ceil(this.reservations.length / 15)>this.pageNumbersReservations.length){
      this.pageNumbersReservations.push(this.pageNumbersReservations.length+1);
    }
    else if(Math.ceil(this.reservations.length / 15)<this.pageNumbersReservations.length){
      this.pageNumbersReservations.pop();
    }
    this.viewReservations = this.reservations.slice((pageNumber - 1) * 15, pageNumber * 15);
    this.pageNumberReservations = pageNumber;
  }
}
