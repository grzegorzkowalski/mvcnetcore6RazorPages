using Microsoft.AspNetCore.Mvc;
using TravelBlog.Data;
using TravelBlog.Models;

namespace TravelBlog.Repositories
{
    public class GalleryItemManager
    {
        private readonly ApplicationDbContext _context;
        public GalleryItemManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GalleryItem> AddGalleryItem(GalleryItem item)
        {
            _context.GalleryItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<List<GalleryItem>> GetList()
        { 
            return _context.GalleryItems.ToList();  
        }
    }
}
