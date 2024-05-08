namespace Catalog.API
{
    public class Constraint
    {
        public const string baseURL = "/api/v1";

        public const string GetProductApi = baseURL + "/products";

        public const string GetProductById = baseURL + "/products/{id}";

        public const string UpdateProduct = baseURL + "/products";

        public const string GetProductByCategory = baseURL + "/products/category/{category}";

        public const string DeleteProduct = baseURL + "/products/{id}";

        public const string CreateProduct = baseURL + "/products";
    }
}
