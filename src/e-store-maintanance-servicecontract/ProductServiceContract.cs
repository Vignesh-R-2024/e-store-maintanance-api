
using System.ComponentModel.DataAnnotations;

namespace EStoreMaintanance.Contract;

public class ProductServiceContract
{
   [Required(ErrorMessage = "ProductName is Recuired Field.")]
    [StringLength(15, ErrorMessage ="ProductName can be minimum 3char maximun 15 chars.", MinimumLength =3)]
   public string? ProductName { get; set; }
   [Required (ErrorMessage = "ProductId is Recuired Field.")]
   public int Id { get; set; }
   [Required(ErrorMessage = "QuantityPerUnit is Recuired Field.")]
   public int QuantityPerUnit { get; set; }
   [Required(ErrorMessage = "ProductType is Recuired Field.")]
   [StringLength(10, ErrorMessage ="ProtuctType can be minimum 3char maximun 10 chars.", MinimumLength =3)]
   public string? ProductType { get; set;}
   [Required(ErrorMessage = "Price is Recuired Field.")]
   public double Price { get; set; }
   [Required(ErrorMessage = "SupplierId is Recuired Field.")]
   public string? SupplierId { get; set; }
   [Required(ErrorMessage = "UnitsOnOrder is Recuired Field.")]
   public int UnitsonOrder { get; set; }
   [Required(ErrorMessage = "UnitsInStock is Recuired Field.")]
   public int UnitsinStock { get; set; }  
}
