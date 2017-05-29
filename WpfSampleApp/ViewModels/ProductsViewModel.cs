using Model;
using System;
using System.Data;

namespace WpfSampleApp.ViewModels
{
    internal class ProductsViewModel
    {
        private ClientProxy.ProductServiceProxy _proxy;

        public ProductsDS.ProductsDataTable ProductsTable { get; set; }
        

        public ProductsViewModel()
        {
            _proxy = new ClientProxy.ProductServiceProxy();
            PrepareProducts();
        }

        /// <summary>
        /// Populates ProductsTable and registers RowChanged and RowDeleting events.
        /// </summary>
        private void PrepareProducts()
        {            
            ProductsTable = _proxy.GetProducts().Products;

            ProductsTable.RowChanged += new DataRowChangeEventHandler(Row_Changed);
            ProductsTable.RowDeleting += new DataRowChangeEventHandler(Row_Deleting);
        }

        /// <summary>
        /// Deletes the selected row from SQL server.
        /// </summary>
        private void Row_Deleting(object sender, DataRowChangeEventArgs e)
        {
            _proxy.DeleteProduct(Convert.ToInt32(e.Row["Id"]));
        }

        /// <summary>
        /// Adds or, if it already exists, updates the row in the SQL server.
        /// </summary>
        private void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            Product product = new Product
                (
                id: Convert.ToInt32(e.Row["Id"]),
                name: e.Row["Name"].ToString(),
                category: e.Row["CategoryName"].ToString(),
                cost: Convert.ToDouble(e.Row["Cost"]),
                price: Convert.ToDouble(e.Row["Price"])
                );
            

            if (e.Action == DataRowAction.Change)
            {
                _proxy.UpdateProduct(product);
            }
            else
            {
                _proxy.InsertProduct(product);
            }
        }
    }
}
