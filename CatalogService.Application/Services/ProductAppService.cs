using CatalogService.Application.DTOs;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using MapsterMapper;
using Microsoft.Extensions.Configuration;


namespace CatalogService.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly string _imageServer;
        public ProductAppService(IProductRepository productRepository, IMapper mapper, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _configuration = configuration;
            _imageServer = _configuration["ImageServer"];
        }
        public void Add(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            _productRepository.Add(entity);
            _productRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
            _productRepository.SaveChanges();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                product.ImageUrl = _imageServer + product.ImageUrl;
            }
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public ProductDTO GetById(int id)
        {
            var product = _productRepository.GetById(id);
            product.ImageUrl = _imageServer + product.ImageUrl;
            return _mapper.Map<ProductDTO>(product);
        }

        public IEnumerable<ProductDTO> GetByIds(int[] ids)
        {
            var products = _productRepository.GetByIds(ids);
            foreach (var product in products)
            {
                product.ImageUrl = _imageServer + product.ImageUrl;
            }
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public void Update(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            _productRepository.Update(entity);
            _productRepository.SaveChanges();
        }
    }
}
