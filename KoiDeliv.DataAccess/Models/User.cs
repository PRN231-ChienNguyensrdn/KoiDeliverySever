using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            CustomerProfiles = new HashSet<CustomerProfile>();
            Orders = new HashSet<Order>();
            ShipmentDeliveringStaffs = new HashSet<Shipment>();
            ShipmentSalesStaffs = new HashSet<Shipment>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<CustomerProfile> CustomerProfiles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Shipment> ShipmentDeliveringStaffs { get; set; }
        public virtual ICollection<Shipment> ShipmentSalesStaffs { get; set; }
    }
}
