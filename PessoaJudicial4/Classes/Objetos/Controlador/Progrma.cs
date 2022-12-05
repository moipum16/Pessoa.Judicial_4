using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PessoaJudicial4.Classes.Interface.Controlador;
using PessoaJudicial4.Classes.Objetos.Pessoa;
using static System.Net.Mime.MediaTypeNames;

namespace PessoaJudicial4.Classes.Objetos.Controlador
{
    public class Progrma : iControlador
    {
        private List<Pessoa_0>? Pessoas { get; set; }
        private bool addmais1 { get; set; } = false;
        private string ?AntesDeSair { get; set; } = "";

        public void init()
        {
            Pessoas = new List<Pessoa_0>();

            NovaPessoa();

        }

        private void NovaPessoa() 
        {
  
            Pessoas.Add(new Pessoa_0());

            Pessoas[Pessoas.Count() - 1].Id= Convert.ToString(Pessoas.Count() - 1);
            Pessoas[Pessoas.Count() - 1].init();

            Depois();
        }

        private void ListarPessoas() 
        {
            Console.WriteLine(" ");

            foreach (var x in Pessoas)
            {
                if (x.Fisica == true)
                {
                    Console.WriteLine($"           Nome: {x.Name}, Data de nascimento: {x.Date}, CPF: {x.CPF}, ID: {x.Id} ");

                }
                else
                {
                    Console.WriteLine($"Nome da empresa: {x.NameFantasy}, Data de fundação: {x.Date}, CPNJ: {x.CPNJ}, ID: {x.Id} ");

                }

            }
        }

        private void AdicionarMaisPessoas() 
        {
            Console.WriteLine("");
            Console.WriteLine("Deseja adicionar mais alguma Pessoa/Empresa? \"true\" ou \"false\" .");

            addmais1 = false;

            try 
            {
                addmais1 = Convert.ToBoolean(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Valor incorreto!");
                Console.WriteLine(value: "");

                AdicionarMaisPessoas();
            }
        }

        private void ListarOuConsultar()
        {
            Console.WriteLine("");
            Console.WriteLine("Deseja Listar todas as Pessoas/Empresas? ou realizar uma consulta? Digite \"consultar\" ou \"listar\" ou \"sair\" .");

            AntesDeSair = Console.ReadLine();

            if(AntesDeSair=="Listar" || AntesDeSair == "listar" || AntesDeSair == "LISTAR" )
            {
                ListarPessoas();
                Depois();

            }
            else if(AntesDeSair == "Consultar" || AntesDeSair == "consultar" || AntesDeSair == "CONSULTAR")
            {
                DigiteOid();
                Depois();

            }
            else if(AntesDeSair == "Sair" || AntesDeSair == "sair" || AntesDeSair == "SAIR" || AntesDeSair == "sair .") 
            {
                Environment.Exit(0);
            }
            else 
            {
                Console.WriteLine("Valor incorreto!");
                Console.WriteLine(value: "");

                Depois();

            }
        }

        private void Depois() 
        {

            AdicionarMaisPessoas();

            if (addmais1 == true)
            {
                NovaPessoa();

            }
            else
            {
                ListarOuConsultar();

            }
        }

        private void DigiteOid() 
        {
            Console.WriteLine("");
            Console.WriteLine($"Digite o ID do usuário: de 0 à {Pessoas.Count()-1}");
            Console.WriteLine("");

            long numeroDigitado = 0;

            try 
            {
                numeroDigitado = Convert.ToInt64(Console.ReadLine());

                if (Pessoas[Convert.ToInt32(numeroDigitado)].Fisica == true)
                {
                    Console.WriteLine($"Nome: {Pessoas[Convert.ToInt32(numeroDigitado)].Name}, Data de nascimento: {Pessoas[Convert.ToInt32(numeroDigitado)].Date}, CPF: {Pessoas[Convert.ToInt32(numeroDigitado)].CPF}, ID: {Pessoas[Convert.ToInt32(numeroDigitado)].Id} ");

                }
                else
                {
                    Console.WriteLine($"Nome da empresa: {Pessoas[Convert.ToInt32(numeroDigitado)].NameFantasy}, Data de fundação: {Pessoas[Convert.ToInt32(numeroDigitado)].Date}, CPNJ: {Pessoas[Convert.ToInt32(numeroDigitado)].CPNJ}, ID: {Pessoas[Convert.ToInt32(numeroDigitado)].Id} ");

                }

            }
            catch (Exception) 
            {
                Console.WriteLine("Valor incorreto! ou ID inexistente");
                Console.WriteLine(value: "");

            }
        }

    }

}
