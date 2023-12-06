using ClimaTes.Models;//importamos el espacion de nombres que contiene la clase Root
using ClimaTes.Services;//importamos  el espacio de nombres que contiene la clase ApiService
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace ClimaTes
{   
    //definimos una clase parcial llamada Climapag que probablemente 
    public partial class Climapag : ContentPage
    {   
        //declaramos variables de instancia para almacenar la latutud y longitud
        private double latitud;
        private double longitud;

        //constructor de la clase Climapag
        public Climapag()
        {
            InitializeComponent();
            BindingContext = this;//Establecemos el contexto de enlace como la instancia actual de la pagina
        }

        // Método llamado cuando la página está a punto de aparecer en la pantalla
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {   //llamamos al metodo GetLocationAsync para obtener la ubicacion actual del dispositivo
                await GetLocationAsync();

                //llamamos al metodo GetClima del servicio ApiService para obtener datos climaticos utilizando las coordenadas
                var result = await ApiService.GetClima(21.943820, -78.432878);

                //imprimimos en la consola de depuracion la respuesta de la API
                Debug.WriteLine($"Respuesta de la API: {result}");

                //verificamos si los datos recibidos son validos y contienen la informacion esperada
                if (result != null && result.hour_hour != null && result.information != null)
                {   
                    //Creamos una lista de objetos ClimaList para mostrar en un control de vista de coleccion
                    List<ClimaList> climalists = new List<ClimaList>()
                    {
                         new ClimaList {Imagen="clima"+result.hour_hour.hour1.icon, Temperatura=result.hour_hour.hour1.temperature.ToString(), Hora=result.hour_hour.hour1.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour2.icon, Temperatura=result.hour_hour.hour2.temperature.ToString(), Hora=result.hour_hour.hour2.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour3.icon, Temperatura=result.hour_hour.hour3.temperature.ToString(), Hora=result.hour_hour.hour3.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour4.icon, Temperatura=result.hour_hour.hour4.temperature.ToString(), Hora=result.hour_hour.hour4.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour5.icon, Temperatura=result.hour_hour.hour5.temperature.ToString(), Hora=result.hour_hour.hour5.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour6.icon, Temperatura=result.hour_hour.hour6.temperature.ToString(), Hora=result.hour_hour.hour6.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour7.icon, Temperatura=result.hour_hour.hour7.temperature.ToString(), Hora=result.hour_hour.hour7.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour8.icon, Temperatura=result.hour_hour.hour8.temperature.ToString(), Hora=result.hour_hour.hour8.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour9.icon, Temperatura=result.hour_hour.hour9.temperature.ToString(), Hora=result.hour_hour.hour9.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour10.icon, Temperatura=result.hour_hour.hour10.temperature.ToString(), Hora= result.hour_hour.hour10.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour11.icon, Temperatura=result.hour_hour.hour11.temperature.ToString(), Hora= result.hour_hour.hour11.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour12.icon, Temperatura=result.hour_hour.hour12.temperature.ToString(), Hora= result.hour_hour.hour12.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour13.icon, Temperatura=result.hour_hour.hour13.temperature.ToString(), Hora= result.hour_hour.hour13.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour14.icon, Temperatura=result.hour_hour.hour14.temperature.ToString(), Hora= result.hour_hour.hour14.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour15.icon, Temperatura=result.hour_hour.hour15.temperature.ToString(), Hora= result.hour_hour.hour15.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour16.icon, Temperatura=result.hour_hour.hour16.temperature.ToString(), Hora= result.hour_hour.hour16.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour17.icon, Temperatura=result.hour_hour.hour17.temperature.ToString(), Hora= result.hour_hour.hour17.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour18.icon, Temperatura=result.hour_hour.hour18.temperature.ToString(), Hora= result.hour_hour.hour18.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour19.icon, Temperatura=result.hour_hour.hour19.temperature.ToString(), Hora= result.hour_hour.hour19.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour20.icon, Temperatura=result.hour_hour.hour20.temperature.ToString(), Hora= result.hour_hour.hour20.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour21.icon, Temperatura=result.hour_hour.hour21.temperature.ToString(), Hora= result.hour_hour.hour21.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour22.icon, Temperatura=result.hour_hour.hour22.temperature.ToString(), Hora= result.hour_hour.hour22.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour23.icon, Temperatura=result.hour_hour.hour23.temperature.ToString(), Hora= result.hour_hour.hour23.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour24.icon, Temperatura=result.hour_hour.hour24.temperature.ToString(), Hora= result.hour_hour.hour24.hour_data},
                         new ClimaList {Imagen="clima"+result.hour_hour.hour25.icon, Temperatura=result.hour_hour.hour25.temperature.ToString(), Hora= result.hour_hour.hour25.hour_data},
                    };
                    
                    //establecemos la fuente de datos para un control de vista de coleccion con la lista creada
                    CvTiempo.ItemsSource = climalists;

                    //Imprimimos en la consola el numero de elementos en la lista
                    Debug.WriteLine($"Número de elementos en climalists: {climalists.Count}");

                    //Actualizamo etiquetas en la interfaz de usuario con informacion de la respuesta de la API
                    LblCiudad.Text = result.locality.name;
                    LblClima.Text = result.hour_hour.hour1.text;
                    LblPais.Text = result.locality.country;
                    LblTemperatura.Text = result.hour_hour.hour1.temperature + result.information.temperature;
                    LblHumedad.Text = result.hour_hour.hour1.humidity + result.information.humidity;
                    LblViento.Text = result.hour_hour.hour1.wind + result.information.wind;
                    //Establecemos las fuentes de imagenes en la interfaz de usuario con iconos
                    ImgHumedadIcon.Source = "humedadicon.png";
                    ImgVientoIcon.Source = "vientoicon.png";
                    ImgClimaIcon.Source = "clima" + result.hour_hour.hour1.icon;
                }
                else
                {
                    // Manejo del caso en el que los datos son nulos o no contienen la información esperada
                    Debug.WriteLine("Los datos climáticos recibidos son nulos o no contienen la información esperada.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                Debug.WriteLine($"Error en OnAppearing: {ex.Message}");
            }
        }
        
        //Metodo para ontener la ubicacion actual del dispositivo
        public async Task GetLocationAsync()
        {
            try
            {
                //utilizamos la clase Geolocation de Xamarin
                var location = await Geolocation.GetLocationAsync();
                if (location != null)
                {
                    latitud = location.Latitude;
                    longitud = location.Longitude;
                }
                else
                {
                    // Manejo del caso en el que la ubicación no está disponible
                    Debug.WriteLine("No se pudo obtener la ubicación.");

                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones durante la obtención de la ubicación
                Debug.WriteLine($"Error en GetLocationAsync: {ex.Message}");
            }
        }

        //definimos una clase interna ClimaList para representar los elementos de la lista de datos climaticos
        public class ClimaList
        {   
            //propiedades de la clase que representan los datos de cada elemento
            public string Imagen { get; set; }
            public string Temperatura { get; set; }
            public string Hora { get; set; }
            
        }
    }
}
