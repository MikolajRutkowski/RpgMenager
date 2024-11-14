using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RpgMenager.Mvc.Controllers
{
    public static class ImageFactory
    {
        public static string PathToCopyImages { get; set; } = $"/images/";
        public static string BadImage { get; set; } = "Bad Image";
        public static async Task<string> FixImagePatchAsync(IFormFile imageUpload)
        {
            if (imageUpload != null && imageUpload.Length > 0)
            {
                var fileName = Path.GetFileName(imageUpload.FileName);
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageUpload.CopyToAsync(stream);
                }

                return (PathToCopyImages + fileName);
            }
            return BadImage;
        }
    }
}
