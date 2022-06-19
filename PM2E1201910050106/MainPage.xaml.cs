using Plugin.Media;
using Plugin.Media.Abstractions;
using PM2E1201910050106.clases;
using PM2E1201910050106.model;
using PM2E1201910050106.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2E1201910050106
{
  
    public partial class MainPage : ContentPage
    {

        List<Modelo> service;

        double latitud, longitud;
        byte[] image;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Camara_Clicked(object sender, EventArgs e)
        {
            var img = new StoreCameraMediaOptions();
            img.PhotoSize = PhotoSize.Full;
            img.Name = "img";
            img.Directory = "PM2E10631";
            var foto = await CrossMedia.Current.TakePhotoAsync(img);
            if (foto != null)
            {

                imagefile.Source = ImageSource.FromStream(() => {
                    return foto.GetStream();
                });
                using (MemoryStream memoria = new MemoryStream())
                {
                    Stream stream = foto.GetStream();
                    stream.CopyTo(memoria);
                    image = memoria.ToArray();
                }
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Descripcion.Text))
            {
                await DisplayAlert("Mensaje", "Complete el campo de Ubicacion", "Salir");
                return;
            }
            if (imagefile.Source == null)
            {
                await DisplayAlert("Mensaje", "Camptar la imagen para poder guardar", "Salir");
                return;
            }
            else
            {

                OperacionesDB operacionesDB = new OperacionesDB();
                cnx conn = new cnx();

                var ubicacion = new Modelo()
                {
                    id = 0,
                    latitud = Convert.ToDouble(Latitud.Text),
                    longitud = Convert.ToDouble(Longitud.Text),
                    descripcion = Descripcion.Text,
                    fotografia = image

                };
                conn.Conn().CreateTable<Modelo>();
                conn.Conn().Insert(ubicacion);
                await DisplayAlert("Mensaje", "Registro Guardado", "Salir");
                Descripcion.Text = "";
            }
        }

        private async void Lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ubicaciones());
        }

       

    }
}
