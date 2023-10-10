namespace Application.Dtos
{
    public class ConfiguracionCasoDto
    {
        public bool ErrorAlRegistrarAlumno { get; set; }
        public bool ErrorAlActualizarEstadistica { get; set; }
        public bool ErrorAlCrearCobro { get; set; }
        public bool ErrorAlNotificarBienvenida { get; set; }
        public bool ErrorAlNotificarCobro { get; set; }
        public bool SinAgregado { get; set; }
        public string RegistrarAlumno { get; set; }
        public string EnMateria { get; set; }
        public string Mensaje { get; set; }

        public ConfiguracionCasoDto()
        {
            ErrorAlActualizarEstadistica = false;
            ErrorAlCrearCobro = false;
            ErrorAlNotificarBienvenida = false;
            ErrorAlNotificarCobro = false;
            ErrorAlRegistrarAlumno = false;

            RegistrarAlumno = "";
            EnMateria = "";
            Mensaje = "";
        }
    }
}
