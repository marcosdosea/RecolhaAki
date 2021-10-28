﻿using AutoMapper;
using Core;
using RecolhakiWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecolhakiWeb.Mappers
{
    public class ManterColetorProfile : Profile
    {
        public ManterColetorProfile()
        {
            CreateMap<ManterColetorViewModel, Pessoa>().ReverseMap();
        }
    }
}
