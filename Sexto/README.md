# Patrón Agregado Raíz

## Objetivo del ejercicio

El objetivo de este ejercicio es el de poder implementar el patrón
de diseño aggregate root para que nuestra solución sea basada en eventos
y siga más naturalmente la arquitectura limpia.

La solución tendrá dos funcionalidades. 
* Una será la de siempre que consiste en tener un ABM de Producto.
* Y luego tendremos una manera de ingresar un pedido; donde, en una transacción
se creará el maestro del pedido, todos los registros detalle y una actualización
al stock de los productos que intervienen en el pedido.

Se necesita mostrar cómo se separa la lógica de negocios y cómo se comunican
de los diferentes eventos entre los agregados raíz y las entidades.

## Otro uso del mediator: Publish

Mediator permite dos tipos de mensajes:

* Send: enviando un Request a un Handler, siempre devuelve algo
* Publish: notifica de un Evento a todos los handlers que sepan manejarlo, no 
devuelve nada

Cuando creamos un pedido, tenemos la complejidad que tenemos que actualizar el
stock de todos y cada uno de los ítems que conforman el pedido. La creación de
un pedido difiere de actualizar el stock, y sin embargo, deben ocurrir en la
misma lógica de negocios.

La propuesta es separar esto por eventos. Crear el pedido y notificar que el 
pedido ha sido creado. Existirá un controlador para los ítems del pedido para 
poderlos crear y validar contra los productos y también existirá un controlador
para actualizar el inventario (stock) de los productos afectados por el pedido.

En este caso, como elegimos la opción de publicar eventos utilizaremos la
función de Publish del mediator.

### Eventos de dominio

Estos son los eventos que publicaremos al mediator. Cada evento dentro de la 
aplicación será subclase de nuestro evento del dominio. Este evento del
dominio deberá implementar INotification.

## Patrón Agregado Raíz (Aggregate Root)

La mejor explicación es la que da el creador de este patrón Martin Fowler.

Agregado es un patrón del paradigma DDD. Un agregado DDD 
es un grupo de objetos de dominio que se pueden tratar como una sola unidad. 
Un ejemplo puede ser un pedido y sus elementos de línea, estos serán objetos 
separados, pero es útil tratar el pedido (junto con sus elementos de línea) 
como un solo agregado.

Un agregado tendrá uno de sus objetos componentes como la raíz del agregado. 
Cualquier referencia desde fuera del agregado solo debe ir a la raíz del 
agregado. La raíz puede así asegurar la integridad del agregado como un todo.

Para implementar este patrón, vamos a usar dos clases: la clase AggregateRoot
y la clase Entity. Una entidad son los objetos de dominio que forman parte
del agregado pero no son raíz.

Una entidad tiene:
* Una lista de eventos que llegan al agregado
* Un identificador único (usaremos un Guid)



1. Crear una aplicación web como en el anterior ejercicio.

2. Adicional la libreria de cliente font-awesome y asegurarse de llamarla en el Layout.

3. Crear el proyecto de librería Domain.

4. Crear el proyecto de librería Infrastructure

5. Crear el proyecto de librería Application

6. Crear el objeto del dominio Producto, solamente con 3 campos: Nombre, Stock y Precio.
No colocar Id todavía.

7. Crear el objeto de dominio PedidoItem que tiene los campos: PedidoId, ProductoId,
Cantidad, PrecioUnitario. El Total también se encuentra en esta clase pero es calculado
a partir de los datos. No colocar el Id todavía.

8. Crear el objeto del dominio Pedido. Solamente necesita los campos: Fecha, 
NombreCliente, Descuento. También se debe colocar Subtotal y Total pero ambos dependen
de los ítems que tenga el pedido. No colocar el Id todavía.

## Implementando Aggregate Root
Para ir implementando este patrón necesitaremos un proyecto que llamaremos SharedKernel.
Este proyecto tiene todo lo necesario para que los objetos del dominio puedan heredar
el funcionamiento que queremos para poder implementar el patrón.

9. Crear el proyecto SharedKernel

10. Colocar el nuget Mediatr Contracts

11. Crear la clase DomainEvent. Solamente se necesita colocar como atributos el 
momento en que el evento pasó y el id del mismo. Esto en la carpeta Core

12. Crear la clase Entity tal cual la describimos en la explicación del patrón
Agreagado Raíz.
```
public abstract class Entity<TId>
{
	public TId Id { get; protected set; }
	private readonly ICollection<DomainEvent> _domainEvents;

	public ICollection<DomainEvent> DomainEvents { get { return _domainEvents; } }

	protected Entity()
	{
		_domainEvents = new List<DomainEvent>();
	}

	public void AddDomainEvent(DomainEvent evento)
	{
		_domainEvents.Add(evento);
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}
}
```

13. Crear la clase AggregateRoot que solamente hace de subclase de Entity y nada más.
```
public abstract class AggregateRoot<TId> : Entity<TId>
{
}
```

14. Crear la interfaz IRepository en la carpeta Core y colocar los dos métodos que
siempre estarán en todos los objetos de dominio que tienen escritura.
```
public interface IRepository<T,in Tid> where T : AggregateRoot<Tid>
{
	Task<T> FindById(Tid id);
	Task CreateAsync(T obj);
}
```
15. El objeto del dominio Producto es un agregado raíz. Indicarlo explícitamente en
la clase. Esto hace que el objeto herede el Id. Esto hace que el proyecto Domain
dependa del objeto SharedKernel.
```
public class Producto : AggregateRoot<Guid>
{
	public string Nombre { get; set; }
	public int Stock { get; set; }
	public decimal Precio { get; set; }
	
	public Producto()
	{
		Nombre = "";
		Stock = 0;
		Precio = 0;
	}
}
```
16. El objeto del dominio Pedido es un agregado raíz. Indicarlo explícitamente en
la clase. Esto hace que el objeto herede el Id.
```
public class Pedido : AggregateRoot<Guid>
{
	public String NombreCliente { get; set; }
	public decimal Descuento { get; set; }
	public DateTime Fecha { get; set; }
	public List<PedidoItem> Detalles { get; set; }
	...
}
```
17. El objeto del dominio PedidoItem es una entidad. Indicarlo explícitamente en
la clase. Esto hace que el objeto herede el Id.
```
public class PedidoItem : Entity<Guid>
{
	public Guid PedidoId { get; set; }
	public Guid ProductoId { get; set; }
	public int Cantidad { get; set; }
	public decimal PrecioUnitario { get; set; }
	public decimal Total
	{
		get { return Cantidad * PrecioUnitario; }
	}
}
```

## Crear lo necesario para ejecutar el Migrations

18. Crear el DTO para Productos. Esto se hace en el proyecto Application.

19. Crear el DTO para Pedidos. Esto se hace en el proyecto Application.

20. Crear el DTO para PedidoItems. Esto se hace en el proyecto Application.

21. Crear el contexto de lectura como en el anterior programa. Esta vez tomar en
cuenta que se tienen 3 conjuntos: Pedidos, PedidoItems y Productos.

22. Crear el context de escritura como en el anterior programa. Esta vez tomar en
cuenta que se tienen 3 conjuntos: Pedidos, PedidoItems y Productos.

23. Instalar el EntityFrameworkCore SqlServer para que puedan funcionar las llamadas
específicas al momento de la creación de tablas y atributos.

24. Crear el Entity Configuration de producto, pedido y pedidoItem para la lectura. 
En esta clase se coloca el 
detalle de cómo se va a implementar la tabla en la base de datos. Este contexto
es el que se utiliza para los update database.

25. Crear el Entity Configuration de producto, pedido y pedidoItem para la escritura.
En esta clase solamente es necesario colocar el tema de la llave (id) de cada una 
de las tablas.

26. Colocar la configuración del string de conexión para la aplicación.

27. Crear la clase de implementación del patrón Unit of Work.

28. Asegurarse de tener la inyección de dependencias para que podamos ejecutar la
aplicación para que se pueda utilizar el update-database para revisar que 
el proyecto está correcto hasta ahora. Aquí no hay todavía nada específico, es 
solamente para que podamos utlizar el migrations.
```
public static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		var connectionString =
			configuration.GetConnectionString("DBConnectionString");

		services.AddDbContext<WriteDbContext>(context =>
			context.UseSqlServer(connectionString));
		services.AddDbContext<ReadDbContext>(context =>
			context.UseSqlServer(connectionString));

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}
```
29. Añadir la referencia a la inyección de dependencias de Infrasatructure desde el
Program de la aplicación principal. Para esto deberá hacer que el proyecto
de presentación haga referencia al proyecto Infrastructure.

30. Realizar los comandos necesarios para crear el migration y luego ejecutar 
el migrations creado. No olvidarse que para que reconozca los comandos debemos
tener el nuget de tools de entityframework.

## Crear los Repositorios

31. Inspirados en el anterior proyecto crear el repositorio para los productos,
pedidos y pedidoItem. tomar en cuenta que ahora el IRepository viene del proyecto
de SharedKernel.

No se hacen repositorios para objetos del dominio que no son agregados y se colocan
en estos repositorios todos los métodos que se necesiten para guardar y actualizar
las entidades de este agregado raíz.