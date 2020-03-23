using System;
using System.Collections.Generic;
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
                db.SaveChanges();
            }

        }

    }


}