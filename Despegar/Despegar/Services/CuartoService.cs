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
            var client = new RestClient("http://hotela.azurewebsites.net");

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

        public static int? SaveReservaHotel1(Reserva reserva)
        {
            var client = new RestClient("http://hotela.azurewebsites.net");

            var request = new RestRequest("Reservas/CreateJson", Method.POST);
           

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
            

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return int.Parse(response.Content);
            else
                return null;
        }

        public static int? SaveReservaHotel2(Reserva reserva)
        {
            var client = new RestClient("http://localhost:5084");

            var request = new RestRequest("Reservas/CreateJson", Method.POST);
            request.AddJsonBody( new
            {
                reserva.CuartoId,
                reserva.CantidadPersonas,
                reserva.DiasReserva,
                reserva.FechaReserva,
                NombreCliente = reserva.Cliente.Email,
                reserva.IdentificacionCliente
            });

            IRestResponse response = client.Execute(request);
            

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return int.Parse(response.Content);
            else
                return null;
        }

        public static bool DeleteReservaHotel1(int reservaId)
        {
            var client = new RestClient("http://hotela.azurewebsites.net");

            var request = new RestRequest("Reservas/DeleteJson", Method.POST);
            request.AddParameter("id", reservaId);

            IRestResponse response = client.Execute(request);
            

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static bool DeleteReservaHotel2(int reservaId)
        {
            var client = new RestClient("http://localhost:5084");

            var request = new RestRequest("Reservas/DeleteJson", Method.POST);
            request.AddParameter("id", reservaId);

            IRestResponse response = client.Execute(request);
            

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
