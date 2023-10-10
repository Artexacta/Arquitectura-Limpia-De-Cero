namespace Infrastructure.EF.ReadModels
{
    public class NotificacionReadModel
    {
        public Guid Id { get; set; }
        public DateTime Creado { get; set; }
        public string Mensaje { get; set; }
        public string Email { get; set; }
    }
}
