using System.ComponentModel.DataAnnotations;

namespace task.Models
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
        public string UserName { get; set; }   
        public string Password { get; set; }

    }
}
