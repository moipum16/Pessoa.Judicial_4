using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PessoaJudicial4.Classes.Interface.PessoaJuridica
{
    internal interface iPessoaJuridica
    {
        public abstract string? NameFantasy{get;set;}

        public abstract string? CPNJ { get; set; }
    }
}
