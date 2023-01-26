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
                //.ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PaientId));
            //CreateMap<Appointment, AppointmentViewModel>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            //    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            //    .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
            //    .ForMember(dest => dest.Paient, opt => opt.MapFrom(src => src.PaientId));


            //CreateMap<AppointmentViewModel, Appointment>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            //    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            //    .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            //    .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
            //    .ForMember(dest => dest.PaientId, opt => opt.MapFrom(src => src.Paient));

        }
    }
}
