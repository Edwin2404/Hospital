using System.ComponentModel.DataAnnotations;

namespace Hospital
{
    public class SubArea
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string SubAreaName { get; set; } = string.Empty;
    }
}
