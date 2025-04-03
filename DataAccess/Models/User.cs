using TaskManager.Common.Models;

namespace TaskManager.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; } = null;
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime LastLoginDate { get; set; }
        public byte[] Photo { get; set; } = null;
        public List<Project> Projects { get; set; } = new List<Project>();
        public List<Desk> Desks { get; set; } = new List<Desk>();
        public List<Objective> Tasks { get; set; } = new List<Objective>();
        public UserStatus Status { get; set; } = UserStatus.User;

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
