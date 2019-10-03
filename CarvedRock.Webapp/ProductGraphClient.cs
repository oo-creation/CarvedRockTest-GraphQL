using System.Threading.Tasks;
using CarvedRock.Webapp.Models;
using GraphQL.Client;
using GraphQL.Common.Request;

namespace CarvedRock.Webapp
{
    public class ProductGraphClient
    {
        private readonly GraphQLClient _client;

        public ProductGraphClient(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<Product> GetProduct(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query productQuery($productId: ID!)
                { product(id: $productId)
                    {id name price rating photoFileName description stock introducedAt
                        reviews {title review}
                    }
                }",
                Variables = new {productId = id}
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Product>("product");
        }

        public async Task<Product[]> GetAllProducts()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                { products
                    { id name price rating photoFileName }
                }"
            };
            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Product[]>("products");
        }
    }
}