using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOUser
/// </summary>
public class DAOUser
{
    public void InsertarUsuario(EncapUsuario user)
    {
        using(var db= new Mapeo())
        {
            db.usuario.Add(user);
            db.SaveChanges();  
        }
    }

    public EncapUsuario verificarCorreo(EncapUsuario verificar)
    {
        using (var db = new Mapeo())
        {
            return db.usuario.Where(x => x.Correo.Equals(verificar.Correo)).FirstOrDefault();
        }
    }

}