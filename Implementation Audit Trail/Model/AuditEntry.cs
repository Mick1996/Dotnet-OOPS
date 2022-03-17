using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Implementation_Audit_Trail.Model
{
    
    public class AuditEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuditId { get; set;} 
        public Guid EmployeeId { get; set;}
        public string TableName { get; set;} 
        public string Action { get; set;}
        public DateTime TimeStamp { get; set;}    
    }
}
