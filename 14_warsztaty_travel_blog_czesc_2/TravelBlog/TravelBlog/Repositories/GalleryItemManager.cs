using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async void RemoveGalleryItem(int? id)
        {
            var elementToRemove = await GetGalleryItem(id);
            if (elementToRemove != null)
            {
                _context.Entry(elementToRemove).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<GalleryItem> GetGalleryItem(int? id)
        {
            if (id != null)
            {
                GalleryItem item = await _context.GalleryItems.FirstOrDefaultAsync(m => m.Id == id);

                return item;
            }
            else
            {
                return null;
            }
        }

        public async void EditGalleryItem(GalleryItem item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GalleryItem>> GetList()
        { 
            return _context.GalleryItems.ToList();  
        }
    }
}
