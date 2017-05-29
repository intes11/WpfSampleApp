using System;
using Contract;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel;
using System.Configuration;

namespace Service
{
   [System.ServiceModel.ServiceBehavior
        (
        ConcurrencyMode =ConcurrencyMode.Single
        , InstanceContextMode= InstanceContextMode.Single
        )]
   public class ProductService : IProductService
    {

        SqlConnection conn;

        public void DeleteProduct(int productId)
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WcfSampleProductsDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("uspProductDelete", conn);
                cmd.Parameters.Add(new SqlParameter("Id", productId));
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public ProductsDS GetProducts()
        {
            ProductsDS ds = new ProductsDS();

            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WcfSampleProductsDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("uspProductsGet", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.TableMappings.Add("Table", "Products");

                da.Fill(ds);

                return ds;
            }
        }

        public void InsertProduct(Product product)
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WcfSampleProductsDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("uspProductInsert", conn);
                cmd.Parameters.Add(new SqlParameter("Name", product.Name));
                cmd.Parameters.Add(new SqlParameter("Cost", product.Cost));
                cmd.Parameters.Add(new SqlParameter("Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("Category", product.Category));
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WcfSampleProductsDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("uspProductUpdate", conn);
                cmd.Parameters.Add(new SqlParameter("ProductId", product.Id));
                cmd.Parameters.Add(new SqlParameter("Name", product.Name));
                cmd.Parameters.Add(new SqlParameter("Cost", product.Cost));
                cmd.Parameters.Add(new SqlParameter("Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("Category", product.Category));
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();                
            }
        }
    }
}
