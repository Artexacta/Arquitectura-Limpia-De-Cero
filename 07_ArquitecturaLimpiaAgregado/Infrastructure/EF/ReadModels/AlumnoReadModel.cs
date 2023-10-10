using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EF.ReadModels
{
    public class AlumnoReadModel
    {
        public Guid Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Nombre { get; set; }
    }
}
