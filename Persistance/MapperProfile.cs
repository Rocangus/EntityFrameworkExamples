using AutoMapper;
using EntityFrameworkExamples.Core.Models;
using EntityFrameworkExamples.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExamples.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentListViewModel>();
            CreateMap<Student, StudentDTO>();
            CreateMap<Student, StudentAddViewModel>().ReverseMap();

            CreateMap<Student, StudentDetailsViewModel>().ForMember(
                dest=>dest.Attending,
                from=>from.MapFrom(s=>s.Enrollments.Count))
                .ForMember(
                dest => dest.Courses,
                from => from.MapFrom(s=>s.Enrollments.Select(e=>
                e.Course).ToList()));

            CreateMap<StudentAddViewModel, Student>()
                .ForMember(
                            dest => dest.Enrollments, opt => opt.Ignore())
                .ForPath(
                        dest => dest.Address,
                        from => from.MapFrom(model => new Address
                        {
                            City = model.AddressCity,
                            Street = model.AddressStreet,
                            ZipCode = model.AddressZipCode
                        }));
                
            
        }
    }
}
