using ClimaTes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;



namespace ClimaTes.Services
{
    public class ApiService
    {
        public static async Task<Root> GetClima(double latitud, double longitud)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = $"https://api.tutiempo.net/json/?lang=es&apid=qCDza4qzz4z83Z0&ll={latitud},{longitud}";
                    var response = await httpClient.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<Root>(response);
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí, ya sea registrándola, mostrando un mensaje al usuario, etc.
                Debug.WriteLine($"Error en GetClima: {ex.Message}");
                return null; // O manejar el error de otra manera según tus necesidades
            }
        }
    }
}
