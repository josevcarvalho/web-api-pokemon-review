using WebApiPokemonReview.Models;

namespace WebApiPokemonReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country? GetCountry(int id);
        Country? GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        void CountryExists(int id);
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
