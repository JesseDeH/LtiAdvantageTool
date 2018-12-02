﻿using System.Net.Http;
using System.Threading.Tasks;
using AdvantageTool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdvantageTool.Pages.Platforms
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public CreateModel(ApplicationDbContext context, 
            IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public PlatformModel Platform { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Platform.DiscoverEndpoints(_httpClientFactory);

            var user = await _context.GetUserAsync(User);
            var platform = new Platform { User = user };
            Platform.UpdateEntity(platform);

            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}