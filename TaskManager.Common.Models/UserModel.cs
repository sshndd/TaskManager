using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Common.Models
{
    public class UserModel
    {
        [Required]
        public int Id { get; set; }
        [Required] 
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte[] Photo { get; set; }
        public UserStatus Status { get; set; }

        public UserModel()
        {
            
        }

        public UserModel(string fname, string lname, string email, string password, UserStatus status, string phone)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            Password = password;
            Phone = phone;
            RegistrationDate = DateTime.Now;
            Status = status;
        }
    }
}
