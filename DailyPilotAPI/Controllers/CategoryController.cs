using AutoMapper;
using DailyPilot.BLL.DTOs;
using DailyPilot.DAL.Context;
using DailyPilot.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyPilotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet(Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult GetCategory()
        {
            var cat = _context.Categories.ToList();
            if (cat.Count == 0)
            {
                return NotFound("No categories found.");
            }
            return Ok(cat);
        }


        //get category by id
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetCategoryById(int id)
        {
            var cats = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (cats == null)
            {
                return NotFound($"Id for {id} is not found");

            }
            return Ok(cats);
        }


        [HttpPost]
        public ActionResult CreateCategory(Category obj)
        {

            Category cate = new Category()
            {
                Name = obj.Name,
            };
            _context.Categories.Add(cate);
            _context.SaveChanges();
            return Ok(cate);
        }


        //tracking 
        [HttpPut("id")]
        public ActionResult UpdateCategory(int id, [FromBody] CategoryDto catDto)
        {
            if (id != catDto.Id)
            {
                return BadRequest("Category ID mismatch.");
            }
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            existingCategory.Name = catDto.Name;
            _context.Categories.Update(existingCategory);
            _context.SaveChanges();
            return Ok(existingCategory);
        }


    }
}
