using Model;
using System.ServiceModel;

namespace Contract
{    
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductsDS GetProducts();

        [OperationContract]
        void InsertProduct(Product product); 

        [OperationContract]
        void UpdateProduct(Product product); 

        [OperationContract]
        void DeleteProduct(int productId);
    }
}
