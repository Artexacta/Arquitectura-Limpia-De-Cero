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

        public string[] Alumnos = { "Hugo", "Paco", "Luis", "Maria" };
        public string[] Materias = { "Programación II", "Investigación Operativa", "Cálculo II", "Algoritmos" };

        public bool ErrorAlRegistrarAlumno { get; set; }
        public bool ErrorAlActualizarEstadistica { get; set; }
        public bool ErrorAlCrearCobro { get; set; }
        public bool ErrorAlNotificarBienvenida { get; set; }
        public bool ErrorAlNotificarCobro { get; set; }
        public bool SinAgregado { get; set; }
        public string RegistrarAlumno { get; set; }
        public string EnMateria { get; set; }
    }
}
