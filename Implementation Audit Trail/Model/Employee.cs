using System.ComponentModel.DataAnnotations;

namespace Implementation_Audit_Trail.Model
{
    public class Employee 
    {
        [Key]
        public Guid Id { get; set;}
        public string Name { get; set;}
        public string Address { get; set;}
        public string Department { get; set;}
    }
}
