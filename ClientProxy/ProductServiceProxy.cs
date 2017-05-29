using System;
using Contract;
using System.ServiceModel;
using Model;

namespace ClientProxy
{
    public class ProductServiceProxy : ClientBase<IProductService>, IProductService
    {
        public void DeleteProduct(int productId)
        {
            base.Channel.DeleteProduct(productId);
        }

        public ProductsDS GetProducts()
        {
            return base.Channel.GetProducts();
        }

        public void InsertProduct(Product product)
        {
            base.Channel.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            base.Channel.UpdateProduct(product);
        }
    }
}
