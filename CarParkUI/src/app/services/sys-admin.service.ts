import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Company, ParkingHouse, Reservation, User} from './models';
import { Constans } from '../utilities/constans';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SysAdminService {
  constructor(private http: HttpClient) { }

  getCompanies(): Observable<Company[]>{    
    return this.http.get<Company[]>(Constans.getCompanies);
  }
  getUsers(): Observable<User[]>{    
    return this.http.get<User[]>(Constans.getUsers);
  }
  getParkingHouses(): Observable<ParkingHouse[]>{    
    return this.http.get<ParkingHouse[]>(Constans.getParkingHouses);
  }
  getReservations(): Observable<Reservation[]>{
    return this.http.get<Reservation[]>(Constans.getReservations);
  }
  updateCompany(companies: Company): Observable<Company>{
    return this.http.patch<Company>(Constans.updateCompany, companies);
  }
  deleteCompany(id: number): Observable<Company>{
    return this.http.delete<Company>(Constans.deleteCompany + "/" + id);
  }
}
