using PokemonReview.WebApi.Data;
using PokemonReview.WebApi.Interfaces;
using PokemonReview.WebApi.Models;

namespace PokemonReview.WebApi.Repositories
{
    public class OwnerRepository(DataContext context) : IOwnerRepository
    {
        private readonly DataContext _context = context;

        public void CreateOwner(Owner owner)
        {
            _context.Add(owner);
            _context.SaveChanges();
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).First();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokemonId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokemonId).Select(po => po.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(po => po.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public void UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            _context.SaveChanges();
        }
    }
}
