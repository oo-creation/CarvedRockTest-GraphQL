using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarvedRock.Data;
using CarvedRock.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Repositories
{
    public class ProductReviewRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductReview> GetAll()
        {
            return _dbContext.ProductReviews;
        }

        public IEnumerable<ProductReview> GetForProducts(int productId)
        {
            return _dbContext.ProductReviews.Where(p => p.ProductId == productId);
        }

        public async Task<ILookup<int, ProductReview>> GetForProducts(IEnumerable<int> productIds)
        {
            var reviews = await _dbContext.ProductReviews.Where(pr => productIds.Contains(pr.ProductId)).ToListAsync();
            return reviews.ToLookup(r => r.ProductId);
        }

        public async Task<ProductReview> AddReview(ProductReview review)
        {
            _dbContext.ProductReviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}