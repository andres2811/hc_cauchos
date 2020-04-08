﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAdmin
/// </summary>
public class DAOAdmin
{
   public EncapUsuario loginEntity(EncapUsuario user)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(user.Correo) && x.Clave.Equals(user.Clave)).FirstOrDefault();
        }

    }
    public EncapUsuario BuscarCorreo(string correo)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(correo) ).FirstOrDefault();
        }

    }

    public EncapUsuario BuscarToken(string token)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Token.Equals(token) && x.Estado_id == 2).FirstOrDefault();
        }

    }

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
                resultado.Tiempo_token = user.Tiempo_token;
                resultado.Sesion = user.Sesion;
                resultado.Last_modify = DateTime.Now;
                resultado.Ip_ = user.Ip_;
                resultado.Mac_ = user.Mac_;

                db.SaveChanges();
            }

        }

    }

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

    //METODO PARA TRAER USUARIO CON NOMBRE DE ROL Y ESTADO }

    public List<EncapUsuario> ObtenerEmpleados()
    {
        using (var db = new Mapeo())
        {
            return (                
                    //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                    from usu in db.usuario where usu.Rol_id==2 || usu.Rol_id==3
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

    //METODO PARA ELIMINAR UN EMPLEADO
    public void EliminarEmpleado(EncapUsuario emple)
    {
        using (var db = new Mapeo())
        {
            db.usuario.Attach(emple);
            var entry = db.Entry(emple);
            entry.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }

    //METODO PARA OBTENER LOS ROLES 
    public List<EncapRol> ObtenerRoles()
    {
        using (var db = new Mapeo())
        {
            return db.rol.ToList();
        }
    }

    //METODO PARA OBTENER LOS ESTADOS
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

            db.usuario.Attach(encapUsuario);
            var entry = db.Entry(encapUsuario);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
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

                        Estado =m.estadoitem.Estado_item
                        
                        
                        


                    }).ToList();


        }
    }
    //METODO ACTUALIZAR TABLA
    public void ActualizarInventario(EncapInventario invent )
    {
        using (var db = new Mapeo())
        {
            var resultado = db.inventario.SingleOrDefault(x => x.Id == invent.Id);
            if (resultado != null)
            {
                resultado.Titulo = invent.Titulo;
                
                resultado.Referencia = invent.Referencia;
                resultado.Precio = invent.Precio;
                resultado.Ca_actual = invent.Ca_actual;
                resultado.Ca_minima = invent.Ca_minima;
                resultado.Id_marca = invent.Id_marca;
                resultado.Id_estado = invent.Id_estado;
                
                db.SaveChanges();
            }
        }

    }
    //ACTUALIZAR CON IMAGEN
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
    //METODO CONSULATR IMAGEN I++
    public EncapInventario BuscarInventario(EncapInventario inventario,string a)
    {
        using (var db = new Mapeo())
        {
            return db.inventario.Where(x => x.Referencia == a).FirstOrDefault();
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
    //METODO CONSULTAR MARCA
    public List<EncapMarca> ColsultarMarca()
    {
        using(var db = new Mapeo())
        {
           return db.marca_carro.ToList();
        }
    }
    //METODO CONSULTAR CATEGORIA
    public List<EncapCategoria> ColsultarCategoria()
    {
        using (var db = new Mapeo())
        {
            return db.categoria.ToList();
        }
    }
    //METODO CONSULTAR EStado
    public List<EncapEstadoItem> ColsultarEstado()
    {
        using (var db = new Mapeo())
        {
            return db.estado_item.ToList();
        }
    }
    //METODO CONSULTAR USUARIO ACTIVO
    public EncapUsuario UsuarioActivo(string sesion)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Sesion == sesion).FirstOrDefault();
        }
    }
}