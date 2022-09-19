using Tercero.Models;
using Xunit;

namespace TerceroTest.Domain
{
    public class ProductoUnitTest
    {
        [Fact]
        public void QuitarDeInventarioDosItems()
        {
            // Arrange
            Producto p = new Producto();
            p.Cantidad = 50;

            // Act
            p.QuitarDeInventario(2);

            // Assert
            Assert.Equal<int>(48, p.Cantidad);
        }
    }
}