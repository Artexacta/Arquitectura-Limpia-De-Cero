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

        private ConfiguracionCaso() { }
        
        public bool ErrorEnLevel0 { get; set; }
        public bool ErrorEnLevel1 { get; set; }
        public bool ErrorEnLevel2 { get; set; }
        public bool ExecuteLevel2 { get; set; }
    }
}
