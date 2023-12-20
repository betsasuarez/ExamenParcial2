using ExamenParcial2.Models;
using ExamenParcial2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial2.Service
{
    public class EncuestaService :IEncuestaService
    {
        public async Task<bool> LoginAsync(int res1, double res2, int res3)
        {
            var result = false;

            await Task.Delay(250);

            var storedRespuestas = new List<Tuple<int, double, int>>
    {
        new Tuple<int, double, int>(Settings.RespuestaEncuesta1, Settings.RespuestaEncuesta2, Settings.RespuestaEncuesta3) };

            var inputRespuestas = new Tuple<int, double, int>(res1, res2, res3);

            if (storedRespuestas.Any(r => r.Equals(inputRespuestas)))
            {
                result = true;
            }

            return result;

        }
    }
}


    


