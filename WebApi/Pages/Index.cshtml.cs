using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Npgsql;
using StackExchange.Redis;
using System.Text.Json;
using WebApi.Dto;
using WebApi.Services;

namespace WebApi.Pages
{
    public class IndexModel(ILogger<IndexModel> logger, AppDbContext context, IConnectionMultiplexer? redis = null) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;
        private readonly AppDbContext _context = context;
        private readonly IConnectionMultiplexer? _redis = redis;

        public List<Product> Products { get; set; } = [];

        [BindProperty]
        public Product NewProduct { get; set; } = new();

        //private const string CacheKey = "products:list";

        public async Task OnGetAsync()
        {
            try {
                Products = [.. _context.Products.OrderBy(p => p.Id)];
            } catch(Exception ex) {
                _logger.LogError(ex, "Error getting index");
            }
        }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

            }

            return RedirectToPage();
        }
    }
}
