using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CarvedRock.Data;
using CarvedRock.Data.Entities;

namespace CarvedRock.Repositories
{
    public class ProductRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        public Product GetProduct(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}