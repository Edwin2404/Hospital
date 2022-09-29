using System.ComponentModel.DataAnnotations;

namespace Hospital
{
    public class Area
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string NameArea { get; set; } = string.Empty;

    }
}
