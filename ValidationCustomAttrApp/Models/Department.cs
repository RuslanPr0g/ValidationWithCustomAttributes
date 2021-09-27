using ValidationCustomAttrApp.CustomAttributes;

namespace ValidationCustomAttrApp.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15, 2)]
        public string DeptShortName { get; set; }

        public string DeptLongName { get; set; }
    }
}
