using AutoMapper;
using CarParkSystem.Interfaces;
using CarParkSystem.Persistence.DTO;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Records;

namespace CarParkSystem.Services
{
    public class ReservationService :IReservationService
    {
        private IReservationRepository _repository;
        private ICustomMapper _mapper;

        public ReservationService(IReservationRepository repository, ICustomMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public int AddReservation(ReservationDTO r)
        {
            var reservation = _mapper.MapReservationDTOToReservation(r);
            return _repository.AddReservation(reservation);
        }
        public void DeleteReservation(int id)
        {
            _repository.DeleteReservation(id);
        }
        public List<ReservationDTO> GetAllReservations()
        {
            var reservations = _repository.GetAllReservations();
            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
            foreach(Reservation reservation in reservations)
            {
                reservationDTOs.Add(_mapper.MapReservationToReservationDTO(reservation));
            }
            return reservationDTOs;
        }
        public List<ReservationDTO> GetAllReservations(int parkingHouseId)
        {
            var reservations = _repository.GetAllReservations().Where(x => x.ParkingHouseId == parkingHouseId).ToList();
            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
            foreach (Reservation reservation in reservations)
            {
                reservationDTOs.Add(_mapper.MapReservationToReservationDTO(reservation));
            }
            return reservationDTOs;
        }
        public bool IsUserHasReservation(string userId, string date)
        {
            return _repository.IsUserHasReservation(userId, date);
        }
        public List<ReservationDTO> GetAllReservations(string userId)
        {
            var reservations = _repository.GetAllReservations().Where(x => x.UserId == userId).ToList();
            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
            foreach (Reservation reservation in reservations)
            {
                reservationDTOs.Add(_mapper.MapReservationToReservationDTO(reservation));
            }
            return reservationDTOs;
        }
    }
}
