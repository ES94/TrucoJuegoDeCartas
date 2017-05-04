using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TrucoJuegoDeCartas.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void EnviarMensajeGlobal(string nombre, string mensaje)
        {
            Clients.All.mostrarMensaje(nombre, mensaje);
        }

        public void EnviarMensajeEquipo(string nombre, string mensaje)
        {
            Clients.Caller.mostrarMensaje(nombre, mensaje);
        }
    }
}