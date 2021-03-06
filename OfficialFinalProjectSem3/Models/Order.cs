﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace OfficialFinalProjectSem3.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public double Total { get; set; }
        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        [Display(Name = "Finished At")]
        public DateTime FinishedAt { get; set; }
        public enum OrderStatus
        {
            ACTIVE = 1, DELIVERY = 0, FINISH = 2, CANCEL = 3
        }
    }
}