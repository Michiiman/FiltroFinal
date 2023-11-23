# FiltroFinal Consultas

1. Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor.
   ```sql
      # /api/pago/PagosPaypal2008
   ```
    ```
   var Dato = await (
         from p in _context.Pagos
         where p.FechaPago.Year == 2008 && p.FormaPago == "Paypal"
         select new
         {
             IdTransaccion = p.IdTransaccion,
             Cliente = p.CodigoCliente,
             MetodoPago = p.FormaPago,
             FechaPago = p.FechaPago,
             Precio = p.Total
         }).OrderDescending()
         .ToListAsync();
     ```
   Ingresamos a la tabla de datos y buscamos el dato de la fecha de pago, usamos el ".Year" como el metodo de la funcion que nos permite extraer solo el dato del año,
   ya que es el que requerimos para comparar y a la vez comparamos que la forma de pago sea la que busquemos, con esto ya podemos filtrar la informacion que deseamos.
    
3. Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas.
   ```sql
      # /api/cliente/MetodosPago
   ```
    ```
        var Dato = await (
            from p in _context.Pagos
            where p.FormaPago != null
            select new
            {
                MetodoDePago = p.FormaPago
            }
            ).Distinct()
            .ToListAsync();
     ```
4. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
   ```sql
      # /api/cliente/ClientesPagoVentasCiudad
   ```
   ```
   var Dato = await (
             from cli in _context.Clientes
             join pag in _context.Pagos on cli.CodigoCliente equals pag.CodigoCliente
             join emp in _context.Empleados on cli.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
             where pag.IdTransaccion != null
             select new
            {
                ## Nombre = cli.NombreCliente,
                ## NombreRepresentante = emp.Nombre + " " + emp.Apellidol + " " + emp.Apellido2,
                 ##CiudadOficina = emp.CodigoOficina
             }).Distinct().ToListAsync();
 
         return Dato;
   ```
5.  Devuelve un listado que muestre el nombre de cada empleados, el nombre de su jefe y el nombre del jefe de sus jefe.
   ```sql
      # /api/empleado/EmpleadosyJefes
   ```
```
   var resultado = await (
            from e1 in _context.Empleados
            join e2 in _context.Empleados on e1.CodigoJefe equals e2.CodigoEmpleado into join1
            from jefe in join1.DefaultIfEmpty()
            join e3 in _context.Empleados on jefe.CodigoJefe equals e3.CodigoEmpleado into join2
            from jefe2 in join2.DefaultIfEmpty()
            select new
            {
                NombreEmpleado = e1.Nombre + " " + e1.Apellidol,
                NombreJefe = jefe != null ? jefe.Nombre + " " + jefe.Apellidol : null,
                NombreJefedelJefe = jefe2 != null ? jefe2.Nombre + " " + jefe2.Apellidol : null
            }).ToListAsync();
```
5. Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
   ```sql
      # /api/pedido/ProductosSinPedidoPlus
   ```
    ```
   var productosSinPedidos = await (
            from prod in _context.Productos
            join gp in _context.GamaProductos on prod.Gama equals gp.Gama
            where !_context.DetallePedidos.Any(dp => dp.CodigoProducto == prod.CodigoProducto)
            select new
            {
                CodigoProducto = prod.CodigoProducto,
                NombreProducto = prod.Nombre,
                Descripcion=gp.DescripcionTexto,
                Imagen= gp.Imagen
            }
        ).ToListAsync();
     ```
6.Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
   ```sql
      # /api/pedido/ProductosSinPedidoPlus
   ```
 ```
   var productosSinPedidos = await (
            from prod in _context.Productos
            join gp in _context.GamaProductos on prod.Gama equals gp.Gama
            where !_context.DetallePedidos.Any(dp => dp.CodigoProducto == prod.CodigoProducto)
            select new
            {
                CodigoProducto = prod.CodigoProducto,
                NombreProducto = prod.Nombre,
                Descripcion=gp.DescripcionTexto,
                Imagen= gp.Imagen
            }
        ).ToListAsync();
 ```
7. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
   ```sql
      # /api/pedido/PedidosPorEstado
   ```
    ```
      var pedidosPorEstado = await _context.Pedidos
            .GroupBy(p => p.Estado)
            .Select(g => new
            {
                Estado = g.Key,
                CantidadPedidos = g.Count()
            })
            .OrderByDescending(x => x.CantidadPedidos)
            .ToListAsync();
     ```
8.Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
   ```sql
      # /api/cliente/ClientesNingunPago
   ```
```
var resultado = await (
            from cli in _context.Clientes
            where !_context.Pagos.Any(p => p.CodigoCliente == cli.CodigoCliente)
            select cli
        ).ToListAsync();
```
9.Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
   ```sql
      # /api/cliente/ClientesConRepresentanteYCiudadOficina
   ```
   ```
   var clientes = await (
            from cliente in _context.Clientes
            join emp in _context.Empleados on cliente.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
            join ofi in _context.Oficinas on emp.CodigoOficina equals ofi.CodigoOficina
            select new
            {
                NombreCliente = cliente.NombreCliente,
                NombreRepresentante = emp.Nombre + " " + emp.Apellidol,
                CiudadOficina = ofi.Ciudad
            }
        ).ToListAsync();
   ```
10. Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
   ```sql
      # /api/cliente/ClientesSinPagosConRepresentante
   ```
```
   var clientesSinPagosConRepresentante = await (
            from cliente in _context.Clientes
            where !cliente.Pagos.Any()
            join emp in _context.Empleados on cliente.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
            select new
            {
                NombreCliente = cliente.NombreCliente,
                NombreRepresentante = emp.Nombre + " " + emp.Apellidol,
                ExtensionTelefonica = emp.Extension
            }
        ).ToListAsync();
```
