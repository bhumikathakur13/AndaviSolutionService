using AndaviSolutionService.Models;
using AndaviSolutionService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndaviSolutionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService) => _itemService = itemService;

        [HttpPost("Add")]
        [AllowAnonymous]
        public IActionResult AddItem(Item item)
        {
            int result = _itemService.Add(item);
            if (result == 1)
            {
                return Ok(new { Message = "Item added successfully" });
            }
            else
            {
                return BadRequest(new { Message = "Item already exists or insertion failed" });
            }
        }

        [HttpPut("Update")]
        [AllowAnonymous]
        public IActionResult UpdateItem(Item item)
        {
            int result = _itemService.Update(item);
            if (result == 1)
            {
                return Ok(new { Message = "Item Update successfully" });
            }
            else
            {
                return BadRequest(new { Message = "Update failed" });
            }
        }

        [HttpDelete("Delete")]
        [AllowAnonymous]
        public IActionResult DeleteItem(Item item)
        {
            int result = _itemService.Delete(item);
            if (result > 0)
            {
                return Ok(new { Message = "Item deleted successfully" });
            }
            else
            {
                return BadRequest(new { Message = "Delete failed" });
            }
        }
    }
}
