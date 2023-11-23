# FiltroFinal Consultas

1. Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor.
   ```sql
      # /api/pago/PagosPaypal2008
   ```
2. Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas.
   ```sql
      # /api/cliente/MetodosPago
   ```
3. Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
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
4.  Devuelve un listado que muestre el nombre de cada empleados, el nombre de su jefe y el nombre del jefe de sus jefe.
   ```sql
      # /api/empleado/EmpleadosyJefes
   ```
5. Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
   ```sql
      # /api/pedido/ProductosSinPedidoPlus
   ```
6.Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
   ```sql
      # /api/pedido/ProductosSinPedidoPlus
   ```
7. ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
   ```sql
      # /api/pedido/PedidosPorEstado
   ```
8.Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
   ```sql
      # /api/cliente/ClientesNingunPago
   ```
9.Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
   ```sql
      # /api/cliente/ClientesConRepresentanteYCiudadOficina
   ```
10. Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
   ```sql
      # /api/cliente/ClientesSinPagosConRepresentante
   ```
