using AutoMapper;
using Microservices.Services.ProductAPI.Data;
using Microservices.Services.ProductAPI.Models;
using Microservices.Services.ProductAPI.Models.DTO;
using Microservices.Services.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    //[Authorize]
    public class ProductApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDTO _response;
        private IMapper _mapper;


        public ProductApiController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Product> objList = _context.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDTO>>(objList);

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Product Product = _context.Products.FirstOrDefault(x => x.ProductId == id);
                _response.Result = _mapper.Map<ProductDTO>(Product);
               
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        
        [HttpPost]
        //[Authorize(Roles =Constants.RoleAdmin)]
        public ResponseDTO Post([FromBody] ProductDTO ProductDTO)
        {
            try
            {
                Product Product = _mapper.Map<Product>(ProductDTO); 
                _context.Products.Add(Product);
                _context.SaveChanges();
                

                _response.Result = _mapper.Map<ProductDTO>(Product);
                               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }
        
        [HttpPut]
        public ResponseDTO Put([FromBody] ProductDTO ProductDTO)
        {
            try
            {
                Product Product = _mapper.Map<Product>(ProductDTO);
                _context.Products.Update(Product);
                _context.SaveChanges();


                _response.Result = _mapper.Map<ProductDTO>(Product);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO Delete(int id)
        {
            try
            {
                Product Product = _context.Products.FirstOrDefault(x=> x.ProductId ==id);

                if (Product == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Product id not found";
                    return _response;

                }
                _context.Products.Remove(Product);
                _context.SaveChanges();
                _response.Message = $"Product id{id} was deleted";

                            

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }
    }
}
