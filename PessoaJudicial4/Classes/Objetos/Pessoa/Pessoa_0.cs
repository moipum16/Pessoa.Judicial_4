using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PessoaJudicial4.Classes.Interface.PessoaFisica;
using PessoaJudicial4.Classes.Interface.PessoaJuridica;

namespace PessoaJudicial4.Classes.Objetos.Pessoa
{
    public class Pessoa_0 : iPessoaFisica, iPessoaJuridica
    {
        private bool RunOnce { get; set; }

        public string? NameFantasy { get; set; } = "";
        public string? Name { get; set; } = "";

        public string? CPNJ { get; set; } = "";
        public string? CPF { get; set; } = "";
        public string? Id { get; set; } = "";

        public DateTime? Date { get; set; }

        public bool Fisica { get; set; }

        public void init()
        {
            if (RunOnce == true)
            {
                Console.WriteLine(value: "Já foi executado!");
            }
            else
            {
                RunOnce = true;
                Cadastro();


            }
        }

        private void Cadastro() 
        {

            void Tipo()
            {

                Console.WriteLine("É Pessoa física Digite \"true\" ou \"false\" .");
                Console.WriteLine(value: "");

                try
                {
                    Fisica = Convert.ToBoolean(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Valor incorreto!");
                    Console.WriteLine(value: "");

                    Tipo();

                }
            }

            void Nomear()
            {
                if (Fisica == true)
                {
                    Console.WriteLine("Qual o seu nome?");
                    Console.WriteLine("");

                    Name = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Qual o nome da sua empresa?");
                    Console.WriteLine("");

                    NameFantasy = Console.ReadLine();

                }
            }

            void Documentar()
            {
                if (Fisica == true)
                {
                    Console.WriteLine("Qual o seu CPF?");
                    Console.WriteLine("");

                    CPF = Console.ReadLine();

                    if (Regex.IsMatch(CPF, @"^\d{3}.\d{3}.\d{3}-\d{2}$")) 
                    {
                    }
                    else 
                    {
                        Console.WriteLine("Valor incorreto. Exemplo: 000.000.006-00");
                        Console.WriteLine(value: "");
                        
                        Documentar();


                    }

                }
                else
                {
                    Console.WriteLine("Qual o seu CPNJ?");
                    Console.WriteLine("");

                    CPNJ = Console.ReadLine();

                    try 
                    {
                        if (Regex.IsMatch(CPNJ, @"^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$"))
                        {
                            if (CPNJ.Substring(11, 4) == "0001")
                            {
                                //Correto se não Valor incorreto
                            }
                            else if (CPNJ.Length == 18)
                            {
                                if (CPNJ.Substring(8, 4) == "0001")
                                {
                                    //Correto se não Valor incorreto
                                }
                                else
                                {
                                    Console.WriteLine("Valor incorreto. Exemplo: XX.XXX.XXX/0001-XX");
                                    Console.WriteLine(value: "");

                                    Documentar();
                                }

                            }
                            else
                            {
                                Console.WriteLine("Valor incorreto. Exemplo: XX.XXX.XXX/0001-XX");
                                Console.WriteLine(value: "");

                                Documentar();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor incorreto. Exemplo: XX.XXX.XXX/0001-XX");
                            Console.WriteLine(value: "");

                            Documentar();


                        }
                    }
                    catch (Exception) 
                    {
                        Console.WriteLine("Valor incorreto. Exemplo: XX.XXX.XXX/0001-XX");
                        Console.WriteLine(value: "");

                        Documentar();
                    }
                    
                }
            }

            void Datar() 
            {
                string av= "nascimento";

                if(Fisica== true) 
                {
                    av = "nascimento?";
                }
                else 
                {
                    av = "fundação?";
                }

                Console.WriteLine($"Qual a sua data de {av}");
                Console.WriteLine(value: "");

                try 
                {
                    Date = Convert.ToDateTime(Console.ReadLine());    
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor incorreto. Exemplo: 01/01/01");
                    Console.WriteLine(value: "");

                    Datar();
                }   
            }

            Tipo();
            Nomear();
            Documentar();
            Datar();

        }   
    }
}
