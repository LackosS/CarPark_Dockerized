using CarParkSystem.Interfaces;
using Moq;
using CarParkSystem.Controllers;
using CarParkSystem.Persistence.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CarParkSystem.Tests
{
    public class DefaultUserControllerTests
    {
        private readonly Mock<ICompanyService> companyService;
        private readonly Mock<IUserService> userService;
        private readonly Mock<IParkingHouseService> parkingHouseService;
        private readonly Mock<ILevelService> levelService;
        private readonly Mock<ISlotService> slotService;
        private readonly Mock<IReservationService> reservationService;

        public DefaultUserControllerTests()
        {
            companyService = new Mock<ICompanyService>();
            userService = new Mock<IUserService>();
            parkingHouseService = new Mock<IParkingHouseService>();
            levelService = new Mock<ILevelService>();
            slotService = new Mock<ISlotService>();
            reservationService = new Mock<IReservationService>();
        }
        [Fact]
        public void AddReservationSuccessful()
        {
            var controller = new DefaultUserController( parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object,slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date="2023-02-27",
                LevelId=1,
                SlotId=1,
                SlotNumber=1,
                ParkingHouseId=1,
                LevelNumber=1,
                ParkingHouseName="Teszt"
            };
            reservationService.Setup(x => x.AddReservation(reservation));
            var result = controller.AddReservation(reservation);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void AddReservationSuccessfulCheckDatas()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            reservationService.Setup(x => x.AddReservation(reservation)).Returns(1);
            var result = controller.AddReservation(reservation);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(1, okResult.Value);
        }
        [Fact]
        public void AddReservationFailed()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            reservationService.Setup(x => x.AddReservation(reservation)).Throws<Exception>();
            Assert.Throws<Exception>(() => controller.AddReservation(reservation));
        }
        [Fact]
        public void AddReservationFailedCheckedDatas()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            reservationService.Setup(x => x.AddReservation(reservation)).Returns(-1);
            var result = controller.AddReservation(reservation);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(-1, okResult.Value);
        }
        [Fact]
        public void DeleteReservationSuccessful()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            reservationService.Setup(x => x.DeleteReservation(It.IsAny<int>()));
            var result = controller.DeleteReservation(reservation.Id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void DeleteReservationFailed()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            reservationService.Setup(x => x.DeleteReservation(It.IsAny<int>())).Throws<Exception>();
            Assert.Throws<Exception>(() => controller.DeleteReservation(reservation.Id));
        }
        [Fact]
        public void GetReservationsSuccessful()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            var reservations = new List<ReservationDTO>();
            reservations.Add(reservation);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Returns(reservations);
            var result = controller.GetReservations(reservation.UserId);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetReservationsSuccessfulCheckDatas()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            var reservations = new List<ReservationDTO>();
            reservations.Add(reservation);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Returns(reservations);
            var result = controller.GetReservations(reservation.UserId);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(reservations, okResult.Value);
        }
        [Fact]
        public void GetReservationsSuccessfulContainsMoreThanOneElement()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            var reservation2 = new ReservationDTO()
            {
                Id = 2,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            var reservations = new List<ReservationDTO>();
            reservations.Add(reservation);
            reservations.Add(reservation2);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Returns(reservations);
            var result = controller.GetReservations(reservation.UserId);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetReservationsFailed()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            var reservation = new ReservationDTO()
            {
                Id = 1,
                UserId = "asd123",
                Date = "2023-02-27",
                LevelId = 1,
                SlotId = 1,
                SlotNumber = 1,
                ParkingHouseId = 1,
                LevelNumber = 1,
                ParkingHouseName = "Teszt"
            };
            var reservations = new List<ReservationDTO>();
            reservations.Add(reservation);
            reservationService.Setup(x => x.GetAllReservations(It.IsAny<string>())).Throws<Exception>();
            Assert.Throws<Exception>(() => controller.GetReservations(reservation.UserId));
        }
        [Fact]
        public void IsUserHasReservationSuccesful()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            reservationService.Setup(x => x.IsUserHasReservation(It.IsAny<string>(),It.IsAny<string>())).Returns(true);
            var result = controller.IsUserHasReservation("asd123","2023-02-27");
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void IsUserHasReservationSuccesfulTrue()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            reservationService.Setup(x => x.IsUserHasReservation(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var result = controller.IsUserHasReservation("asd123", "2023-02-27");
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(true, okResult.Value);
        }
        [Fact]
        public void IsUserHasReservationSuccesfulFalse()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            reservationService.Setup(x => x.IsUserHasReservation(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            var result = controller.IsUserHasReservation("asd123", "2023-02-27");
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(false, okResult.Value);
        }
        [Fact]
        public void IsUserHasReservationSuccesfulFailed()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            reservationService.Setup(x => x.IsUserHasReservation(It.IsAny<string>(), It.IsAny<string>())).Throws<Exception>();
            Assert.Throws<Exception>(()=>controller.IsUserHasReservation("asd123", "2023-02-27"));
        }
        [Fact]
        public void IsSlotFreeSuccessful()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            slotService.Setup(x => x.IsSlotFree(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var result = controller.IsSlotFree(1, "2023-02-27");
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void IsSlotFreeSuccessfulTrue()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            slotService.Setup(x => x.IsSlotFree(It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            var result = controller.IsSlotFree(1, "2023-02-27");
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(true, okResult.Value);
        }
        [Fact]
        public void IsSlotFreeSuccessfulFalse()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            slotService.Setup(x => x.IsSlotFree(It.IsAny<int>(), It.IsAny<string>())).Returns(false);
            var result = controller.IsSlotFree(1, "2023-02-27");
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(false, okResult.Value);
        }
        [Fact]
        public void IsSlotFreeSuccessfulFailed()
        {
            var controller = new DefaultUserController(parkingHouseService.Object, userService.Object, reservationService.Object, companyService.Object, slotService.Object);
            slotService.Setup(x => x.IsSlotFree(It.IsAny<int>(), It.IsAny<string>())).Throws<Exception>();
            Assert.Throws<Exception>(() => controller.IsSlotFree(1, "2023-02-27"));
        }
    }
     
}