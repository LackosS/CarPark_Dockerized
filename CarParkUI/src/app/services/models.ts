export interface RegisterCompany  {
    CompanyName: string,
    Name: string,
    UserName: string,
    Password: string,
}
export interface CurrentUser {
    userId: string,
    name: string,
    role: string,
    companyId: number,
    companyName: string,
    companyIsValid: number,
    exp: number,
    isValid: number
}
export interface Login{
    username: string,
    password: string,
}
export interface RegisterUser{
    companyId: any,
    fullName: string,
    userName: string,
    password: string,
    post: string,
}
export interface ChangePasswordModel{
    UserName: string,
    OldPassword: string,
    NewPassword: string
}

export interface Company{
    id: number,
    name: string,
    isValid : number
}
export interface User{
    id: string,
    companyId: number,
    fullName: string,
    role: string,
    isValid: number,
}
export interface ParkingHouse{
    id: number,
    companyId: any,
    name: string,
    isActive: number,
    level: number,
    slots: number
}
export interface Reservation{
    id: number,
    userId: any,
    parkingHouseId: number,
    levelId : number,
    slotId: any,
    parkingHouseName: string,
    levelNumber: number,
    slotNumber: number,
    date: string,
}

export interface Level{
    id: number,
    parkingHouseId: number,
    parkingHouseName: string,
    isActive: number,
    levelNumber: number,
    slot: number
}
export interface Slot{
    id: number,
    levelId: number,
    slotNumber: number,
    type: string,
    initialNumber: number,
    isFree : boolean
}