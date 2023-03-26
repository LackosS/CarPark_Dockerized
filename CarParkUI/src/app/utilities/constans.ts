export class Constans{
    static readonly basicUrl = "http://localhost:7154";
    
    //AUTHENTICATION URLS
    static readonly loginUrl = this.basicUrl + "/UserProfile/Login";
    static readonly registerUrl = this.basicUrl + "/UserProfile/RegisterCompany";
    static readonly changePasswordUrl = this.basicUrl + "/UserProfile/ChangePassword";
    static readonly registerUserUrl = this.basicUrl + "/UserProfile/RegisterUser";
    static readonly registerSysAdminUrl = this.basicUrl + "/UserProfile/RegisterSystemAdmin";

    //SYSTEM-ADMIN URLS
    static readonly getCompanies = this.basicUrl+"/SystemAdmin/GetCompanies";
    static readonly getUsers = this.basicUrl+"/SystemAdmin/GetUsers";
    static readonly getParkingHouses = this.basicUrl+"/SystemAdmin/GetParkingHouses";
    static readonly getReservations = this.basicUrl+"/SystemAdmin/GetReservations";
    static readonly updateCompany = this.basicUrl+"/SystemAdmin/UpdateCompanies";
    static readonly deleteCompany = this.basicUrl+"/SystemAdmin/DeleteCompany";

    //COMPANY-ADMIN URLS
    static readonly getUsersByCompany= this.basicUrl+"/CompanyAdmin/GetUsers";
    static readonly updateUsers = this.basicUrl+"/CompanyAdmin/UpdateUsers";
    static readonly deleteUser = this.basicUrl+"/CompanyAdmin/DeleteUser";
    static readonly getParkingHousesByCompany = this.basicUrl+"/CompanyAdmin/GetParkingHouses";
    static readonly getReservationsByUsers = this.basicUrl+"/CompanyAdmin/GetReservations";
    static readonly addParkingHouse = this.basicUrl+"/CompanyAdmin/AddParkingHouse";
    static readonly updateParkingHouses = this.basicUrl+"/CompanyAdmin/UpdateParkingHouses";
    static readonly deleteParkingHouse = this.basicUrl+"/CompanyAdmin/DeleteParkingHouse";
    static readonly getLevelsByParkingHouseId = this.basicUrl+"/CompanyAdmin/GetLevels";
    static readonly updateLevels = this.basicUrl+"/CompanyAdmin/UpdateLevels";
    static readonly addLevel = this.basicUrl+"/CompanyAdmin/AddLevel";
    static readonly deleteLevel = this.basicUrl+"/CompanyAdmin/DeleteLevel";
    static readonly addSlots = this.basicUrl+"/CompanyAdmin/AddSlots";
    static readonly addSlot = this.basicUrl+"/CompanyAdmin/AddSlot";
    static readonly getSlotsByLevelId = this.basicUrl+"/CompanyAdmin/GetSlots";
    static readonly updateSlots = this.basicUrl+"/CompanyAdmin/UpdateSlots";
    static readonly deleteSlots = this.basicUrl+"/CompanyAdmin/DeleteSlots";

    //USER URLS
    static readonly getReservationsByUserId = this.basicUrl+"/DefaultUser/GetReservations";
    static readonly deleteReservation = this.basicUrl+"/DefaultUser/DeleteReservation";
    static readonly IsSlotFree = this.basicUrl+"/DefaultUser/IsSlotFree";
    static readonly addReservation = this.basicUrl+"/DefaultUser/AddReservation";
    static readonly isUserHasReservation = this.basicUrl+"/DefaultUser/IsUserHasReservation";
}