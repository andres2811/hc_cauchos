using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOEmpleado
/// </summary>
public class DAOEmpleado
{
    public DAOEmpleado()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }


    //METODO PARA OBTENER LOS CLIENTES EN VENTAS 
    public List<EncapUsuario> ObtenerClientes()
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario
                    where usu.Rol_id == 4
                    //join usuario - rol
                    join rol in db.rol on usu.Rol_id equals rol.Id
                    //join usuario - estado 
                    join estado in db.estado on usu.Estado_id equals estado.Id

                    select new
                    {
                        usu,
                        rol,
                        estado

                    }).ToList().Select(m => new EncapUsuario
                    {
                        User_id = m.usu.User_id,
                        Nombre = m.usu.Nombre,
                        Apellido = m.usu.Apellido,
                        Correo = m.usu.Correo,
                        Clave = m.usu.Clave,
                        Fecha_nacimiento = m.usu.Fecha_nacimiento,
                        Identificacion = m.usu.Identificacion,
                        //
                        Rol_id = m.usu.Rol_id,
                        RolNombre = m.rol.Nombre,
                        //
                        Estado_id = m.usu.Estado_id,
                        EstadoNombre = m.estado.Nombre

                    }).ToList();
        }
    }
    //METODO PARA OBTEENR CLIENTES POR NIMBRE
    public List<EncapUsuario> ObtenerClientesCedula(string cedula)
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario
                    where (usu.Rol_id == 4) && (usu.Identificacion == cedula)
                    //join usuario - rol
                    join rol in db.rol on usu.Rol_id equals rol.Id
                    //join usuario - estado 
                    join estado in db.estado on usu.Estado_id equals estado.Id

                    select new
                    {
                        usu,
                        rol,
                        estado

                    }).ToList().Select(m => new EncapUsuario
                    {

                        User_id = m.usu.User_id,
                        Nombre = m.usu.Nombre,
                        Apellido = m.usu.Apellido,
                        Correo = m.usu.Correo,
                        Clave = m.usu.Clave,
                        Fecha_nacimiento = m.usu.Fecha_nacimiento,
                        Identificacion = m.usu.Identificacion,
                        //
                        Rol_id = m.usu.Rol_id,
                        RolNombre = m.rol.Nombre,
                        //
                        Estado_id = m.usu.Estado_id,
                        EstadoNombre = m.estado.Nombre

                    }).ToList();
        }
    }

    //METODO PARA INSERTAR UN CLIENTE
    public void InsertarCliente(EncapUsuario clien)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Add(clien);
            db.SaveChanges();
        }
    }

    //OBTENGO CANTIDAD DE PRODUCTOS DE VENDEDOR CARRITO
    public int ObtenerCantidadxProductoCarritoxEmple(int user_id)
    {
        using (var db = new Mapeo())
        {
            return db.carrito.Where(x => x.User_id == user_id).Count();
        }
    }


    //METODO PARA INSERTAR PRODUCTOS AL MOMENTO DE VENTA
    public void InsertarProductos(EncapProducto_pedido producto)
    {
        using (var db = new Mapeo())
        {
            db.productos.Add(producto);
            db.SaveChanges();
        }
    }

    //ACTUALIZAR  CANTIDAD DEL PRODUCTO EN EL INVENTARIO 
    public void ActualizarCantidadInventario(EncapInventario producto)
    {
        using (var db = new Mapeo())
        {
            EncapInventario inventarioedit = db.inventario.Where(x => x.Id == producto.Id).SingleOrDefault();
            inventarioedit.Ca_actual = inventarioedit.Ca_actual - producto.Ca_actual;

            db.SaveChanges();
        }
    }

    //METODO PARA BORRAR EN CARRITO LUEGO DE HACER FACTURACION
    public void limpiarCarrito(int userid)
    {
        using (var db = new Mapeo())
        {
            List<EncapCarrito> productos = db.carrito.Where(x => x.User_id == userid).ToList();

            foreach (var pro in productos)
            {
                db.Entry(pro).State = EntityState.Deleted;
            }

            db.SaveChanges();
        }
    }

    //METODO PARA OBTENER LOS PEDIDOS DEL EMPLEADO
    public List<EncapPedido> ObtenerPedidos(int user)
    {
        using (var db = new Mapeo())
        
            return (from pedi in db.pedidos.Where(x=>x.Atendido_id== user && x.Estado_pedido == 2)
                    join usu in db.usuario on pedi.User_id equals usu.User_id 
                    //join emple in db.usuario  on pedi.Atendido_id  equals emple.User_id
                 

                    select new
                    {
                        pedi,
                        usu
                        //emple,
                 

                    }).ToList().Select(m => new EncapPedido
                    {           

                        Id=m.pedi.Id,
                        Fecha_pedido = m.pedi.Fecha_pedido,
                        User_id = m.pedi.User_id,
                        Atendido_id = m.pedi.Atendido_id,
                        Domiciliario_id=m.pedi.Domiciliario_id,                      
                        Estado_pedido = m.pedi.Estado_pedido,
                        Total= m.pedi.Total,
                        Novedad=m.pedi.Novedad,
                        Ciu_dep_id=m.pedi.Ciu_dep_id,
                        Direccion=m.pedi.Direccion,
                        Municipio_id=m.pedi.Municipio_id,
                        Fecha_pedido_fin=m.pedi.Fecha_pedido_fin,
                        Usuario = m.usu.Nombre
                        //Empleado = m.emple.Nombre,               


                    }).ToList();
        }

    //METODO PARA OBTENER LOS PRODUCTOS DEL PEDIDO
    public List<EncapProducto_pedido> ObtenerProductos(int pedido)
    {
        using (var db = new Mapeo())

            return (from produc in db.productos.Where(x => x.Pedido_id == pedido)
                    join inventario in db.inventario on produc.Producto_id equals inventario.Id

                    select new
                    {
                        produc,
                        inventario


                    }).ToList().Select(m => new EncapProducto_pedido
                    {

                        Id = m.produc.Id,
                        Pedido_id=m.produc.Pedido_id,
                        Producto_id=m.produc.Producto_id,
                        Cantidad=m.produc.Cantidad,
                        Precio=m.produc.Precio,
                        Total=m.produc.Total,
                        Nombre_producto=m.inventario.Titulo,
                        Referencia=m.inventario.Referencia
                        

                    }).ToList();
    }



    //ACTUALIZAR ESTADO PEDIDO A 2
    public void ActualizarEstadoPedido2(EncapPedido pedido2)
    {
        using (var db = new Mapeo())
        {
            EncapPedido estado = db.pedidos.Where(x => x.Id == pedido2.Id).SingleOrDefault();
            estado.Estado_pedido = pedido2.Estado_pedido;

            db.SaveChanges();
        }
    }

    //ACTUALIZAR ESTADO PEDIDO A 3
    public void ActualizarEstadoPedido3(EncapPedido pedido3)
    {
        using (var db = new Mapeo())
        {
            EncapPedido estado = db.pedidos.Where(x => x.Id == pedido3.Id).SingleOrDefault();
            estado.Estado_pedido = pedido3.Estado_pedido;

            db.SaveChanges();
        }
    }


    //ACTUALIZAR NOVEDAD EN EL PEDIDO
    public void ActualizarNovedadPedido(EncapPedido novedad)
    {
        using (var db = new Mapeo())
        {
            EncapPedido newnovedad = db.pedidos.Where(x => x.Id == novedad.Id).SingleOrDefault();
            newnovedad.Novedad = novedad.Novedad;

            db.SaveChanges();
        }
    }

    //ACTUALIZAR ESTADO EMPLEADO
    public void ActualizarEstadoEmpleado(EncapUsuario empleado)
    {
        using (var db = new Mapeo())
        {
            EncapUsuario emple = db.usuario.Where(x => x.User_id == empleado.User_id ).SingleOrDefault();
            emple.Estado_id = empleado.Estado_id;

            db.SaveChanges();
        }
    }
    public List<EncapCiudades_Dep> ConsultarDepartamento()
    {
        using (var db =new Mapeo())
        {
            return db.ciudades_departamentso.OrderBy(x => x.Id).ToList();
        }
    }
    public List<EncapMunicipio> ConsultarMunicipio()
    {
        using (var db = new Mapeo())
        {
            return db.municipios.OrderBy(x=> x.Id).ToList();
        }
    }
    //OBTENGO CANTIDAD DE PRODUCTOS DE USUARIO CARRITO
    public int ObtenerCantidadPedidos(int user_id)
    {
        using (var db = new Mapeo())
        {
            return db.pedidos.Where(x => x.Atendido_id == user_id && x.Estado_pedido==2).Count();
        }
    }
}



