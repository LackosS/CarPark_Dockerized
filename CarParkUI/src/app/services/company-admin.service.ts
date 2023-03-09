import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Constans } from '../utilities/constans';
import { Level, ParkingHouse, Reservation, Slot, User } from './models';

@Injectable({
  providedIn: 'root'
})
export class CompanyAdminService {

  constructor(private http: HttpClient) { }

  getUsersByCompanyId(id: any):Observable<User[]>{
    return this.http.get<User[]>(Constans.getUsersByCompany + "/" + id);
  }
  updateUser(user: User): Observable<User>{
    return this.http.patch<User>(Constans.updateUsers, user);
  }
  deleteUser(id: string): Observable<User>{
    return this.http.delete<User>(Constans.deleteUser + "/" + id);
  }
  getParkingHousesByCompanyId(id: any): Observable<ParkingHouse[]>{    
    return this.http.get<ParkingHouse[]>(Constans.getParkingHousesByCompany + "/" + id);
  }
  getReservationsByUserId(id: string): Observable<Reservation[]>{
    return this.http.get<Reservation[]>(Constans.getReservationsByUsers + "/" + id);
  }
  addParkingHouse(parkingHouse: ParkingHouse): Observable<number>{
    return this.http.post<number>(Constans.addParkingHouse, parkingHouse);
  }
  updateParkingHouse(parkingHouse: ParkingHouse): Observable<ParkingHouse>{
    return this.http.patch<ParkingHouse>(Constans.updateParkingHouses, parkingHouse);
  }
  deleteParkingHouse(id: number): Observable<ParkingHouse>{
    return this.http.delete<ParkingHouse>(Constans.deleteParkingHouse + "/" + id);
  }
  getLevelsByParkingHouseId(id: number): Observable<Level[]>{
    return this.http.get<Level[]>(Constans.getLevelsByParkingHouseId + "/" + id);
  }
  updateLevel(level: Level): Observable<Level>{
    return this.http.patch<Level>(Constans.updateLevels, level);
  }
  addLevel(level: Level): Observable<number>{
    return this.http.post<number>(Constans.addLevel, level);
  }
  addSlots(slots: any): Observable<number>{
    return this.http.post<number>(Constans.addSlots, slots);
  }
  deleteLevel(id: number): Observable<Level>{
    return this.http.delete<Level>(Constans.deleteLevel + "/" + id);
  }
  addSlot(slot: any): Observable<number>{
    return this.http.post<number>(Constans.addSlot, slot);
  }
  getSlotsByLevelId(id: number): Observable<Slot[]>{
    return this.http.get<Slot[]>(Constans.getSlotsByLevelId + "/" + id);
  }
  updateSlots(slots: Slot[]): Observable<Slot>{
    return this.http.patch<Slot>(Constans.updateSlots,slots);
  }
  deleteSlots(slots: Slot[]): Observable<Slot[]>{
    return this.http.post<Slot[]>(Constans.deleteSlots,slots);
  }
}
