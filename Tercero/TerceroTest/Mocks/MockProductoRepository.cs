using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercero.Domain.Persistence;
using Tercero.Models;

namespace TerceroTest.Mocks
{
    public class MockProductoRepository
    {
        protected MockProductoRepository()
        {
        }

        public static Mock<IProductoRepository> GetMock()
        {
            List<Producto> productos =  new List<Producto>();

            productos.Add(new Producto() {
                Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                Nombre = "Herramienta",
                FechaVencimiento = DateTime.Now.AddDays(1000),
                Cantidad = 50,
                Estado = EstadoProducto.Activo,
                Precio = 100
            });

            var mock = new Mock<IProductoRepository>();

            mock.Setup(m => m.GetProductos(It.IsAny<string>())).Returns(productos);

            mock.Setup(m => m.GetProductoById(It.IsAny<Guid>()))
                .Returns(async (Guid id) =>
                await Task.Run(() =>
                {
                    // Producto vacio si tenemos error
                    Producto result = new Producto();
                    result.Id = Guid.Empty;

                    Producto? p = productos.Find(o => o.Id == id);
                    if (p == null) return result;

                    result = p;
                    return result;
                }));

            mock.Setup(m => m.Insert(It.IsAny<Producto>()))
                .Returns(async (Producto p) =>
                    await Task.Run(() =>
                    {
                        Guid nuevo = Guid.NewGuid();
                        p.Id = nuevo;
                        productos.Add(p);
                        return nuevo;
                    })
                );

            mock.Setup(m => m.Update(It.IsAny<Producto>()))
                .Callback((Producto p) =>
                {
                    Producto? antiguo = productos.Find(x => x.Id == p.Id);
                    if (antiguo == null)
                        return;

                    productos.RemoveAll(x => x.Id == p.Id);
                    productos.Add(p);
                });

            mock.Setup(m => m.Delete(It.IsAny<Guid>()))
                .Callback((Guid id) =>
                {
                    productos.RemoveAll(x => x.Id == id);
                });

            return mock;
        }
    }
}
