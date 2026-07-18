using CatalogService.Application.DTOs;
using CatalogService.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Mappings
{
    public class CatalogRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductDTO>().TwoWays();
        }
    }
}
