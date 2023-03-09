using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Egn { get; set; } 
        public string Education { get; set; }
        public string PhoneNumber { get; set; }

    }
}
