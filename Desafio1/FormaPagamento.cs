﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    internal abstract class FormaPagamento
    {

        protected FormaPagamento() { }
        public abstract void descricao(double valorTotal);
    }
}
