using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopigStore.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(225)")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(225)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(225)")]
        public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(225)")]
        public string PasswordSalt { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }

        [Phone]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string ProfilePictureUrl { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Bio { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Interests { get; set; }

        // Navigation properties
        public List<Interest> InterestList { get; set; }

        public virtual ICollection<UserItem> UserItems { get; set; }

        // User roles
        [Column(TypeName = "nvarchar(100)")]
        public string Role { get; set; } // e.g., Admin, Customer

        // Status
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }

        // Audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
    }
}
