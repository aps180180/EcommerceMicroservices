using AutoMapper;
using Microservices.Services.CupomAPI.Data;
using Microservices.Services.CupomAPI.Models;
using Microservices.Services.CupomAPI.Models.DTO;
using Microservices.Services.CupomAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.CupomAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    //[Authorize]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDTO _response;
        private IMapper _mapper;


        public CouponApiController(AppDbContext context, IMapper mapper)
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
                IEnumerable<Coupon> objList = _context.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);

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
                Coupon coupon = _context.Coupons.FirstOrDefault(x => x.CouponId == id);
                _response.Result = _mapper.Map<CouponDTO>(coupon);
               
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
        [Route("GetByCode/{code}")]
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupon coupon = _context.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
                if (coupon == null)
                {
                    _response.IsSuccess=false;
                    _response.Message = "Coupon code not found";

                }

                _response.Result = _mapper.Map<CouponDTO>(coupon);

               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }
        [HttpPost]
        [Authorize(Roles =Constants.RoleAdmin)]
        public ResponseDTO Post([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDTO); 
                _context.Coupons.Add(coupon);
                _context.SaveChanges();
                

                _response.Result = _mapper.Map<CouponDTO>(coupon);
                               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;

            }
            return _response;
        }
        
        [HttpPut]
        public ResponseDTO Put([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDTO);
                _context.Coupons.Update(coupon);
                _context.SaveChanges();


                _response.Result = _mapper.Map<CouponDTO>(coupon);

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
                Coupon coupon = _context.Coupons.FirstOrDefault(x=> x.CouponId ==id);

                if (coupon == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Coupon id not found";
                    return _response;

                }
                _context.Coupons.Remove(coupon);
                _context.SaveChanges();
                _response.Message = $"coupon id{id} was deleted";

                            

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
