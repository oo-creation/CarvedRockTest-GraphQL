using CarvedRock.Data.Entities;
using CarvedRock.GraphQL.Types;
using CarvedRock.Repositories;
using GraphQL.Types;

namespace CarvedRock.GraphQL
{
    public class CarvedRockQuery: ObjectGraphType
    {
        public CarvedRockQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>(
                "products",
                resolve: context => productRepository.GetAll()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productRepository.GetProduct(id);
                }
            );
        }
    }
}