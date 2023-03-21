using CarParkSystem.Interfaces;
using Moq;
using CarParkSystem.Controllers;
using CarParkSystem.Persistence.DTO;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CarParkSystem.Tests
{
    public class SystemAdminControllerTests
    {
        private readonly Mock<ICompanyService> companyService;
        private readonly Mock<IUserService> userService;
        private readonly Mock<IParkingHouseService> parkingHouseService;
        private readonly Mock<ILevelService> levelService;
        private readonly Mock<ISlotService> slotService;
        private readonly Mock<IReservationService> reservationService;

        public SystemAdminControllerTests()
        {
            companyService = new Mock<ICompanyService>();
            userService = new Mock<IUserService>();
            parkingHouseService = new Mock<IParkingHouseService>();
            levelService = new Mock<ILevelService>();
            slotService = new Mock<ISlotService>();
            reservationService = new Mock<IReservationService>();
        }
        [Fact]
        public void UpdateCompaniesSuccessful()
        {
            companyService.Setup(x => x.UpdateCompany(It.IsAny<CompanyDTO>()));
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var company = new CompanyDTO
            {
                Id = 1,
                Name = "Teszt",
                IsValid = 0,
            };
            var updateResult = sysAdminController.UpdateCompanies(company);

            Assert.NotNull(updateResult);
            Assert.IsType<OkResult>(updateResult);
        }
        [Fact]
        public void UpdateCompaniesFailed()
        {
            companyService.Setup(x => x.UpdateCompany(It.IsAny<CompanyDTO>())).Throws<Exception>();
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var company = new CompanyDTO
            {
                Id = 1,
                Name = "Teszt",
                IsValid = 0,
            };

            Assert.Throws<Exception>(() => sysAdminController.UpdateCompanies(company));
        }
        [Fact]
        public void DeleteCompanySuccessFul()
        {
            companyService.Setup(x => x.DeleteCompany(It.IsAny<int>()));
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var deleteResult = sysAdminController.DeleteCompany(1);

            Assert.NotNull(deleteResult);
            Assert.IsType<OkResult>(deleteResult);
        }
        [Fact]
        public void DeleteCompanyFailed()
        {
            companyService.Setup(x => x.DeleteCompany(It.IsAny<int>())).Throws<Exception>();
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => sysAdminController.DeleteCompany(1));
        }
        [Fact]
        public void GetCompaniesSuccessful()
        {
            companyService.Setup(x => x.GetAllCompany()).Returns(new List<CompanyDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetCompanies();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
        }
        [Fact]
        public void GetCompaniesFailed()
        {
            companyService.Setup(x => x.GetAllCompany()).Throws<Exception>();
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => sysAdminController.GetCompanies());
        }
        [Fact]
        public void GetCompaniesSuccessfulCheckedDatas()
        {
            companyService.Setup(x => x.GetAllCompany()).Returns(new List<CompanyDTO> {
                new CompanyDTO {
                    Id = 1,
                    Name = "Teszt",
                    IsValid = 0,
                }
            });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetCompanies();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<CompanyDTO>>(result.Value);
            var resultValue = result.Value as List<CompanyDTO>;
            Assert.NotNull(resultValue);
            Assert.Single(resultValue);
            Assert.Equal(1, resultValue[0].Id);
            Assert.Equal("Teszt", resultValue[0].Name);
            Assert.Equal(0, resultValue[0].IsValid);
        }
        [Fact]
        public void GetCompaniesSuccessfulContainsMoreThanOneElement()
        {
            companyService.Setup(x => x.GetAllCompany()).Returns(new List<CompanyDTO> {
                new CompanyDTO {
                    Id = 1,
                    Name = "Teszt",
                    IsValid = 0,
                },
                new CompanyDTO {
                    Id = 2,
                    Name = "Teszt2",
                    IsValid = 1,
                }
            });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetCompanies();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<CompanyDTO>>(result.Value);
            var resultValue = result.Value as List<CompanyDTO>;
            Assert.NotNull(resultValue);
            Assert.Equal(2, resultValue.Count);
            Assert.Equal(1, resultValue[0].Id);
            Assert.Equal("Teszt", resultValue[0].Name);
            Assert.Equal(0, resultValue[0].IsValid);
            Assert.Equal(2, resultValue[1].Id);
            Assert.Equal("Teszt2", resultValue[1].Name);
            Assert.Equal(1, resultValue[1].IsValid);
        }
        [Fact]
        public void GetCompaniesSuccessfulEmptyList()
        {
            companyService.Setup(x => x.GetAllCompany()).Returns(new List<CompanyDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetCompanies();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<CompanyDTO>>(result.Value);
            var resultValue = result.Value as List<CompanyDTO>;
            Assert.NotNull(resultValue);
            Assert.Empty(resultValue);
        }
        [Fact]
        public void GetParkingHousesSuccessful()
        {
            parkingHouseService.Setup(x => x.GetAllParkingHouses()).Returns(new List<ParkingHouseDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetParkingHouses();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
        }
        [Fact]
        public void GetParkingHousesFailed()
        {
            parkingHouseService.Setup(x => x.GetAllParkingHouses()).Throws<Exception>();
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => sysAdminController.GetParkingHouses());
        }
        [Fact]
        public void GetParkingHousesSuccessfulCheckedDatas()
        {
            parkingHouseService.Setup(x => x.GetAllParkingHouses()).Returns(new List<ParkingHouseDTO> {
                new ParkingHouseDTO {
                    Id = 1,
                    Name = "Teszt",
                    CompanyId = 1,
                    IsActive = 0,
                    Level = 5,
                    Slots = 50,
                }
            });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetParkingHouses();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<ParkingHouseDTO>>(result.Value);
            var resultValue = result.Value as List<ParkingHouseDTO>;
            Assert.NotNull(resultValue);
            Assert.Single(resultValue);
            Assert.Equal(1, resultValue[0].Id);
            Assert.Equal("Teszt", resultValue[0].Name);
            Assert.Equal(1, resultValue[0].CompanyId);
            Assert.Equal(0, resultValue[0].IsActive);
            Assert.Equal(5, resultValue[0].Level);
            Assert.Equal(50, resultValue[0].Slots);
        }
        [Fact]
        public void GetParkingHousesSuccessfulContainsMoreThanOneElement()
        {
            parkingHouseService.Setup(x => x.GetAllParkingHouses()).Returns(new List<ParkingHouseDTO> {
                new ParkingHouseDTO {
                    Id = 1,
                    Name = "Teszt",
                    CompanyId = 1,
                    IsActive = 0,
                    Level = 5,
                    Slots = 50,
                },
                new ParkingHouseDTO {
                    Id = 2,
                    Name = "Teszt2",
                    CompanyId = 2,
                    IsActive = 1,
                    Level = 10,
                    Slots = 100,
                }
            });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetParkingHouses();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<ParkingHouseDTO>>(result.Value);
            var resultValue = result.Value as List<ParkingHouseDTO>;
            Assert.NotNull(resultValue);
            Assert.Equal(2, resultValue.Count);
            Assert.Equal(1, resultValue[0].Id);
            Assert.Equal("Teszt", resultValue[0].Name);
            Assert.Equal(1, resultValue[0].CompanyId);
            Assert.Equal(0, resultValue[0].IsActive);
            Assert.Equal(5, resultValue[0].Level);
            Assert.Equal(50, resultValue[0].Slots);
            Assert.Equal(2, resultValue[1].Id);
            Assert.Equal("Teszt2", resultValue[1].Name);
            Assert.Equal(2, resultValue[1].CompanyId);
            Assert.Equal(1, resultValue[1].IsActive);
            Assert.Equal(10, resultValue[1].Level);
            Assert.Equal(100, resultValue[1].Slots);
        }
        [Fact]
        public void GetParkingHousesSuccessfulEmptyList()
        {
            parkingHouseService.Setup(x => x.GetAllParkingHouses()).Returns(new List<ParkingHouseDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetParkingHouses();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<ParkingHouseDTO>>(result.Value);
            var resultValue = result.Value as List<ParkingHouseDTO>;
            Assert.NotNull(resultValue);
            Assert.Empty(resultValue);
        }
        [Fact]
        public void GetReservationsSuccessful()
        {
            reservationService.Setup(x => x.GetAllReservations()).Returns(new List<ReservationDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetReservations();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
        }
        [Fact]
        public void GetReservationsFailed()
        {
            reservationService.Setup(x => x.GetAllReservations()).Throws<Exception>();
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => sysAdminController.GetReservations());
        }
        [Fact]
        public void GetReservationsSuccessfulCheckedDatas()
        {
            reservationService.Setup(x => x.GetAllReservations()).Returns(new List<ReservationDTO> {
                new ReservationDTO {
                    Id = 1,
                    UserId = "safjsfb123",
                    ParkingHouseId = 1,
                    SlotId = 1,
                    Date = "2023-02-26",
                    LevelId = 1,
                    ParkingHouseName = "Teszt",
                    SlotNumber = 5,
                    LevelNumber = 1,
                }
            });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetReservations();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<ReservationDTO>>(result.Value);
            var resultValue = result.Value as List<ReservationDTO>;
            Assert.NotNull(resultValue);
            Assert.Single(resultValue);
            Assert.Equal(1, resultValue[0].Id);
            Assert.Equal("safjsfb123", resultValue[0].UserId);
            Assert.Equal(1, resultValue[0].ParkingHouseId);
            Assert.Equal(1, resultValue[0].SlotId);
            Assert.Equal("2023-02-26", resultValue[0].Date);
            Assert.Equal(1, resultValue[0].LevelId);
            Assert.Equal("Teszt", resultValue[0].ParkingHouseName);
            Assert.Equal(5, resultValue[0].SlotNumber);
            Assert.Equal(1, resultValue[0].LevelNumber);
        }
        [Fact]
        public void GetReservationsSuccessfulContainsMoreThanOneElement()
        {
            reservationService.Setup(x => x.GetAllReservations()).Returns(new List<ReservationDTO> {
                new ReservationDTO {
                    Id = 1,
                    UserId = "safjsfb123",
                    ParkingHouseId = 1,
                    SlotId = 1,
                    Date = "2023-02-26",
                    LevelId = 1,
                    ParkingHouseName = "Teszt",
                    SlotNumber = 5,
                    LevelNumber = 1,
                },
                new ReservationDTO {
                    Id = 2,
                    UserId = "safjsfb123gf5",
                    ParkingHouseId = 1,
                    SlotId = 1,
                    Date = "2023-02-27",
                    LevelId = 2,
                    ParkingHouseName = "Teszt",
                    SlotNumber = 1,
                    LevelNumber = 2,
                }
            });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetReservations();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<ReservationDTO>>(result.Value);
            var resultValue = result.Value as List<ReservationDTO>;
            Assert.NotNull(resultValue);
            Assert.Equal(2, resultValue.Count);
            Assert.Equal(1, resultValue[0].Id);
            Assert.Equal("safjsfb123", resultValue[0].UserId);
            Assert.Equal(1, resultValue[0].ParkingHouseId);
            Assert.Equal(1, resultValue[0].SlotId);
            Assert.Equal("2023-02-26", resultValue[0].Date);
            Assert.Equal(1, resultValue[0].LevelId);
            Assert.Equal("Teszt", resultValue[0].ParkingHouseName);
            Assert.Equal(5, resultValue[0].SlotNumber);
            Assert.Equal(1, resultValue[0].LevelNumber);
            Assert.Equal(2, resultValue[1].Id);
            Assert.Equal("safjsfb123gf5", resultValue[1].UserId);
            Assert.Equal(1, resultValue[1].ParkingHouseId);
            Assert.Equal(1, resultValue[1].SlotId);
            Assert.Equal("2023-02-27", resultValue[1].Date);
        }
    
        [Fact]
        public void GetReservationsSuccessfulEmptyList()
        {
            reservationService.Setup(x => x.GetAllReservations()).Returns(new List<ReservationDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetReservations();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<ReservationDTO>>(result.Value);
            var resultValue = result.Value as List<ReservationDTO>;
            Assert.NotNull(resultValue);
            Assert.Empty(resultValue);
        }
        [Fact]
        public void GetUsersSuccessful()
        {
            userService.Setup(x => x.GetAllUsers()).Returns(new List<UserDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetUsers();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
        }
        [Fact]
        public void GetUsersFailed()
        {
            userService.Setup(x => x.GetAllUsers()).Throws<Exception>();
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => sysAdminController.GetUsers());
        }
        [Fact]
        public void GetUsersSuccessfulCheckedDatas()
        {
            userService.Setup(x => x.GetAllUsers()).Returns(new List<UserDTO> {
                new UserDTO {
                    Id = "safjsfb123",
                    CompanyId = 1,
                    FullName = "Teszt",
                    isValid = 0,
                    Role = "CompanyAdmin", },
                });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetUsers();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<UserDTO>>(result.Value);
            var resultValue = result.Value as List<UserDTO>;
            Assert.NotNull(resultValue);
            Assert.Single(resultValue);
            Assert.Equal("safjsfb123", resultValue[0].Id);
            Assert.Equal(1, resultValue[0].CompanyId);
            Assert.Equal("Teszt", resultValue[0].FullName);
            Assert.Equal(0, resultValue[0].isValid);
            Assert.Equal("CompanyAdmin", resultValue[0].Role);
        }
        [Fact]
        public void GetUsersSuccessfulContainsMoreThanOneElement()
        {
            userService.Setup(x => x.GetAllUsers()).Returns(new List<UserDTO> {
                new UserDTO {
                    Id = "safjsfb123",
                    CompanyId = 1,
                    FullName = "Teszt",
                    isValid = 0,
                    Role = "CompanyAdmin", },
                new UserDTO {
                    Id = "safjsfb123",
                    CompanyId = 1,
                    FullName = "Teszt",
                    isValid = 0,
                    Role = "CompanyAdmin", },
                });
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetUsers();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<UserDTO>>(result.Value);
            var resultValue = result.Value as List<UserDTO>;
            Assert.NotNull(resultValue);
            Assert.Equal(2, resultValue.Count);
        }
        [Fact]
        public void GetUsersSuccessfulEmptyList()
        {
            userService.Setup(x => x.GetAllUsers()).Returns(new List<UserDTO>());
            var sysAdminController = new SystemAdminController(companyService.Object, userService.Object, parkingHouseService.Object, reservationService.Object);
            var getResult = sysAdminController.GetUsers();

            Assert.NotNull(getResult);
            Assert.IsType<OkObjectResult>(getResult.Result);
            var result = getResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.IsType<List<UserDTO>>(result.Value);
            var resultValue = result.Value as List<UserDTO>;
            Assert.NotNull(resultValue);
            Assert.Empty(resultValue);
        }
    }
}