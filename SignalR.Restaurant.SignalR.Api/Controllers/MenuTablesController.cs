using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Restaurant.Business.Abstract;
using SignalR.Restaurant.Dtos.MenuTableDtos;
using SignalR.Restaurant.Entities.Entities;

namespace SignalR.Restaurant.SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            return Ok(_menuTableService.TMenuTableCount());
        }

        [HttpGet]
        public IActionResult MenuTableList()
        {
            var values = _menuTableService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            _menuTableService.TAdd(new MenuTable()
            {
                MenuTableName = createMenuTableDto.MenuTableName,
                MenuTableStatus = false
            });
            return Ok("Masa Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.TGetById(id);
            _menuTableService.TDelete(value);
            return Ok("Masa Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            _menuTableService.TUpdate(new MenuTable()
            {
                MenuTableName = updateMenuTableDto.MenuTableName,
                MenuTableStatus = updateMenuTableDto.MenuTableStatus,
                MenuTableID = updateMenuTableDto.MenuTableID
            });
            return Ok("Masa güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var values = _menuTableService.TGetById(id);
            return Ok(values);
        }
    }
}
