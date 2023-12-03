using ClimaTes.Models;
using ClimaTes.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClimaTes
{
    public partial class Climapag : ContentPage
    {
        public Climapag()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var result = await ApiService.GetClima(40.4178, -3.7022);

                Debug.WriteLine($"Locality: {result.locality?.name}");
                Debug.WriteLine($"Hour1 Text: {result.hour_hour?.hour1?.text}");

                if (result != null && result.hour_hour != null && result.hour_hour.hour1 != null &&
                    result.information != null)
                {

                    List<ClimaList> climalists = new List<ClimaList>();
                    for (int i = 1; i <= 10; i++)
                    {
                        climalists.Add(new ClimaList
                        {
                            Imagen = "clima" + result.hour_hour.GetType().GetProperty($"hour{i}")?.GetValue(result.hour_hour)?.GetType().GetProperty("icon")?.GetValue(result.hour_hour.GetType().GetProperty($"hour{i}")?.GetValue(result.hour_hour)),
                            Temperatura = result.hour_hour.GetType().GetProperty($"hour{i}")?.GetValue(result.hour_hour)?.GetType().GetProperty("temperature")?.GetValue(result.hour_hour.GetType().GetProperty($"hour{i}")?.GetValue(result.hour_hour))?.ToString(),
                            Hora = result.hour_hour.GetType().GetProperty($"hour{i}")?.GetValue(result.hour_hour)?.GetType().GetProperty("hour_data")?.GetValue(result.hour_hour.GetType().GetProperty($"hour{i}")?.GetValue(result.hour_hour))?.ToString()
                        });
                    }

                    // No puedes asignar dos veces las propiedades Temperatura y Hora en esta l�nea.
                    // Adem�s, la �ltima l�nea est� fuera del bucle, por lo que est� configurando la Temperatura y Hora para la hora 25 (fuera del rango).
                    // Cambi� la �ltima l�nea para que tenga solo una asignaci�n.
                    // Si deseas mostrar datos para la hora 25, puedes agregar otra entrada al climalists o hacerlo por separado.

                    CvTiempo.ItemsSource = climalists;

                    LblCiudad.Text = result.locality.name;
                    LblClima.Text = result.hour_hour.hour1.text;
                    LblPais.Text = result.locality.country;
                    LblTemperatura.Text = $"{result.hour_hour.hour1.temperature}{result.information.temperature}";
                    LblHumedad.Text = $"{result.hour_hour.hour1.humidity}{result.information.humidity}";
                    LblViento.Text = $"{result.hour_hour.hour1.wind}{result.information.wind}";
                    ImgHumedadIcon.Source = "humedadicon.png";
                    ImgVientoIcon.Source = "vientoicon.png";
                    ImgClimaIcon.Source = "clima" + result.hour_hour.hour1.icon;
                }
                else
                {
                    // Puedes manejar el caso donde los datos no son v�lidos o est�n incompletos
                    // ...
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepci�n aqu�, ya sea registr�ndola, mostrando un mensaje al usuario, etc.
                Debug.WriteLine($"Error en OnAppearing: {ex.Message}");
            }
        }

        public class ClimaList
        {
            public string Imagen { get; set; }
            public string Temperatura { get; set; }
            public string Hora { get; set; }
        }
    }
}