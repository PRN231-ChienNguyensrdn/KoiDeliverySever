using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class RatingsFeedback
    {
        public int FeedbackId { get; set; }
        public int OrderId { get; set; }
        public int? Rating { get; set; }
        public string? Feedback { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Order Order { get; set; } 
    }
}
