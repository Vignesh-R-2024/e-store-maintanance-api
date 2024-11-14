using System.Collections.Generic;
using System.Data;
using EStoreMaintanance.Model;
using MySql.Data.MySqlClient;

namespace EStoreMaintanance.Services.ProductRepository;

public class ProductRepository
{
   private MySqlConnection _connection;
   private MySqlCommand command = new MySqlCommand();
   public ProductRepository(string connectionString)
   {
      _connection = new MySqlConnection(connectionString);  
      command.CommandType = CommandType.Text;
      command.Connection = _connection;
   }

   public Product GetProduct(int id)
   {
      Product? product = null;
      _connection.Open();
      command.CommandText = $"SELECT * FROM product where product_id = {id}";
      MySqlDataReader reader = command.ExecuteReader();
      if(reader.Read())
      {
        product = new Product();
        product.product_id = reader.GetInt32("product_id");
        product.product_name = reader.GetString("product_name");
        product.Quantity_per_unit = reader.GetInt32("Quantity_per_unit");
        product.product_type = reader.GetString("product_type");
        product.supplier_id = reader.GetString("supplier_id");
        product.units_in_stock = reader.GetInt32("units_in_stock");
        product.units_on_order = reader.GetInt32("units_on_order");
        product.Price = reader.GetDouble("Price");
      }
      _connection.Close();
     return product;
   }
   public List<Product> GetProductListOfSupplierId(string supplierId)
   {
     _connection.Open();
     List<Product> products = new List<Product>();
     command.CommandText = $"SELECT * FROM product WHERE supplier_id = '{supplierId}'";
     MySqlDataReader reader = command.ExecuteReader();
     while(reader.Read())
     {
        Product product = new Product();
        product.product_id = reader.GetInt32("product_id");
        product.product_name = reader.GetString("product_name");
        product.Quantity_per_unit = reader.GetInt32("Quantity_per_unit");
        product.product_type = reader.GetString("product_type");
        product.supplier_id = reader.GetString("supplier_id");
        product.units_in_stock = reader.GetInt32("units_in_stock");
        product.units_on_order = reader.GetInt32("units_on_order");
        product.Price = reader.GetDouble("Price");

        products.Add(product);
     }
     _connection.Close();
     return products;
   }
   public void AddProduct(Product product)
   {
     _connection.Open();
     command.CommandText = $"INSERT INTO product(product_id,product_name,Quantity_per_unit,product_type,supplier_id,units_in_stock,units_on_order,Price)VALUES({product.product_id},'{product.product_name}',{product.Quantity_per_unit},'{product.product_type}','{product.supplier_id}',{product.units_in_stock},{product.units_on_order},{product.Price})";
     command.ExecuteNonQuery();
     _connection.Close();
   }
   public void UpdateProduct(Product product)
   {
     _connection.Open();
     command.CommandText=$"UPDATE product SET product_name='{product.product_name}',Quantity_per_unit={product.Quantity_per_unit},product_type='{product.product_type}',supplier_id='{product.supplier_id}',units_in_stock={product.units_in_stock},units_on_order={product.units_on_order},Price={product.Price} WHERE product_id = {product.product_id}";       
     command.ExecuteNonQuery();
     _connection.Close();  
   }
    public void DeleteProduct(int productId)
    {
        _connection.Open();
        command.CommandText =$"DELETE FROM product WHERE product_id ={productId} ";
        command.ExecuteNonQuery();
        _connection.Close();
    }
}