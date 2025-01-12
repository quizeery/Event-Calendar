using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunnyWeb.Models
{
    public class CalendarEvent
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string Title { get; set; }
        
        [Required]
        public required string Description { get; set; }
        
        public DateTime EventDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Color { get; set; } = "#3788d8";
        public bool AllDay { get; set; } = false;
    }
} 