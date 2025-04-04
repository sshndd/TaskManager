using System.ComponentModel.DataAnnotations;
using System.Numerics;
using TaskManager.Common.Models;

namespace TaskManager.DAL.Models
{
    public class User
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
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Desk> Desks { get; set; } = new List<Desk>();
        public List<Objective> Objectives { get; set; } = new List<Objective>();
        public UserStatus Status { get; set; }

        public User()
        {
            
        }

        public User(UserModel userModel)
        {
            Id = userModel.Id;
            FirstName = userModel.FirstName;
            LastName = userModel.LastName;
            Email = userModel.Email;
            Password = userModel.Password;
            Phone = userModel.Phone;
            RegistrationDate = userModel.RegistrationDate;
            LastLoginDate = userModel.LastLoginDate;
            Photo = userModel.Photo;
            Status = userModel.Status;
        }

        public User(string fname, string lname, string email, string password, UserStatus status = UserStatus.User, string phone = null, byte[] photo = null)
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            Password = password;
            Phone = phone;
            Photo = photo;
            RegistrationDate = DateTime.Now;
            Status = status;
        }

        public UserModel ToDto()
        {
            return new UserModel
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                Phone = this.Phone,
                RegistrationDate = this.RegistrationDate,
                LastLoginDate = this.LastLoginDate,
                Photo = this.Photo,
                Status = this.Status,
            };
        }
    }
}
