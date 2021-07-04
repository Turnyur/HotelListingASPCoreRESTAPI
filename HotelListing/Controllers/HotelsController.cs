using AutoMapper;
using HotelListing.DTO;
using HotelListing.Services.UnitOfWork.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController:ControllerBase{

    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<HotelsController> _logger;
    private readonly IMapper _mapper;



    public HotelsController(IUnitOfWork unitOfWork,
        ILogger<HotelsController> logger,
        IMapper mapper
        )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;


    }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var hotels = await _unitOfWork.hotelRepository.GetAll();
                var results = _mapper.Map<IEnumerable<HotelDTO>>(hotels);
                return Ok(results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetCountries)}");
                return StatusCode(500, e);
            }
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotels = await _unitOfWork.hotelRepository.Get(
                    c => c.Id == id, new List<string>
                    {
                        "Country"
                    }
                    );
                var result = _mapper.Map<HotelDTO>(hotels);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something Went Wrong in the {nameof(GetCountries)}");
                return StatusCode(500, e);
            }
        }
    }
}
