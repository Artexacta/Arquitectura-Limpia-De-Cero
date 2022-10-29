namespace MediatorAndAggregate.Models
{
    public class ConfiguracionCaso
    {
        private static ConfiguracionCaso instancia = null;
        public static ConfiguracionCaso GetOrCreate()
        {
            if (instancia == null)
                instancia = new ConfiguracionCaso();
            return instancia;
        }

        private ConfiguracionCaso() {
            ErrorAlActualizarEstadistica = false;
            ErrorAlCrearCobro = false;
            ErrorAlNotificarBienvenida = false;
            ErrorAlNotificarCobro = false;
            ErrorAlRegistrarAlumno = false;
        }
        
        public bool ErrorAlRegistrarAlumno { get; set; }
        public bool ErrorAlActualizarEstadistica { get; set; }
        public bool ErrorAlCrearCobro { get; set; }
        public bool ErrorAlNotificarBienvenida { get; set; }
        public bool ErrorAlNotificarCobro { get; set; }
    }
}
