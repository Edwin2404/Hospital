using System.ComponentModel.DataAnnotations;

namespace Hospital
{
    public class SubAreaxArea
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public Area? Area { get; set; }

        public int SubAreaId { get; set; }
        public SubArea? SubArea { get; set; }

    }
}
