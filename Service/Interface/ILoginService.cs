﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenParcial2.Service.Interface
{
    public interface ILoginService
    {
        public Task<bool> LoginAsync(string usuario, string contraseña);
    }


}
