using Primero.Services;

namespace Primero.Implementations
{
    public class ReversaString : IReversaString
    {
        public string Reversa(string fuente)
        {
            return String.Concat(fuente.Reverse());
        }
    }
}
