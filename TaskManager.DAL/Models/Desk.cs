using System.Runtime.CompilerServices;

namespace TaskManager.DAL.Models
{
    public class Desk : CommonObjects
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; }
        public string Colums { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Objective> Tasks { get; set; } = new List<Objective>();
    }
}
