
using Microsoft.AspNetCore.Mvc;
using EStoreMaintanance.Services.ProductRepository;
using EStoreMaintanance.Model;
using System.Collections.Generic;
using EStoreMaintanance.Contract;
using System.Linq;
using AutoMapper;

namespace EStoreMaintanance.api.Controllers;

[ApiController]
[Route("[Controller]")]

public class EStoreMaintanance : ControllerBase
{
   private ProductRepository _productRepository;
   private IMapper _mapper;
   public EStoreMaintanance(IMapper mapper)
   {
      _mapper = mapper;
      _productRepository = new ProductRepository("server=127.0.0.1;port=3306;database=e_store_maintanance;user=vicky;password=Dev2024"); 
   }
  
   // private ProductServiceContract Convert(Product product)
   // {
   //    ProductServiceContract productServiceContract = new ProductServiceContract();

   //    productServiceContract.Id = product.product_id;
   //    productServiceContract.ProductName = product.product_name;
   //    productServiceContract.ProductType = product.product_type;
   //    productServiceContract.SupplierId =  product.supplier_id;
   //    productServiceContract.UnitsinStock = product.units_in_stock;
   //    productServiceContract.UnitsonOrder = product.units_on_order;
   //    productServiceContract.QuantityPerUnit = product.Quantity_per_unit;
   //    productServiceContract.Price = product.Price;
   //    return productServiceContract;
   // }
   // private Product ConvertProduct(ProductServiceContract productServiceContract)
   // {
   //    Product product = new Product();
   //    product.product_id = productServiceContract.Id ;
   //    product.product_name = productServiceContract.ProductName;
   //    product.product_type = productServiceContract.ProductType;
   //    product.supplier_id = productServiceContract.SupplierId;
   //    product.units_in_stock = productServiceContract.UnitsinStock;
   //    product.units_on_order = productServiceContract.UnitsonOrder;
   //    product.Quantity_per_unit = productServiceContract.QuantityPerUnit;
   //    product.Price = productServiceContract.Price;
   //    return product;
   // }


   
   [HttpGet("{id}")]
   public IActionResult GetProduct(int id)
   {
     var product = _productRepository.GetProduct(id);
     if(product is null)
      return NotFound($"Product Id: {id} Is Not Found.");
     var productServiceContract = _mapper.Map<ProductServiceContract>(product);
     return Ok(productServiceContract);
   }

   [HttpGet("supplier/{supplierId}")]
   public IActionResult GetProductListOfSupplierId(string supplierId)
   {
      List<ProductServiceContract> productServiceContract = new List<ProductServiceContract>();
      var productListOfSupplierId= _productRepository.GetProductListOfSupplierId(supplierId);
      if(!productListOfSupplierId.Any())
      {
        return NotFound($"SupplierId: {supplierId} Is Not Found.");
      }
      foreach(var product in productListOfSupplierId)
         productServiceContract.Add(_mapper.Map<ProductServiceContract>(product));   
      return Ok(productServiceContract);
   } 

   [HttpPost]
   public IActionResult AddProduct(ProductServiceContract productServiceContract)
   {
      if(ModelState.IsValid)
      {
        var product = _mapper.Map<Product>(productServiceContract);
        _productRepository.AddProduct(product);
        return Ok();
      }
      return BadRequest();
   }
   [HttpPut]
   public IActionResult UpdateProduct(ProductServiceContract productServiceContract)
   {
      if(productServiceContract.Id > 0 && productServiceContract.ProductName == null && productServiceContract.ProductName == "" && productServiceContract.ProductType == null && productServiceContract.ProductType =="" && productServiceContract.Price >0 && productServiceContract.SupplierId == null && productServiceContract.SupplierId=="" && productServiceContract.UnitsinStock>0 && productServiceContract.UnitsonOrder>0 && productServiceContract.QuantityPerUnit>0)
      {
         var product = _mapper.Map<Product>(productServiceContract);
         _productRepository.UpdateProduct(product);
         return Ok();
      }
      return BadRequest();
   }
   [HttpDelete("{productId}")]
   public IActionResult DeleteProduct(int productId)
   {
     if(productId > 0) 
     {
      _productRepository.DeleteProduct(productId);
      return Ok();
     }
     return BadRequest();
   }

}