using AGSRProject.Common.Models.BLL;
using AGSRProject.Common.Models.Dto;
using AGSRProject.Common.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.Common.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile() {
            this.CreateMap<PatientDto, Patient>()
                .ReverseMap();

            this.CreateMap<PatientBLL, PatientDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(z => z.Name.Id))
                .ForMember(x => x.Use, opt => opt.MapFrom(z => z.Name.Use))
                .ForMember(x => x.Family, opt => opt.MapFrom(z => z.Name.Family))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(z => z.Name.Given[0]))
                .ForMember(x => x.Patronymic, opt => opt.MapFrom(z => z.Name.Given[1]))
                .ForMember(x => x.Gender, opt => opt.MapFrom(z => z.Gender))
                .ForMember(x => x.BirthDate, opt => opt.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Active, opt => opt.MapFrom(z => z.Active));

            this.CreateMap<PatientDto, PatientBLL>()
                .ForMember(x => x.Name, opt => opt.MapFrom(i => new NameBLL { Id = i.Id, Family = i.Family, Use = i.Use, Given = new string[] {i.FirstName, i.Patronymic } }))
                .ForMember(x => x.Gender, opt => opt.MapFrom(z => z.Gender))
                .ForMember(x => x.BirthDate, opt => opt.MapFrom(z => z.BirthDate))
                .ForMember(x => x.Active, opt => opt.MapFrom(z => z.Active));
        }
    }
}
