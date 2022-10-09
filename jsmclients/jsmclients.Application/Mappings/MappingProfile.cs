using AutoMapper;
using jsmclients.Application.Models.Responses;
using jsmclients.Application.Models.Requests;
using jsmclients.Core.Entities;
using System.Collections.Generic;

namespace jsmclients.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ElegibleListRequest, Client>()
                .ForMember(dest => dest.Type, fonte => fonte.MapFrom(src => src.Type))
                .ForPath(dest => dest.Location.Region, fonte => fonte.MapFrom(src => src.Region));

            CreateMap<Client, ClientResponse>()
                .ForMember(dest => dest.Type, fonte => fonte.MapFrom(src => src.GetType(src.Location.Longitude, src.Location.Latitude)))
                .ForMember(dest => dest.Gender, fonte => fonte.MapFrom(src => src.Gender))
                .ForPath(dest => dest.Name.Title, fonte => fonte.MapFrom(src => src.TitleName))
                .ForPath(dest => dest.Name.First, fonte => fonte.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.Name.Last, fonte => fonte.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, fonte => fonte.MapFrom(src => src.Email))
                .ForMember(dest => dest.Birthday, fonte => fonte.MapFrom(src => src.DobDate))
                .ForMember(dest => dest.Registered, fonte => fonte.MapFrom(src => src.RegisteredDate))
                .ForMember(dest => dest.TelephoneNumbers, fonte => fonte.MapFrom(src => new List<string>() { src.Phone }))
                .ForMember(dest => dest.MobileNumbers, fonte => fonte.MapFrom(src => new List<string>() { src.Cel }))
                .ForMember(dest => dest.Nationality, fonte => fonte.MapFrom(src => src.Nationality));

            CreateMap<Location, LocationResponse>()
                .ForMember(dest => dest.Region, fonte => fonte.MapFrom(src => src.Client.GetRegion(src.State)))
                .ForMember(dest => dest.Street, fonte => fonte.MapFrom(src => src.Street))
                .ForMember(dest => dest.City, fonte => fonte.MapFrom(src => src.City))
                .ForMember(dest => dest.State, fonte => fonte.MapFrom(src => src.State))
                .ForMember(dest => dest.Postcode, fonte => fonte.MapFrom(src => src.Postcode))
                .ForPath(dest => dest.Coordinates.Latitude, fonte => fonte.MapFrom(src => src.Latitude))
                .ForPath(dest => dest.Coordinates.Longitude, fonte => fonte.MapFrom(src => src.Longitude))
                .ForPath(dest => dest.Timezone.Offset, fonte => fonte.MapFrom(src => src.TimezoneOffset))
                .ForPath(dest => dest.Timezone.Description, fonte => fonte.MapFrom(src => src.TimezoneDescription));

            CreateMap<Pictures, PicturesResponse>()
                .ForMember(dest => dest.Large, fonte => fonte.MapFrom(src => src.Large))
                .ForMember(dest => dest.Medium, fonte => fonte.MapFrom(src => src.Medium))
                .ForMember(dest => dest.Thumbnail, fonte => fonte.MapFrom(src => src.Thumbnail));
        }
    }
}
