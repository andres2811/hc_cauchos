using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdmin
/// </summary>
public class DAOAdmin
{

    //METODO PARA VERIFICAR USUARIO EN LOGIN 
    public EncapUsuario loginEntity(EncapUsuario user)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(user.Correo) && x.Clave.Equals(user.Clave)).FirstOrDefault();
        }

    }
    //METODO PARA BUSCAR CORREO EN LOGIN 
    public EncapUsuario BuscarCorreo(string correo)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(correo)).FirstOrDefault();
        }

    }

    //METODO PARA VERIFICAR TOKEN DE RECUPERACION EN LOGIN 
    public EncapUsuario BuscarToken(string token)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Token.Equals(token) && x.Estado_id == 2).FirstOrDefault();
        }

    }


    //METODO PARA ACTUALIZAR USUARIOS 
    public void ActualizarUsuario(EncapUsuario user)
    {
        using (var db = new Mapeo())
        {

            var resultado = db.usuario.SingleOrDefault(b => b.User_id == user.User_id);
            if (resultado != null)
            {
                resultado.Nombre = user.Nombre;
                resultado.Apellido = user.Apellido;
                resultado.Correo = user.Correo;
                resultado.Clave = user.Clave;
                resultado.Fecha_nacimiento = user.Fecha_nacimiento;
                resultado.Identificacion = user.Identificacion;
                resultado.Token = user.Token;
                resultado.Estado_id = user.Estado_id;
                resultado.Rol_id = user.Rol_id;
                resultado.Tiempo_token = user.Tiempo_token;
                resultado.Sesion = user.Sesion;
                resultado.Last_modify = DateTime.Now;
                resultado.Ip_ = user.Ip_;
                resultado.Mac_ = user.Mac_;

                db.SaveChanges();
            }

        }

    }

    //METODO PARA OBTENER USUARIO COMPLETO
    public List<EncapUsuario> ObtenerUsuario(string correo)
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario
                    where usu.Correo == correo
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

    //###################################################################################################################//

    //METODO PARA VERIFICAR SI EL CORREO ESTA AL MOMENTO DE REGISTRAR EMPLEADO
    public EncapUsuario verificarCorreo(EncapUsuario emple)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(emple.Correo)).FirstOrDefault();
        }
    }

    //METODO PARA INSERTAR UN EMPLEADO
    public void InsertarEmpleado(EncapUsuario emple)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Add(emple);
            db.SaveChanges();
        }
    }

    //METODO PARA TRAER USUARIO CON NOMBRE DE ROL Y ESTADO 

    public List<EncapUsuario> ObtenerEmpleados()
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario where usu.Rol_id == 2 || usu.Rol_id == 3
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
    //METODO PARA TRAER USUARIO CON NOMBRE DE ROL, ESTADO Y NOMBRE DE BUSQUEDA

    public List<EncapUsuario> ObtenerEmpleadosNombre(string nombre)
    {
        using (var db = new Mapeo())
        {
            return (
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario
                    where (usu.Rol_id == 2 || usu.Rol_id == 3) && (usu.Nombre == nombre)
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

    //METODO PARA OBTENER LOS ROLES DEL EMPLEADO
    public List<EncapRol> ObtenerRoles()
    {
        using (var db = new Mapeo())
        {
            return db.rol.ToList();
        }
    }

    //METODO PARA OBTENER LOS ESTADOS DE LOS USUARIOS 
    public List<EncapEstado> ObtenerEstados()
    {
        using (var db = new Mapeo())
        {
            return db.estado.ToList();
        }
    }

    //METODO PARA ACTUALIZAR EMPLEADO
    public void actualizarEmpleado(EncapUsuario empleado)
    {
        using (var db = new Mapeo())
        {
            EncapUsuario encapUsuario = db.usuario.Where(x => x.User_id == empleado.User_id).First();

            encapUsuario.Nombre = empleado.Nombre;
            encapUsuario.Apellido = empleado.Apellido;
            encapUsuario.Correo = empleado.Correo;
            encapUsuario.Identificacion = empleado.Identificacion;
            encapUsuario.Rol_id = empleado.Rol_id;
            encapUsuario.Estado_id = empleado.Estado_id;
            encapUsuario.Fecha_nacimiento = empleado.Fecha_nacimiento;

            db.usuario.Attach(encapUsuario);
            var entry = db.Entry(encapUsuario);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }

    //###################################################################################################################//
    //METODO PARA INSERTAR UN ITEM INVENTARIO
    public void InsertarItem(EncapInventario invent)
    {
        using (var db = new Mapeo())
        {
            db.inventario.Add(invent);
            db.SaveChanges();
        }
    }

    //METODO CONSULTAR INVENTARIO
    public List<EncapInventario> ConsultarInventario()
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,
                        estadoitem,

                        _cantCarrito


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,

                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }).ToList();
        }
    }
    //METODO ACTUALIZAR TABLA EN EL INVENTARIO
    public void ActualizarInventario(EncapInventario invent)
    {
        using (var db = new Mapeo())
        {
            var resultado = db.inventario.SingleOrDefault(x => x.Id == invent.Id);
            if (resultado != null)
            {
                resultado.Titulo = invent.Titulo;
                resultado.Imagen = invent.Imagen;
                resultado.Referencia = invent.Referencia;
                resultado.Precio = invent.Precio;
                resultado.Ca_actual = invent.Ca_actual;
                resultado.Ca_minima = invent.Ca_minima;
                resultado.Id_marca = invent.Id_marca;
                resultado.Id_estado = invent.Id_estado;
                resultado.Id_categoria = invent.Id_categoria;

                db.SaveChanges();
            }
        }

    }
    //ACTUALIZAR CON IMAGEN EN EL INVENTARIO 
    public void ActualizarReferencia(EncapInventario invent)
    {
        using (var db = new Mapeo())
        {
            var resultado = db.inventario.SingleOrDefault(x => x.Referencia == invent.Referencia);
            if (resultado != null)
            {
                resultado.Titulo = invent.Titulo;

                resultado.Referencia = invent.Referencia;
                resultado.Precio = invent.Precio;
                resultado.Ca_actual = resultado.Ca_actual + invent.Ca_actual;
                resultado.Ca_minima = invent.Ca_minima;
                resultado.Id_marca = invent.Id_marca;
                resultado.Id_estado = invent.Id_estado;
                resultado.Imagen = invent.Imagen;

                db.SaveChanges();
            }
        }

    }


    //METODO CONSULATAR REFERENCIA
    public List<EncapInventario> BuscarReferencia(string a)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.inventario.Where(x => x.Referencia == a)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,

                        estadoitem


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual,
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item




                    }).ToList();
        }
    }
    //METODO DE CONSULTAR ITEM CON ID_MARCA
    public List<EncapInventario> BuscarMarca(int marca)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Id_marca == marca)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,

                        estadoitem


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual,
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item




                    }).ToList();
        }
    }


    //METODO DE CONSULTAR ITEM MARCA Y CATEGORIA
    public List<EncapInventario> BuscarMarcaCategoria(int marca, int categ)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario.Where(x => x.Id_marca == marca && x.Id_categoria == categ)
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,

                        estadoitem


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual,
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }).ToList();
        }
    }
    //METODO DE CONSULTAR ITEM CON ID_Categoria
    public List<EncapInventario> BuscarCategoria(int categ)
    {
        using (var db = new Mapeo())
        {


            return (from uu in db.inventario.Where(x => x.Id_categoria == categ)

                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,

                        estadoitem


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual,
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,

                        Nombre_categoria = m.categoria.Categoria,
                        Nombre_marca = m.marca_carro.Marca,

                        Estado = m.estadoitem.Estado_item





                    }).ToList();
        }
    }

    //METODO CONSULTAR IMAGEN I++
    public EncapInventario BuscarInventario(EncapInventario inventario, string a)
    {
        using (var db = new Mapeo())
        {
            return db.inventario.Where(x => x.Referencia == a).FirstOrDefault();
        }
    }
    public EncapInventario BuscarId(EncapInventario inventario, int a)
    {
        using (var db = new Mapeo())
        {
            return db.inventario.Where(x => x.Id == a).FirstOrDefault();
        }
    }

    //METODO ELIMINAR ITEM DEL INVENTARIO
    public void EliminarItem(EncapInventario invent)
    {
        using (var db = new Mapeo())
        {
            db.inventario.Attach(invent);

            var entry = db.Entry(invent);
            entry.State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
    //METODO CONSULTAR MARCA DE INVENTARIO
    public List<EncapMarca> ColsultarMarca()
    {
        using (var db = new Mapeo())
        {
            return db.marca_carro.OrderBy(x => x.Id).ToList();
        }
    }
    public List<EncapMarca> ColsultarMarca2()
    {
        using (var db = new Mapeo())
        {
            return db.marca_carro.Where(x => x.Id >= 1).ToList();
        }
    }
    //METODO CONSULTAR CATEGORIA DE INVENTARIO 
    public List<EncapCategoria> ColsultarCategoria()
    {
        using (var db = new Mapeo())
        {
            return db.categoria.OrderBy(x => x.Id).ToList();
        }
    }
    public List<EncapCategoria> ColsultarCategoria2()
    {
        using (var db = new Mapeo())
        {
            return db.categoria.OrderBy(x => x.Id >= 1).ToList();
        }
    }
    //METODO CONSULTAR ESTADO DE INVENTARIO 
    public List<EncapEstadoItem> ColsultarEstado()
    {
        using (var db = new Mapeo())
        {
            return db.estado_item.ToList();
        }
    }
    //METODO CONSULTAR USUARIO ACTIVO
    public EncapUsuario UsuarioActivo2(string correo)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo == correo).FirstOrDefault();
        }
    }
    public EncapUsuario UsuarioActivo(string sesion)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Sesion == sesion).FirstOrDefault();
        }
    }
    //METODO DE CONSULTAR ITEM QUE TIENE CANTIDAD CRITICA
    public List<EncapInventario> ConsultarAlertas()
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.inventario where uu.Ca_actual <= uu.Ca_minima
                    join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                    join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                    join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                    select new
                    {
                        uu,
                        marca_carro,
                        categoria,

                        estadoitem


                    }).ToList().Select(m => new EncapInventario
                    {
                        Id = m.uu.Id,
                        Imagen = m.uu.Imagen,
                        Titulo = m.uu.Titulo,
                        Precio = m.uu.Precio,
                        Referencia = m.uu.Referencia,
                        Ca_actual = m.uu.Ca_actual,
                        Ca_minima = m.uu.Ca_minima,
                        Id_marca = m.uu.Id_marca,
                        Id_categoria = m.uu.Id_categoria,
                        Id_estado = m.uu.Id_estado,


                        Nombre_categoria = m.categoria.Categoria,


                        Estado = m.estadoitem.Estado_item
                    }).ToList();
        }
    }

    //METODO PARAMETRO DE TIMEPO CARRITO

    public void ActualizarTiempoCarrito(EncapParametros tiempocarrito)
    {
        using (var db = new Mapeo())
        {
            EncapParametros resultado = db.parametros.Where(x => x.Id == tiempocarrito.Id).First();
            if (resultado != null)
            {
                resultado.Valor = tiempocarrito.Valor;
                db.SaveChanges();
            }

        }

    }
    //METODO CONSULTAR PROVEEDOR
    public List<EncapProveedor> ColsultarProveedor()
    {
        using (var db = new Mapeo())
        {
            return db.proveedor.ToList();
        }
    }
    public List<EncapProveedor> ColsultarProveedor2()
    {
        using (var db = new Mapeo())
        {
            return db.proveedor.Where(x => x.Id > 0).OrderBy(x => x.Id >= 1).ToList();
        }
    }
    //METODO ACTUALIZAR Proveedor
    public void ActualizarProveedor(EncapProveedor proveedor)
    {
        using (var db = new Mapeo())
        {
            var resultado = db.proveedor.SingleOrDefault(x => x.Id == proveedor.Id);
            if (resultado != null)
            {
                resultado.Nombre_pro = proveedor.Nombre_pro;
                resultado.Contacto = proveedor.Contacto;
                resultado.Correo = proveedor.Correo;
                resultado.Tiempo_envio = proveedor.Tiempo_envio;
                resultado.Nid = proveedor.Nid;
                resultado.Session = proveedor.Session;
                resultado.Last_modify = proveedor.Last_modify;


                db.SaveChanges();
            }
        }

    }
    public List<EncapProductoProveedor> ColsultarP(int pro)
    {
        using (var db = new Mapeo())
        {
            return db.producto_proveedor.Where(x => x.Producto_id == pro).ToList();
        }
    }
    public List<EncapPedidoProveedor> ColsultarPPedido()
    {
        using (var db = new Mapeo())
        {
            return db.pedido_proveedor.ToList();
        }
    }

    //METODO DE AGREGAR PEDIDO PROVEEDOR
    public void InsertarPedidoProveedor(EncapPedidoProveedor pedido)
    {
        using (var db = new Mapeo())
        {
            db.pedido_proveedor.Add(pedido);
            db.SaveChanges();
        }
    }

    public List<EncapPedidoProveedor> ConsultarPedidoProveedor()
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.pedido_proveedor.Where(x => x.Id > 0)

                    join prov in db.proveedor on uu.Id_proveedor equals prov.Id
                    join est in db.estado_pedido_proveedor on uu.Id_estado equals est.Id
                    select new
                    {
                        uu,

                        prov,
                        est


                    }).ToList().Select(m => new EncapPedidoProveedor
                    {

                        Id = m.uu.Id,

                        Id_proveedor = m.uu.Id_proveedor,


                        Elementos = m.uu.Elementos,
                        T_entrega = m.uu.T_entrega,
                        Valor = m.uu.Valor,
                        Id_estado = m.uu.Id_estado,
                        Nombre_proveedor = m.prov.Nombre_pro,

                        Estado = m.est.Estado




                    }
                      ).ToList();
        }
    }
    //METODO INSERTAR Proveedor
    public void InsertarProveedor(EncapProveedor pro)
    {
        using (var db = new Mapeo())
        {
            db.proveedor.Add(pro);
            db.SaveChanges();
        }
    }
    //METODO INSERTAR PRODUCTO Proveedor
    public void InsertarProductoProveedor(EncapProductoProveedor pp)
    {
        using (var db = new Mapeo())
        {
            db.producto_proveedor.Add(pp);
            db.SaveChanges();
        }
    }
    //METODO CONSULTAR PRODUCTOS VINCULADOS AL PROVEEDOR
    public List<EncapProductoProveedor> ConsultarProductoProveedor(int pro)
    {
        using (var db = new Mapeo())
        {
            return (from uu in db.producto_proveedor where uu.Proveedor_id == pro
                    join iven in db.inventario on uu.Producto_id equals iven.Id
                    select new
                    {
                        uu,
                        iven

                    }).ToList().Select(m => new EncapProductoProveedor
                    {

                        Id = m.uu.Id,
                        Producto_id = m.uu.Producto_id,
                        Proveedor_id = m.uu.Producto_id,
                        Cantidad = m.uu.Cantidad,
                        Precio = m.uu.Precio,
                        Last_modify = m.uu.Last_modify,
                        Session = m.uu.Session,
                        Referencia = m.iven.Referencia,
                        Nombre_producto = m.iven.Titulo




                    }
                      ).ToList();
        }
    }
    //ACTUALIZAR PRODUCTO PROVEEDOR
    public void ActualizarProductoProveedor(EncapProductoProveedor producto)
    {
        using (var db = new Mapeo())
        {
            var resultado = db.producto_proveedor.SingleOrDefault(x => x.Id == producto.Id);
            if (resultado != null)
            {
                resultado.Nombre_producto = producto.Nombre_producto;
                resultado.Cantidad = producto.Cantidad;
                resultado.Precio = producto.Precio;
                resultado.Producto_id = producto.Producto_id;
                resultado.Proveedor_id = producto.Proveedor_id;
                resultado.Session = producto.Session;
                resultado.Last_modify = producto.Last_modify;


                db.SaveChanges();
            }
        }

    }
    //METODO DE AGREGAR A AUX
    public void InsertarAux(producto pp)
    {
        using (var db = new Mapeo())
        {
            db.aux.Add(pp);
            db.SaveChanges();
        }
    }
    //METODO ELIMINAR ITEM DEL INVENTARIO
    public void LimpiarAux()
    {
        using (var db = new Mapeo())
        {


            var entry = from c in db.aux select c;

            db.aux.RemoveRange(entry);
            db.SaveChanges();
        }


    }
    public List<producto> ColsultarAux()
    {
        using (var db = new Mapeo())
        {
            return db.aux.ToList();
        }
    }
    //Metodo para eliminar el proveedor
    public void EliminarProveedor(EncapProveedor proveedor)
    {

        using (var db = new Mapeo())
        {
            db.proveedor.Attach(proveedor);

            //hacer borrado en
            //lista de productos a eliminar
            var producto_eliminar = db.producto_proveedor.Where(x => x.Proveedor_id == proveedor.Id);

            var entry = db.Entry(proveedor);
            entry.State = EntityState.Deleted;

            db.producto_proveedor.RemoveRange(producto_eliminar);

            db.SaveChanges();
        }
    }
    //Metodo QUE BUSCA LA REFERENCIA EN producto_proveedor
    public List<EncapProductoProveedor> ConsultarReferenciaProductoProveedor(int pro, string refe)
    {
        using (var db = new Mapeo())
        {
            EncapInventario inve = new EncapInventario();
            inve = new DAOAdmin().BuscarInventario(inve, refe);
            return (from uu in db.producto_proveedor.Where(x => x.Proveedor_id == pro && x.Producto_id == inve.Id)
                    join iven in db.inventario on uu.Producto_id equals iven.Id
                    select new
                    {
                        uu,
                        iven

                    }).ToList().Select(m => new EncapProductoProveedor
                    {

                        Id = m.uu.Id,
                        Producto_id = m.uu.Producto_id,
                        Proveedor_id = m.uu.Producto_id,
                        Cantidad = m.uu.Cantidad,
                        Precio = m.uu.Precio,
                        Last_modify = m.uu.Last_modify,
                        Session = m.uu.Session,
                        Referencia = m.iven.Referencia,
                        Nombre_producto = m.iven.Titulo




                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A LAS FECHAS DE BUSQUEDA
    public List<EncapPedido> ConsultarVentasDia(int dia)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Day == dia)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A LAS FECHAS DE BUSQUEDA
    public List<EncapPedido> ConsultarVentas()
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id

                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,

                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado,
                        Empleado = m.empleado.Nombre,

                    }
                      ).ToList();
        }
    }
    public List<EncapUsuario> ConsultarEmpleado()
    {
        using (Mapeo db = new Mapeo()) {
            return db.usuario.Where(x => x.Rol_id == 2).ToList();
        }
    }
    //
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A MES
    public List<EncapPedido> ConsultarVentasMes(int mes)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Month == mes)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A MES Y DIA
    public List<EncapPedido> ConsultarVentasMesDia(int mes, int dia)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Month == mes && x.Fecha_pedido.Day == dia)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A AÑO
    public List<EncapPedido> ConsultarVentasAno(int ano)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }

    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A AÑO Y Dia
    public List<EncapPedido> ConsultarVentasAnoDia(int ano, int dia)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano && x.Fecha_pedido.Day == dia)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A AÑO,MES Y DIA 
    public List<EncapPedido> ConsultarVentasAnoMesDia(int ano, int mes, int dia)
    {
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano &&
                    x.Fecha_pedido.Month == mes && x.Fecha_pedido.Day == dia)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A AÑO,MES Y DIA 
    public List<EncapPedido> ConsultarVentasAnoMesDiaEmpleado(int ano, int mes, int dia, int emp)


    {
        string Query = "";
        //solo Empleado
        if (ano == 0 && mes == 0 && dia == 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id = " + emp;
        }
        //empleado y Dia
        if (ano == 0 && mes == 0 && dia != 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                   " AND to_char(fecha_pedido, 'DD')::integer = " + dia;

        }
        //empleado dia y mes
        if (ano == 0 && mes != 0 && dia != 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 5 AND atendido_id =" + emp +
                   " AND to_char(fecha_pedido, 'DD')::integer = " + dia +
                   " AND  to_char(fecha_pedido, 'MM')::integer =" + mes;
        }
        //empleado y mes
        if (ano == 0 && mes != 0 && dia == 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +

                   " AND  to_char(fecha_pedido, 'MM')::integer =" + mes;
        }
        //empleado y año
        if (ano != 0 && mes == 0 && dia == 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +

                   " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
        }

        //empleado año y dia
        if (ano != 0 && mes == 0 && dia != 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                " AND to_char(fecha_pedido, 'DD')::integer = " + dia +
                   " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
        }
        //empleado mes y ano
        if (ano != 0 && mes != 0 && dia == 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                " AND to_char(fecha_pedido, 'MM')::integer = " + mes +
                   " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
        }
        //Combinado
        if (ano != 0 && mes != 0 && dia != 0 && emp != 0)
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                 " AND to_char(fecha_pedido, 'DD')::integer = " + dia +
                " AND to_char(fecha_pedido, 'MM')::integer = " + mes +

                   " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
        }
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.SqlQuery(Query)

                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }
    }
    //METODO DE BUSCAR EL HISTORIA DE VENTAS DEACUEDO A AÑO Y Mes


    
        public List<EncapPedido> ConsultarPedidos()
    {
        using (var db = new Mapeo())
        {

           

            return (from uu in db.pedidos
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join domi in db.usuario on uu.Domiciliario_id equals domi.User_id
                                        select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado,
                        domi

                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Domiciliaro = m.domi.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado,
                        Empleado = m.empleado.Nombre,
                        
                    }
                      ).ToList();
        }

    }

    public List<EncapPedido> ConsultarPedidosEstado(int est)
    {
        using (var db = new Mapeo())
        {



            return (from uu in db.pedidos.Where(x => x.Estado_pedido == est)
                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join domi in db.usuario on uu.Domiciliario_id equals domi.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado,
                        domi


                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Domiciliaro = m.domi.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado,
                        Empleado = m.empleado.Nombre,

                    }
                      ).ToList();
        }

    }

    //MEDOTO VENTAS MES AÑO
        public List<EncapPedido> ConsultarVentasAnMes(int ano, int mes)
        {
        string Query = "";
        if (ano != 0 && mes != 0 )
        {
            Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 "+
                " AND to_char(fecha_pedido, 'MM')::INTEGER = " + mes +
                   " AND to_char(fecha_pedido, 'YYYY')::INTEGER =" + ano;
        }
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano && x.Fecha_pedido.Month == mes)

                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                    join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                    join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                    select new
                    {
                        uu,
                        usuario,
                        estado,
                        empleado
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                        User_id = m.usuario.User_id,
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                        Empleado = m.empleado.Nombre,
                        Usuario = m.usuario.Nombre,
                        Estado = m.estado.Estado

                    }
                      ).ToList();
        }

    }

    public List<EncapPedido> ConsultarVentasMesAMes(int ano, int mes)
    {
        string Query = "";
      
            Query = "SELECT date_part('year', pp.fecha_pedido) as año, date_part('month'::text, pp.fecha_pedido)"+
                        "as mes, sum(pp.total) as total_mes, Count(*) as Facturas" +
                        "FROM pedidos.pedidos pp" +
                        "WHERE pp.estado_pedido = 6" +
                        " GROUP BY date_part('year', pp.fecha_pedido), date_part('month'::text, pp.fecha_pedido)";
        
        using (var db = new Mapeo())
        {

            return (from uu in db.pedidos.SqlQuery(Query)

                    join usuario in db.usuario on uu.User_id equals usuario.User_id
                  
                    select new
                    {
                        uu
                       
                    }).ToList().Select(m => new EncapPedido
                    {

                        Id = m.uu.Id,
                       
                        Atendido_id = m.uu.Atendido_id,
                        Domiciliario_id = m.uu.Domiciliario_id,
                        Fecha_pedido = m.uu.Fecha_pedido,
                        Estado_pedido = m.uu.Estado_pedido,
                        Total = m.uu.Total,
                      

                    }
                      ).ToList();
        }

    }
}
