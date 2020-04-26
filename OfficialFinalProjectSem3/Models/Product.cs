using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OfficialFinalProjectSem3.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Thumbnails { get; set; }
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
        public ProductStatus Status { get; set; }
        public enum ProductStatus
        {
            ACTIVE = 1, DEACTIVE = 0, DELETE = -1

        }

        public string GetDefaultThumbnail()
        {
            if (this.Thumbnails != null && this.Thumbnails.Length > 0)
            {
                var arrayThumbnail = this.Thumbnails.Split(',');
                if (arrayThumbnail.Length > 0)
                {
                    return ConfigurationManager.AppSettings["CloudinaryPrefix"] + arrayThumbnail[0];
                }
            }
            return ConfigurationManager.AppSettings["DefaultImage"];
        }

        public string[] GetThumbnails()
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

        public string[] GetThubnailIds()
        {
            var ids = new List<String>();
            var thumbnails = GetThumbnails();
            foreach(var thumb in thumbnails)
            {
                var splittedThumb = thumb.Split('/');
                if(splittedThumb.Length != 4)
                {
                    continue;
                }
                ids.Add(splittedThumb[3].Split('.')[0]);

            }
            return ids.ToArray();
        }
    }
}
