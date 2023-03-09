using AutoMapper;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.MappingConfigurations
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
        }
        public class UserProfile : Profile
        {
            public UserProfile()
            {
                CreateMap<User, UserDTO>();
                CreateMap<UserDTO, User>();
            }
        }

        public class ParkingHouseProfile : Profile
        {
            public ParkingHouseProfile()
            {
                CreateMap<ParkingHouse, ParkingHouseDTO>();
                CreateMap<ParkingHouseDTO, ParkingHouse>();
            }
        }

       /* public class LevelProfile : Profile
        {
            public LevelProfile()
            {
                CreateMap<Level, LevelDTO>();
                CreateMap<LevelDTO, Level>();
            }
        }*/

        public class SlotProfile : Profile
        {
            public SlotProfile()
            {
                CreateMap<Slot, SlotDTO>();
                CreateMap<SlotDTO, Slot>();
            }
        }
        /*public class ReservationProfile : Profile
        {
            public ReservationProfile()
            {
                CreateMap<Reservation, ReservationDTO>();
                CreateMap<ReservationDTO, Reservation>();
            }
        }*/
    }
}
