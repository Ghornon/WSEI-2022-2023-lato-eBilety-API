using eBilety.Data.Base;
using eBilety.Models;

namespace eBilety.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
