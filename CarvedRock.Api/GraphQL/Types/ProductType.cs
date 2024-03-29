using CarvedRock.Data.Entities;
using CarvedRock.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace CarvedRock.GraphQL.Types
{
    public class ProductType: ObjectGraphType<Product>
    {
        public ProductType(ProductReviewRepository reviewRepository,
            IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(t => t.Id);
            Field(t => t.Name).Description("The name of the product");
            Field(t => t.Description);
            Field(t => t.IntroducedAt).Description("When the product was first introduced in the catalog");
            Field(t => t.PhotoFileName).Description("This file name of the photo");
            Field(t => t.Price);
            Field(t => t.Rating).Description("The (max 5) star customer rating");
            Field(t => t.Stock);
            Field<ProductTypeEnumType>("Type", "The type of product");

            Field<ListGraphType<ProductReviewType>>(
                "reviews",
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductReview>(
                        "GetReviewsByProductId", reviewRepository.GetForProducts);
                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}