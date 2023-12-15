using Backend.Data;
using Backend.Filters;
using Backend.Helpers;
using Backend.Interfaces;
using Backend.Models;
using Backend.Models.DTO;
using Backend.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CatalogDBContext _context;
        private readonly IUriService _uriService;

        public CategoriesController(CatalogDBContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;
        }

        // GET: api/Categories/GetCategoryDatasets/13 
        [HttpGet("GetCategoryDatasets/{id}")]
        public async Task<IActionResult> GetCategoryDatasets(int id)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@CategoryId", id)
            };

            var data = await SPHelper.GetAllAsync(_context, "spGetCategoryDatasets", parameters);

            return Ok(data);
        }

        // GET: api/Categories/GetOneCategoryName/13 
        [HttpGet("GetOneCategoryName/{id}")]
        public async Task<IActionResult> GetOneCategoryName(int id)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@CategoryId", id)
            };

            var data = await SPHelper.GetOneOrExecAsync(_context, "spGetCategoryName", parameters);

            return Ok(data);
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Categories!
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            var totalRecords = await _context.Categories!.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<Category>(pagedData, validFilter, totalRecords, _uriService, route!);
            return Ok(pagedReponse);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(new Response<Category>(category));
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories/PostCategory
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'CatalogDBContext.Categories'  is null.");
            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
