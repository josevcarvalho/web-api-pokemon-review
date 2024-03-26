using WebApiPokemonReview.Models;

namespace WebApiPokemonReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryExists(int id);
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(Country country);
    }
}
