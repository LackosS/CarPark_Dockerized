import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Constans } from '../utilities/constans';
import { Reservation } from './models';

@Injectable({
  providedIn: 'root'
})
export class DefaultUserService {

  constructor(private http: HttpClient) { }

  getReservationsByUserId(id: any): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(Constans.getReservationsByUserId +"/"+ id);
  }
  deleteReservation(id: number): Observable<any> {
    return this.http.delete(Constans.deleteReservation +"/"+ id);
  }
  isSlotFree(id:number, date:string){
    return this.http.get<boolean>(Constans.IsSlotFree +"/"+ id +"/"+ date);
  }
  addReservation(reservation: Reservation): Observable<any> {
    return this.http.post(Constans.addReservation, reservation);
  }
  isUserHasReservation(id: any, date: string): Observable<boolean> {
    return this.http.get<boolean>(Constans.isUserHasReservation +"/"+ id +"/"+ date);
  }
}
