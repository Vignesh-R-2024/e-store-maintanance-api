using AutoMapper;
using EStoreMaintanance.Contract;
using EStoreMaintanance.Model;

public class AutoMapperApiModel: Profile
{
  public AutoMapperApiModel()
  {
    CreateMap<ProductServiceContract , Product>()
    .ForMember(p => p.product_id, pSC => pSC.MapFrom(p => p.Id))
    .ForMember(p => p.product_name, pSC => pSC.MapFrom(p => p.ProductName))
    .ForMember(p => p.product_type, pSC => pSC.MapFrom(p => p.ProductType))
    .ForMember(p => p.supplier_id, pSC => pSC.MapFrom(p => p.SupplierId))
    .ForMember(p => p.Quantity_per_unit, pSC => pSC.MapFrom(p => p.QuantityPerUnit))
    .ForMember(p => p.units_in_stock, pSC => pSC.MapFrom(p => p.UnitsinStock))
    .ForMember(p => p.units_on_order, pSC => pSC.MapFrom(p => p.UnitsonOrder))
    .ForMember(p => p.Price, pSC => pSC.MapFrom(p => p.Price))
    .ReverseMap();
  }
}