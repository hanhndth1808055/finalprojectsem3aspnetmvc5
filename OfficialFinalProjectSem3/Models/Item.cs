using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfficialFinalProjectSem3.Models
{
    public class Item
    {
        private readonly string ImageDomain = "https://res.cloudinary.com/daaycakkk/";
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Thumbnails { get; set; }

        public string GetDefaultThumbnail()
        {
            if(this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnail = this.Thumbnails.Split(',');
                if(arrayThumbnail.Length > 0)
                {
                    return ImageDomain + arrayThumbnail[0];
                }
            }
            return "https://daykemtainang.com/wp-content/themes/bitcoinee/images/no-thumbnail.jpg";
        }

        public string[] GetDefaultThumbnails()
        {
            if (this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnail = this.Thumbnails.Split(',');
                if (arrayThumbnail.Length > 0)
                {
                    return arrayThumbnail;
                }
            }
            return new string[0];
        }
    }
}