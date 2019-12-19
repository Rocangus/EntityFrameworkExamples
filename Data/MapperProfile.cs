﻿using AutoMapper;
using EntityFrameworkExamples.Models;
using EntityFrameworkExamples.Models.ViewModels;
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

            CreateMap<Student, StudentDetailsViewModel>().ForMember(
                dest=>dest.Attending,
                from=>from.MapFrom(s=>s.Enrollments.Count))
                .ForMember(
                dest => dest.Courses,
                from => from.MapFrom(s=>s.Enrollments.Select(e=>
                e.Course).ToList()));
        }
    }
}
