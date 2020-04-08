using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

/// <summary>
/// Descripción breve de MAC_IP
/// </summary>
public class MAC_IP
{
    public String mac()
    {

        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        String sMacAddress = string.Empty;

        foreach (NetworkInterface adapter in nics)
        {

            if (sMacAddress == String.Empty) //solo devuelve la dirección MAC de la primera tarjeta
            {

                IPInterfaceProperties properties = adapter.GetIPProperties();

                sMacAddress = adapter.GetPhysicalAddress().ToString();

            }

        }
        return sMacAddress;

    }


    public String ip()
    {
        string IP4Address = String.Empty;// Declaramos cadena vacia

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily == AddressFamily.InterNetwork)
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }
}