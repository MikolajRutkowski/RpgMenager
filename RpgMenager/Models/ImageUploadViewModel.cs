﻿namespace RpgMenager.Mvc.Models
{
    public class ImageUploadViewModel
    {
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; } // Zawiera ścieżkę do przesłanego obrazu
    }

}
