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
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(this.schema);
        base.OnModelCreating(modelBuilder);
    }

}