using Microsoft.EntityFrameworkCore;
using WebApiPokemonReview.Data;
using WebApiPokemonReview.Interfaces;
using WebApiPokemonReview.Models;

namespace WebApiPokemonReview.Repositories
{
    public class CategoryRepository(DataContext context) : ICategoryRepository
    {
        private readonly DataContext _context = context;

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {
            _context.Add(category);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteCategory(Category category)
        {
            _context.Remove(category);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category? GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public void UpdateCategory(Category category)
        {
            _context.Update(category);
            try
            {
                _context.SaveChanges();
            } 
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
