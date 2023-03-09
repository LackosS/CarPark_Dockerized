using CarParkSystem.Interfaces;
using Moq;
using CarParkSystem.Controllers;
using CarParkSystem.Persistence.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CarParkSystem.Tests
{
    public class CompanyAdminControllerTests
    {
        private readonly Mock<ICompanyService> companyService;
        private readonly Mock<IUserService> userService;
        private readonly Mock<IParkingHouseService> parkingHouseService;
        private readonly Mock<ILevelService> levelService;
        private readonly Mock<ISlotService> slotService;
        private readonly Mock<IReservationService> reservationService;

        public CompanyAdminControllerTests()
        {
            companyService = new Mock<ICompanyService>();
            userService = new Mock<IUserService>();
            parkingHouseService = new Mock<IParkingHouseService>();
            levelService = new Mock<ILevelService>();
            slotService = new Mock<ISlotService>();
            reservationService = new Mock<IReservationService>();
        }
        #region AddTests
        [Fact]
        public void AddParkinghouseSuccessful()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.AddParkingHouse(It.IsAny<ParkingHouseDTO>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddParkingHouse(parkinghouse);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void AddParkinghouseSuccessfulCheckDatas()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.AddParkingHouse(It.IsAny<ParkingHouseDTO>())).Returns(1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddParkingHouse(parkinghouse);
            var okResult = result as OkObjectResult;
            Assert.Equal(parkinghouse.Id, okResult.Value);
        }
        [Fact]
        public void AddParkinghouseFailed()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.AddParkingHouse(It.IsAny<ParkingHouseDTO>())).Returns(-1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddParkingHouse(parkinghouse);
            var okResult = result as OkObjectResult;
            Assert.Equal(-1, okResult.Value);
        }
        [Fact]
        public void AddLevelSuccessful()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.AddLevel(It.IsAny<LevelDTO>())).Returns(1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddLevel(level);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void AddLevelSuccessfulCheckDatas()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.AddLevel(It.IsAny<LevelDTO>())).Returns(1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddLevel(level);
            var okResult = result as OkObjectResult;
            Assert.Equal(level.Id, okResult.Value);
        }
        [Fact]
        public void AddLevelFailed()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.AddLevel(It.IsAny<LevelDTO>())).Returns(-1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddLevel(level);
            var okResult = result as OkObjectResult;
            Assert.Equal(-1, okResult.Value);
        }
        [Fact]
        public void AddSlotSuccessful()
        {
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slotService.Setup(x => x.AddSlot(It.IsAny<SlotDTO>())).Returns(1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddSlot(slot);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void AddSlotSuccessfulCheckDatas()
        {
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slotService.Setup(x => x.AddSlot(It.IsAny<SlotDTO>())).Returns(1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddSlot(slot);
            var okResult = result as OkObjectResult;
            Assert.Equal(slot.Id, okResult.Value);
        }
        [Fact]
        public void AddSlotFailed()
        {
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slotService.Setup(x => x.AddSlot(It.IsAny<SlotDTO>())).Returns(-1);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.AddSlot(slot);
            var okResult = result as OkObjectResult;
            Assert.Equal(-1, okResult.Value);
        }
        #endregion
        #region UpdateTests

        [Fact]
        public void UpdateUserSuccesful()
        {
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            userService.Setup(x => x.UpdateUser(It.IsAny<UserDTO>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.UpdateUsers(user);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void UpdateUserFailed()
        {
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            userService.Setup(x => x.UpdateUser(It.IsAny<UserDTO>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.UpdateUsers(user));
        }
        [Fact]
        public void UpdateParkinghouseSuccessful()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.UpdateParkingHouse(It.IsAny<ParkingHouseDTO>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.UpdateParkingHouses(parkinghouse);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void UpdateParkinghouseFailed()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.UpdateParkingHouse(It.IsAny<ParkingHouseDTO>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.UpdateParkingHouses(parkinghouse));
        }
        [Fact]
        public void UpdateLevelSuccessful()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.UpdateLevel(It.IsAny<LevelDTO>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.UpdateLevels(level);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void UpdateLevelFailed()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.UpdateLevel(It.IsAny<LevelDTO>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.UpdateLevels(level));
        }
        [Fact]
        public void UpdateSlotSuccessful()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slots.Add(slot);
            slotService.Setup(x => x.UpdateSlot(It.IsAny<SlotDTO>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.UpdateSlots(slots);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void UpdateSlotFailed()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slots.Add(slot);
            slotService.Setup(x => x.UpdateSlot(It.IsAny<SlotDTO>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.UpdateSlots(slots));
        }
        #endregion
        #region DeleteTests
        [Fact]
        public void DeleteUserSuccessful()
        {
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            userService.Setup(x => x.DeleteUser(It.IsAny<string>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.DeleteUser(user.Id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteUserFailed()
        {
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            userService.Setup(x => x.DeleteUser(It.IsAny<string>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.DeleteUser(user.Id));
        }
        [Fact]
        public void DeleteParkinghouseSuccessful()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.DeleteParkingHouse(It.IsAny<int>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.DeleteParkingHouse(parkinghouse.Id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteParkinghouseFailed()
        {
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 10,
                Slots = 100,
            };
            parkingHouseService.Setup(x => x.DeleteParkingHouse(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.DeleteParkingHouse(parkinghouse.Id));
        }
        [Fact]
        public void DeleteLevelSuccessful()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.DeleteLevel(It.IsAny<int>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.DeleteLevel(level.Id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteLevelFailed()
        {
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                IsActive = 0,
                ParkingHouseName = "Teszt",
                Slot = 10,
            };
            levelService.Setup(x => x.DeleteLevel(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.DeleteLevel(level.Id));
        }
        [Fact]
        public void DeleteSlotSuccessful()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slots.Add(slot);
            slotService.Setup(x => x.DeleteSlot(It.IsAny<int>()));
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.DeleteSlots(slots);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteSlotFailed()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                InitialNumber = 5,
                IsFree = true,
                Type = "Default"
            };
            slots.Add(slot);
            slotService.Setup(x => x.DeleteSlot(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.DeleteSlots(slots));
        }
        #endregion
        #region GetUsersTests
        [Fact]
        public void GetUsersSuccessful()
        {
            var users = new List<UserDTO>();
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            users.Add(user);
            userService.Setup(x => x.GetAllUsers(It.IsAny<int>())).Returns(users);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetUsers(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetUsersSuccessfulCheckDatas()
        {
            var users = new List<UserDTO>();
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            users.Add(user);
            userService.Setup(x => x.GetAllUsers(It.IsAny<int>())).Returns(users);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetUsers(1) as OkObjectResult;
            var value = result.Value as List<UserDTO>;
            Assert.NotNull(value);
            Assert.Equal(users, value);
            Assert.Equal(users.Count, value.Count);
        }
        [Fact]
        public void GetUsersSuccesfulContainsMoreThanOneElement()
        {
            var users = new List<UserDTO>();
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            var user2 = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            users.Add(user);
            users.Add(user2);
            userService.Setup(x => x.GetAllUsers(It.IsAny<int>())).Returns(users);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetUsers(1) as OkObjectResult;
            var value = result.Value as List<UserDTO>;
            Assert.NotNull(value);
            Assert.Equal(users, value);
            Assert.Equal(users.Count, value.Count);
        }
        [Fact]
        public void GetUsersFailed()
        {
            var users = new List<UserDTO>();
            var user = new UserDTO()
            {
                CompanyId = 1,
                FullName = "Teszt teszt",
                Id = "asdh123",
                isValid = 0,
                Role = "Boss"
            };
            users.Add(user);
            userService.Setup(x => x.GetAllUsers(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.GetUsers(1));
        }
        #endregion
        #region GetParkinghousesTests
        [Fact]
        public void GetParkinghousesSuccessful()
        {
            var parkinghouses = new List<ParkingHouseDTO>();
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 5,
                Slots = 50
            };
            parkinghouses.Add(parkinghouse);
            parkingHouseService.Setup(x => x.GetAllParkingHouses(It.IsAny<int>())).Returns(parkinghouses);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetParkingHouses(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetParkinghousesSuccessfulCheckDatas()
        {
            var parkinghouses = new List<ParkingHouseDTO>();
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 5,
                Slots = 50
            };
            parkinghouses.Add(parkinghouse);
            parkingHouseService.Setup(x => x.GetAllParkingHouses(It.IsAny<int>())).Returns(parkinghouses);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetParkingHouses(1) as OkObjectResult;
            var value = result.Value as List<ParkingHouseDTO>;
            Assert.NotNull(value);
            Assert.Equal(parkinghouses, value);
            Assert.Equal(parkinghouses.Count, value.Count);
        }
        [Fact]
        public void GetParkinghousesSuccesfulContainsMoreThanOneElement()
        {
            var parkinghouses = new List<ParkingHouseDTO>();
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 5,
                Slots = 50
            };
            var parkinghouse2 = new ParkingHouseDTO()
            {
                Id = 2,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 5,
                Slots = 50
            };
            parkinghouses.Add(parkinghouse);
            parkinghouses.Add(parkinghouse2);
            parkingHouseService.Setup(x => x.GetAllParkingHouses(It.IsAny<int>())).Returns(parkinghouses);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetParkingHouses(1) as OkObjectResult;
            var value = result.Value as List<ParkingHouseDTO>;
            Assert.NotNull(value);
            Assert.Equal(parkinghouses, value);
            Assert.Equal(parkinghouses.Count, value.Count);
        }
        [Fact]
        public void GetParkinghousesFailed()
        {
            var parkinghouses = new List<ParkingHouseDTO>();
            var parkinghouse = new ParkingHouseDTO()
            {
                Id = 1,
                CompanyId = 1,
                Name = "Teszt",
                IsActive = 0,
                Level = 5,
                Slots = 50
            };
            parkinghouses.Add(parkinghouse);
            parkingHouseService.Setup(x => x.GetAllParkingHouses(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.GetParkingHouses(1));
        }
        #endregion
        #region GetLevelsTests
        [Fact]
        public void GetLevelsSuccessful()
        {
            var levels = new List<LevelDTO>();
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                IsActive = 0,
                LevelNumber = 9,
                Slot = 20
            };
            levels.Add(level);
            levelService.Setup(x => x.GetAllLevels(It.IsAny<int>())).Returns(levels);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetLevels(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetLevelsSuccessfulCheckDatas()
        {
            var levels = new List<LevelDTO>();
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                IsActive = 0,
                LevelNumber = 9,
                Slot = 20
            };
            levels.Add(level);
            levelService.Setup(x => x.GetAllLevels(It.IsAny<int>())).Returns(levels);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetLevels(1) as OkObjectResult;
            var value = result.Value as List<LevelDTO>;
            Assert.NotNull(value);
            Assert.Equal(levels, value);
            Assert.Equal(levels.Count, value.Count);
        }
        [Fact]
        public void GetLevelsSuccesfulContainsMoreThanOneElement()
        {
            var levels = new List<LevelDTO>();
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                IsActive = 0,
                LevelNumber = 9,
                Slot = 20
            };
            var level2 = new LevelDTO()
            {
                Id = 2,
                ParkingHouseId = 1,
                IsActive = 0,
                LevelNumber = 9,
                Slot = 20
            };
            levels.Add(level);
            levels.Add(level2);
            levelService.Setup(x => x.GetAllLevels(It.IsAny<int>())).Returns(levels);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetLevels(1) as OkObjectResult;
            var value = result.Value as List<LevelDTO>;
            Assert.NotNull(value);
            Assert.Equal(levels, value);
            Assert.Equal(levels.Count, value.Count);
        }
        [Fact]
        public void GetLevelsFailed()
        {
            var levels = new List<LevelDTO>();
            var level = new LevelDTO()
            {
                Id = 1,
                ParkingHouseId = 1,
                IsActive = 0,
                LevelNumber = 9,
                Slot = 20
            };
            levels.Add(level);
            levelService.Setup(x => x.GetAllLevels(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.GetLevels(1));
        }
        #endregion
        #region GetSlotsTests
        [Fact]
        public void GetSlotsSuccessful()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber=1,
                IsFree=true,
                InitialNumber=1,
                Type="Default",
            };
            slots.Add(slot);
            slotService.Setup(x => x.GetAllSlots(It.IsAny<int>())).Returns(slots);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetSlots(1);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetSlotsSuccessfulCheckDatas()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                IsFree = true,
                InitialNumber = 1,
                Type = "Default",
            };
            slots.Add(slot);
            slotService.Setup(x => x.GetAllSlots(It.IsAny<int>())).Returns(slots);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetSlots(1) as OkObjectResult;
            var value = result.Value as List<SlotDTO>;
            Assert.NotNull(value);
            Assert.Equal(slots, value);
            Assert.Equal(slots.Count, value.Count);
        }
        [Fact]
        public void GetSlotsSuccesfulContainsMoreThanOneElement()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                IsFree = true,
                InitialNumber = 1,
                Type = "Default",
            };
            var slot2 = new SlotDTO()
            {
                Id = 2,
                LevelId = 1,
                SlotNumber = 1,
                IsFree = true,
                InitialNumber = 1,
                Type = "Default",
            };
            slots.Add(slot);
            slots.Add(slot2);
            slotService.Setup(x => x.GetAllSlots(It.IsAny<int>())).Returns(slots);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetSlots(1) as OkObjectResult;
            var value = result.Value as List<SlotDTO>;
            Assert.NotNull(value);
            Assert.Equal(slots, value);
            Assert.Equal(slots.Count, value.Count);
        }
        [Fact]
        public void GetSlotsFailed()
        {
            var slots = new List<SlotDTO>();
            var slot = new SlotDTO()
            {
                Id = 1,
                LevelId = 1,
                SlotNumber = 1,
                IsFree = true,
                InitialNumber = 1,
                Type = "Default",
            };
            slots.Add(slot);
            slotService.Setup(x => x.GetAllSlots(It.IsAny<int>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.GetSlots(1));
        }
        #endregion
        #region GetReservationsTests
        [Fact]
        public void GetReservationsSuccessful()
        {
            var reservations = new List<ReservationDTO>();
            var reservation = new ReservationDTO()
            {
                UserId = "asd123",
                Id = 1,
                Date = "2023-02-27",
                LevelId = 1,
                LevelNumber = 1,
                ParkingHouseId = 1,
                ParkingHouseName = "Teszt",
                SlotId = 1,
                SlotNumber = 1,

            };
            reservations.Add(reservation);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Returns(reservations);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetReservations("asd123");
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetReservationsSuccessfulCheckDatas()
        {
            var reservations = new List<ReservationDTO>();
            var reservation = new ReservationDTO()
            {
                UserId = "asd123",
                Id = 1,
                Date = "2023-02-27",
                LevelId = 1,
                LevelNumber = 1,
                ParkingHouseId = 1,
                ParkingHouseName = "Teszt",
                SlotId = 1,
                SlotNumber = 1,

            };
            reservations.Add(reservation);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Returns(reservations);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetReservations("asd123") as OkObjectResult;
            var value = result.Value as List<ReservationDTO>;
            Assert.NotNull(value);
            Assert.Equal(reservations, value);
            Assert.Equal(reservations.Count, value.Count);
        }
        [Fact]
        public void GetReservationsSuccesfulContainsMoreThanOneElement()
        {
            var reservations = new List<ReservationDTO>();
            var reservation = new ReservationDTO()
            {
                UserId = "asd123",
                Id = 1,
                Date = "2023-02-27",
                LevelId = 1,
                LevelNumber = 1,
                ParkingHouseId = 1,
                ParkingHouseName = "Teszt",
                SlotId = 1,
                SlotNumber = 1,

            };
            var reservation2 = new ReservationDTO()
            {
                UserId = "asd123",
                Id = 2,
                Date = "2023-02-26",
                LevelId = 1,
                LevelNumber = 1,
                ParkingHouseId = 1,
                ParkingHouseName = "Teszt",
                SlotId = 1,
                SlotNumber = 1,

            };
            reservations.Add(reservation);
            reservations.Add(reservation2);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Returns(reservations);
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            var result = controller.GetReservations("asd123") as OkObjectResult;
            var value = result.Value as List<ReservationDTO>;
            Assert.NotNull(value);
            Assert.Equal(reservations, value);
            Assert.Equal(reservations.Count, value.Count);
        }
        [Fact]
        public void GetReservationsFailed()
        {
            var reservations = new List<ReservationDTO>();
            var reservation = new ReservationDTO()
            {
                UserId = "asd123",
                Id = 1,
                Date = "2023-02-27",
                LevelId = 1,
                LevelNumber = 1,
                ParkingHouseId = 1,
                ParkingHouseName = "Teszt",
                SlotId = 1,
                SlotNumber = 1,

            };
            reservations.Add(reservation);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Throws<Exception>();
            var controller = new CompanyAdminController(parkingHouseService.Object, userService.Object, levelService.Object, slotService.Object, reservationService.Object);
            Assert.Throws<Exception>(() => controller.GetReservations("asd123"));
        }
        #endregion
    }
}