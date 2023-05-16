using AutoMapper;
using eBilety.Data.ViewModels;
using eBilety.Models;

namespace eBilety.Controllers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<ActorDto, Actor>();
			CreateMap<CinemaDto, Cinema>();
			CreateMap<ProducerDto, Producer>();
			CreateMap<ShoppingCartItemVM, ShoppingCartItem>();
		}
	}
}