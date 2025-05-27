using Microsoft.EntityFrameworkCore;
using PokemonReview.WebApi.Data;
using PokemonReview.WebApi.Interfaces;
using PokemonReview.WebApi.Models;

namespace PokemonReview.WebApi.Repositories
{
    public class CountryRepository(DataContext context) : ICountryRepository
    {
        private readonly DataContext _context = context;

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public void CreateCountry(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(Country country)
        {
            _context.Remove(country);
            _context.SaveChanges();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id).First();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).First();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Include(c => c.Country).Where(c => c.Country.Id == countryId).ToList();
        }

        public void UpdateCountry(Country country)
        {
            _context.Update(country);
            _context.SaveChanges();
        }
    }
}
