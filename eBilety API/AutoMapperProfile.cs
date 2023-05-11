﻿using AutoMapper;
using eBilety.Models;

namespace eBilety.Controllers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ActorDto, Actor>();
		}
	}
}