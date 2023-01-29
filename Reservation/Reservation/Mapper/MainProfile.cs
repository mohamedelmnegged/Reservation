using AutoMapper;
using Reservation.Data.Tables;
using Reservation.Models;
namespace Reservation.Mapper
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Appointment, AppointmentViewModel>()
                .ForMember(dest => dest.StatusColor, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.TypeColor, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.PaientId, opt => opt.MapFrom(src => src.PaientId));

            CreateMap<AddAppointmentViewModel, Appointment>()
                .ForMember(dest => dest.PaientId, opt => opt.MapFrom(src => src.PaientId));
            
            CreateMap<Appointment, AddAppointmentViewModel>()
                .ForMember(dest => dest.PaientId, opt => opt.MapFrom(src => src.PaientId));

            CreateMap<Paient, PaientViewModel>();
            CreateMap<AddPaientViewModel, Paient>();

            CreateMap<Paient, AddPaientViewModel>();

            CreateMap<RegisterViewModel, User>(); 
            CreateMap<User, RegisterViewModel>(); 



        }
    }
}
