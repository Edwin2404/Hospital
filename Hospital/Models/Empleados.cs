using System.ComponentModel.DataAnnotations;

namespace Hospital
{
    public class Empleados
    {
        public int Id { get; set; }
        public int Documento { get; set; }

        [StringLength(25)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(25)]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(25)]
        public string Telefono { get; set; } = string.Empty;
        public int Edad { get; set; }

        public int AreaId { get; set; }

        public Area? Area { get; set; }
    }
}