
namespace EStoreMaintanance.Model;

public class Product
{
   public string? product_name { get; set; }
   public int product_id { get; set; }
   public string? product_type { get; set; }
   public int Quantity_per_unit { get; set; }
   public double Price { get; set; }
   public string? supplier_id { get; set; }
   public int units_on_order { get; set; }
   public int units_in_stock { get; set; }  
}                                             
                