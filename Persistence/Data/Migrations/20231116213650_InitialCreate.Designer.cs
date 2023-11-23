﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20231116213650_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("CodigoCliente")
                        .HasColumnType("int")
                        .HasColumnName("codigo_cliente");

                    b.Property<string>("ApellidoContacto")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("apellido_contacto");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ciudad");

                    b.Property<int?>("CodigoEmpleadoRepVentas")
                        .HasColumnType("int")
                        .HasColumnName("codigo_empleado_rep_ventas");

                    b.Property<string>("CodigoPostal")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_postal");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("fax");

                    b.Property<decimal?>("LimiteCredito")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("limite_credito");

                    b.Property<string>("LineaDireccion1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("linea_direccion1");

                    b.Property<string>("LineaDireccion2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("linea_direccion2");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(58)
                        .HasColumnType("varchar(58)")
                        .HasColumnName("nombre_cliente");

                    b.Property<string>("NombreContacto")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("nombre_contacto");

                    b.Property<string>("Pais")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("pais");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("region");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono");

                    b.HasKey("CodigoCliente")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CodigoEmpleadoRepVentas" }, "codigo_empleado_rep_ventas");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetallePedido", b =>
                {
                    b.Property<int>("CodigoPedido")
                        .HasColumnType("int")
                        .HasColumnName("codigo_pedido");

                    b.Property<string>("CodigoProducto")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("codigo_producto");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<short>("NumeroLinea")
                        .HasColumnType("smallint")
                        .HasColumnName("numero_linea");

                    b.Property<decimal>("PrecioUnidad")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("precio_unidad");

                    b.HasKey("CodigoPedido", "CodigoProducto")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "CodigoProducto" }, "codigo_producto");

                    b.ToTable("detalle_pedido", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("CodigoEmpleado")
                        .HasColumnType("int")
                        .HasColumnName("codigo_empleado");

                    b.Property<string>("Apellido2")
                        .HasMaxLength(58)
                        .HasColumnType("varchar(58)")
                        .HasColumnName("apellido2");

                    b.Property<string>("Apellidol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellidol");

                    b.Property<int?>("CodigoJefe")
                        .HasColumnType("int")
                        .HasColumnName("codigo_jefe");

                    b.Property<string>("CodigoOficina")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_oficina");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("extension");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Puesto")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("puesto");

                    b.HasKey("CodigoEmpleado")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CodigoJefe" }, "codigo_jefe");

                    b.HasIndex(new[] { "CodigoOficina" }, "codigo_oficina");

                    b.ToTable("empleado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.GamaProducto", b =>
                {
                    b.Property<string>("Gama")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("gama");

                    b.Property<string>("DescripcionHtml")
                        .HasColumnType("text")
                        .HasColumnName("descripcion_html");

                    b.Property<string>("DescripcionTexto")
                        .HasColumnType("text")
                        .HasColumnName("descripcion_texto");

                    b.Property<string>("Imagen")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)")
                        .HasColumnName("imagen");

                    b.HasKey("Gama")
                        .HasName("PRIMARY");

                    b.ToTable("gama_producto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Oficina", b =>
                {
                    b.Property<string>("CodigoOficina")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_oficina");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("varchar(38)")
                        .HasColumnName("ciudad");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("codigo_postal");

                    b.Property<string>("LineaDireccion1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("linea_direccion1");

                    b.Property<string>("LineaDireccion2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("linea_direccion2");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("pais");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("region");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefono");

                    b.HasKey("CodigoOficina")
                        .HasName("PRIMARY");

                    b.ToTable("oficina", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.Property<int>("CodigoCliente")
                        .HasColumnType("int")
                        .HasColumnName("codigo_cliente");

                    b.Property<string>("IdTransaccion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id_transaccion");

                    b.Property<DateOnly>("FechaPago")
                        .HasColumnType("date")
                        .HasColumnName("fecha_pago");

                    b.Property<string>("FormaPago")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("varchar(48)")
                        .HasColumnName("forma_pago");

                    b.Property<decimal>("Total")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("total");

                    b.HasKey("CodigoCliente", "IdTransaccion")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.ToTable("pago", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("CodigoPedido")
                        .HasColumnType("int")
                        .HasColumnName("codigo_pedido");

                    b.Property<int>("CodigoCliente")
                        .HasColumnType("int")
                        .HasColumnName("codigo_cliente");

                    b.Property<string>("Comentarios")
                        .HasColumnType("text")
                        .HasColumnName("comentarios");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("estado");

                    b.Property<DateOnly?>("FechaEntrega")
                        .HasColumnType("date")
                        .HasColumnName("fecha_entrega");

                    b.Property<DateOnly>("FechaEsperada")
                        .HasColumnType("date")
                        .HasColumnName("fecha_esperada");

                    b.Property<DateOnly>("FechaPedido")
                        .HasColumnType("date")
                        .HasColumnName("fecha_pedido");

                    b.HasKey("CodigoPedido")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CodigoCliente" }, "codigo_cliente");

                    b.ToTable("pedido", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<string>("CodigoProducto")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("codigo_producto");

                    b.Property<short>("CantidadEnStock")
                        .HasColumnType("smallint")
                        .HasColumnName("cantidad_en_stock");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<string>("Dimensiones")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("dimensiones");

                    b.Property<string>("Gama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("gama");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("nombre");

                    b.Property<decimal?>("PrecioProveedor")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("precio_proveedor");

                    b.Property<decimal>("PrecioVenta")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("precio_venta");

                    b.Property<string>("Proveedor")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("proveedor");

                    b.HasKey("CodigoProducto")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Gama" }, "gama");

                    b.ToTable("producto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdUsuarioFk")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioFk");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RolUsuario", b =>
                {
                    b.Property<int>("IdUsuarioFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.HasKey("IdUsuarioFk", "IdRolFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.Empleado", "CodigoEmpleadoRepVentasNavigation")
                        .WithMany("Clientes")
                        .HasForeignKey("CodigoEmpleadoRepVentas")
                        .HasConstraintName("cliente_ibfk_1");

                    b.Navigation("CodigoEmpleadoRepVentasNavigation");
                });

            modelBuilder.Entity("Domain.Entities.DetallePedido", b =>
                {
                    b.HasOne("Domain.Entities.Pedido", "CodigoPedidoNavigation")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("CodigoPedido")
                        .IsRequired()
                        .HasConstraintName("detalle_pedido_ibfk_1");

                    b.HasOne("Domain.Entities.Producto", "CodigoProductoNavigation")
                        .WithMany("DetallePedidos")
                        .HasForeignKey("CodigoProducto")
                        .IsRequired()
                        .HasConstraintName("detalle_pedido_ibfk_2");

                    b.Navigation("CodigoPedidoNavigation");

                    b.Navigation("CodigoProductoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.HasOne("Domain.Entities.Empleado", "CodigoJefeNavigation")
                        .WithMany("InverseCodigoJefeNavigation")
                        .HasForeignKey("CodigoJefe")
                        .HasConstraintName("empleado_ibfk_2");

                    b.HasOne("Domain.Entities.Oficina", "CodigoOficinaNavigation")
                        .WithMany("Empleados")
                        .HasForeignKey("CodigoOficina")
                        .IsRequired()
                        .HasConstraintName("empleado_ibfk_1");

                    b.Navigation("CodigoJefeNavigation");

                    b.Navigation("CodigoOficinaNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "CodigoClienteNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("CodigoCliente")
                        .IsRequired()
                        .HasConstraintName("pago_ibfk_1");

                    b.Navigation("CodigoClienteNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "CodigoClienteNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("CodigoCliente")
                        .IsRequired()
                        .HasConstraintName("pedido_ibfk_1");

                    b.Navigation("CodigoClienteNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.HasOne("Domain.Entities.GamaProducto", "GamaNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("Gama")
                        .IsRequired()
                        .HasConstraintName("producto_ibfk_1");

                    b.Navigation("GamaNavigation");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.RolUsuario", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pagos");

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("InverseCodigoJefeNavigation");
                });

            modelBuilder.Entity("Domain.Entities.GamaProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.Oficina", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Navigation("DetallePedidos");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolUsuarios");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("RolUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}