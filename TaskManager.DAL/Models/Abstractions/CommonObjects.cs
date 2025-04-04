namespace TaskManager.DAL.Models
{
    public class CommonObjects
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] Photo { get; set; }
        public CommonObjects()
        {
            CreateDate = DateTime.Now;
        }
    }
}
