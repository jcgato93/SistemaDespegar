using Despegar.Entity;
using Despegar.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despegar.Services
{
    public static class CuartoService
    {

        public static List<Cuartos> GetCuartosHotel1()
        {
            var client = new RestClient("http://localhost:5085");

            var request = new RestRequest("Cuartos/IndexJson", Method.GET);

            
            IRestResponse<List<Cuartos>> response = client.Execute<List<Cuartos>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return  response.Data; // raw content as string
            }
            else
            {
                return null;
            }

            
        }

        public static List<Cuartos> GetCuartosHotel2()
        {
            var client = new RestClient("http://localhost:5084");

            var request = new RestRequest("Cuartos/IndexJson", Method.GET);


            IRestResponse<List<Cuartos>> response = client.Execute<List<Cuartos>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }

        public static bool SaveReservaHotel1(Reserva reserva)
        {
            var client = new RestClient("http://localhost:5085");

            var request = new RestRequest("Reservas/CreateJson", Method.POST);
            request.AddParameter("reservas",new {
                reserva.CuartoId,
                reserva.CantidadPersonas,
                reserva.DiasReserva,
                reserva.FechaReserva,
                reserva.Cliente.Email,
                reserva.IdentificacionCliente
            });

            request.AddJsonBody(new
            {
                reserva.CuartoId,
                reserva.CantidadPersonas,
                reserva.DiasReserva,
                reserva.FechaReserva,
                reserva.Cliente.Email,
                reserva.IdentificacionCliente
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static bool SaveReservaHotel2(Reserva reserva)
        {
            var client = new RestClient("http://localhost:5084");

            var request = new RestRequest("Reservas/CreateJson", Method.POST);
            request.AddParameter("reservas", new
            {
                reserva.CuartoId,
                reserva.CantidadPersonas,
                reserva.DiasReserva,
                reserva.FechaReserva,
                reserva.Cliente.Email,
                reserva.IdentificacionCliente
            });

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
