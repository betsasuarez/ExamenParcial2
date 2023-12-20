using CommunityToolkit.Maui.Alerts;
using ExamenParcial2.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial2.ViewModel
{
    public class EncuestaViewModel:INotifyPropertyChanged
    {
        private readonly IEncuestaService encuestaService;

        public event PropertyChangedEventHandler PropertyChanged;

        public int RespuestaEncuesta1 { get; set; }
        public double RespuestaEncuesta2 { get; set; }
        public int RespuestaEncuesta3 { get; set; }

        public Command ValidarRespuestasCommand { get; set; }

        
        public EncuestaViewModel(IEncuestaService encuestaService)
        {
            this.encuestaService = encuestaService;

            ValidarRespuestasCommand = new Command(ValidarRespuestas);
        }

        private void ValidarRespuestas()
        {
            char respuestaPregunta1;
            if (char.TryParse(RespuestaEncuesta1.ToString(), out respuestaPregunta1))
            {
                if (respuestaPregunta1== '4')
                {
                    ShowToastAsync("Respuesta correcta para la Pregunta 1");
                }
                else
                {
                    ShowToastAsync("Respuesta incorrecta para la Pregunta 1");
                }
            }
            else
            {
                ShowToastAsync("La respuesta para la Pregunta 1 no es un carácter válido");
            }
            double respuestaPregunta2;
            if (double.TryParse(RespuestaEncuesta2.ToString(), out respuestaPregunta2))
            {
                if (Math.Abs(respuestaPregunta2 - 3.14) < 0.0001) 
                {
                    ShowToastAsync("Respuesta correcta para la Pregunta 2");
                }
                else
                {
                    ShowToastAsync("Respuesta incorrecta para la Pregunta 2");
                }
            }
            else
            {
                ShowToastAsync("La respuesta para la Pregunta 2 no es un número válido");
            }

            int respuestaPregunta3;
            if (int.TryParse(RespuestaEncuesta3.ToString(), out respuestaPregunta3))
            {
                if (respuestaPregunta3 == 5)
                {
                    ShowToastAsync("Respuesta correcta para la Pregunta 3");
                }
                else
                {
                    ShowToastAsync("Respuesta incorrecta para la Pregunta 3");
                }
            }
            else
            {
                ShowToastAsync("La respuesta para la Pregunta 3 no es un número válido");
            }

        }

        private async Task ShowToastAsync(string message)
        {
            // implement your logic here
            var toast = Toast.Make(message);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await toast.Show(cts.Token);
        }
    }

}