using AutoMapper;
using HomeAPI.Configuration;
using HomeAPI.Contracts.Models.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HomeAPI.Controllers
{
    /// <summary>
    /// Контроллер статусов устройств
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        //[HttpPost]
        //[Route("Add")]
        //public IActionResult Add()
        //{
        //    return StatusCode(200, "Этот метод будет добавлять новые устройства");
        //}

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(
          [FromBody] // Атрибут, указывающий, откуда брать значение объекта
   AddDeviceRequest request // Объект запроса
        )
        {
            if (request.CurrentVolts < 120)
            {
                return StatusCode(403, $"Устройства с напряжением меньше 120 вольт не поддерживаются!");
            }
            //return StatusCode(200, "Этот метод будет добавлять новые устройства");
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }
    }
}
