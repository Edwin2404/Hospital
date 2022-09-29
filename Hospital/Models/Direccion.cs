using System.ComponentModel.DataAnnotations;


namespace Hospital
{
    public class Direccion
    {
        [Key]
        [StringLength(50)]
        public string direccion { get; set; } = string.Empty;

        public int EmpleadoId { get; set; }
        public Empleados? Empleados { get; set; }
    }
}
