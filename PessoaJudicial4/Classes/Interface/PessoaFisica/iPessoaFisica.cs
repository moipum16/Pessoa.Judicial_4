using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PessoaJudicial4.Classes.Interface.PessoaFisica
{
    internal interface iPessoaFisica
    {
        public abstract string? Name { get; set; }
        
        public abstract string? CPF { get; set; }

    }
}
