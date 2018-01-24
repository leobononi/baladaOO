using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaladaOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Balada balada = new Balada();
            int ciclo = 0;

            Console.WriteLine("Criando pessoas...");
            balada.NovaMenininha();
            balada.NovaMenininho();
            balada.NovaMenininha();
            balada.NovaMenininho();
            balada.NovaMenininha();
            balada.NovaMenininho();
            balada.NovaMenininha();           
            balada.NovaMenininho();
            balada.NovaMenininha();            
            balada.NovaMenininho();
            balada.NovaMenininho();
            balada.NovaMenininha();
            balada.NovaMenininho();
            balada.NovaMenininha();
            balada.NovaMenininha();
            balada.NovaMenininha();
            balada.NovaMenininha();
            balada.NovaMenininha();
            balada.NovaMenininha();
            balada.NovaMenininho();
            balada.NovaMenininho();
            balada.NovaMenininho();
            balada.NovaMenininho();
            
            while (!balada.Finalizada)
            {
                ciclo++;
                balada.Atualizar();
                Console.Clear();
                Console.WriteLine("Ciclo " + ciclo);
                Console.WriteLine();
                foreach (Pessoa pessoa in balada.Pessoas)
                {
                    if (pessoa is Menininha)
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else
                        Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine(pessoa.Nome + " " + pessoa.Beleza + "/" + pessoa.Simpatia);
                    Console.Write(" A: " + pessoa.Alcool);
                    Console.Write(" Dançar: " + pessoa.GostaDancar);

                    if (pessoa is Menininho)
                    {
                        Menininho temp = (Menininho)pessoa;
                        Console.Write(" C: " + temp.Coragem);
                        //Console.Write(" F: " + temp.Forca);
                    }

                    string estado = "";

                    switch (pessoa.Estado)
                    {
                        case EstadoPessoa.Dancando:
                            estado = "Dançando...";
                            break;
                        case EstadoPessoa.Bebendo:
                            estado = "Bebendo...";
                            break;
                        case EstadoPessoa.Paquerando:
                            estado = "Paquerando " + pessoa.ParceiroPaquera.Nome;
                            break;
                        case EstadoPessoa.Brigando:
                            estado = "Brigando...";
                            break;
                        case EstadoPessoa.Ficando:
                            estado = "FICANDO com " + pessoa.ParceiroPaquera.Nome;
                            break;
                        case EstadoPessoa.Bebado:
                            estado = "BEBADO";
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(" [" + estado + "]");
                    Console.WriteLine();
                }

                Console.WriteLine("Hora: " + CicloParaHora(ciclo));
                System.Threading.Thread.Sleep(300);
            }
        }

        public static string CicloParaHora(int ciclo)
        {
            int min = (ciclo % 60);
            int hora = Convert.ToInt32((ciclo - min) / 60);

            string retorno = hora.ToString("00") + ":" + min.ToString("00") + " da manhã";

            return retorno;
        }
    }
}
