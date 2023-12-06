using ClimaTes.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ClimaTes.Services
{
    public static class ApiService
    {
        // Creamos el método GetClima
        public static async Task<Root> GetClima(double latitud, double longitud)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(10);

                    var apiUrl = $"https://api.tutiempo.net/json/?lan=es&apid=4sTXXX4zzXagZ0z&ll=21.943820, -78.432878";

                    Debug.WriteLine($"[ApiService] URL de la solicitud: {apiUrl}");

                    var response = await httpClient.GetStringAsync(apiUrl);

                    Debug.WriteLine($"[ApiService] Respuesta del servidor: {response}");

                    var result = JsonConvert.DeserializeObject<Root>(response);

                    if (result != null)
                    {
                        Debug.WriteLine("[ApiService] Objeto deserializado: " + result);
                        return result;
                    }
                    else
                    {
                        Debug.WriteLine("[ApiService] Objeto deserializado es nulo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[ApiService] Error: {ex.Message}");
                throw;
            }

            return null;
        }
    }
}