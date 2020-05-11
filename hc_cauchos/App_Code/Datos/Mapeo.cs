using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

/// <summary>
/// Descripción breve de Mapeo
/// </summary>
/// 
public class Mapeo : DbContext
{
    static Mapeo()
    {
        Database.SetInitializer<Mapeo>(null);
    }
    private readonly string schema;
    public Mapeo()
        :base("Name = Conexion")
    {

    }

    // variables que apuntan a la tabla
    public DbSet<EncapUsuario> usuario { get; set; }
    public DbSet<EncapRol> rol { get; set; }
    public DbSet<EncapEstado> estado { get; set; }
    public DbSet<EncapInventario> inventario { get; set; }
    public DbSet<EncapMarca> marca_carro  { get; set; }
    public DbSet<EncapCategoria> categoria { get; set; }
    public DbSet<EncapEstadoItem> estado_item { get; set; }
    public DbSet<EncapMision> mision { get; set; }
    public DbSet<EncapVision> vision { get; set; }
    public DbSet<EncapObjetivo> objetivo { get; set; }
    public DbSet<EncapCarrito> carrito { get; set; }
    public DbSet<EncapProveedor> proveedor { get; set; }
    public DbSet<EncapPedidoProveedor> pedido_proveedor { get; set; }
    public DbSet<EncapProductoProveedor> producto_proveedor { get; set; }
    public DbSet<EncapEstadoPProveedor> estado_pedido_proveedor { get; set; }
    public DbSet<EncapParametros> parametros { get; set; }
    public DbSet<EncapPedido> pedidos { get; set; }
    public DbSet<producto> aux { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(this.schema);
        base.OnModelCreating(modelBuilder);
    }

}