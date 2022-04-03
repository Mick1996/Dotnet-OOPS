using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Complaint_Api.DAL.Model
{
    public class Vendor
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; } 
        public string Name { get; set;}
        public string JobType { get; set;}
        [JsonIgnore]
        public string ComplaintBox { get; set;}   

    }
}
