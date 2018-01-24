using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaladaOO
{
    public class Menininho : Pessoa
    {
        //Random Maximo 10
        private int forca = 0;
        //Random Maximo 10
        private int coragem = 0;

        private int tentativaPaquera = 0;

        public Menininho(Balada Balada)
            : base(Balada)
        {
            Random random = new Random();
            forca = random.Next(10);
            forca++;
            System.Threading.Thread.Sleep(80);
            coragem = random.Next(10);
            coragem++;
            System.Threading.Thread.Sleep(80);

            //Vou explicar isso na aula. Isso é um método estatico
            nome = Balada.GeraNome(true);
        }

        //Criado depois da aula
        public int Coragem
        {
            get
            {
                double calc = coragem + (alcool * 0.3);
                return Convert.ToInt32(Math.Round(calc));
            }
        }

        public int Forca
        {
            get
            {
                double calc = forca - (alcool * 0.3);
                return Convert.ToInt32(Math.Round(calc));
            }
        }

        public override void Paquerar(Pessoa Parceiro)
        {
            tentativaPaquera++;

            parceiroPaquera = Parceiro;
            estado = EstadoPessoa.Paquerando;
            Parceiro.Paquerar(this);

            if (Parceiro.ParceiroPaquera == this)
            {
                estado = EstadoPessoa.Ficando;
            }
        }

        public override void AgirGenero()
        {
            if (estado != EstadoPessoa.Ficando)
            {
                if (parceiroPaquera != null)
                {
                    //Tenta numero de coragem vezes até desistir
                    if (tentativaPaquera >= Coragem)
                    {
                        parceiroPaquera = null;
                        tentativaPaquera = 0;

                        //Se toma toco volta a beber kkkk
                        estado = EstadoPessoa.Bebendo;
                    }
                    else
                    {
                        //Se o parceiro ainda não possui par tenta paquerar novamente
                        if (parceiroPaquera.ParceiroPaquera == null)
                            Paquerar(parceiroPaquera);
                        else
                        {
                            parceiroPaquera = null;
                            tentativaPaquera = 0;

                            //Se desiste vai beber novamente
                            estado = EstadoPessoa.Bebendo;
                        }
                    }
                }
                else
                {
                    List<Menininha> garotas = balada.BuscaMenininhas();
                    //escolhi este nome pra zuar mesmo
                    Menininha vitima = null;

                    foreach (Menininha garota in garotas)
                    {
                        if (vitima == null)
                            vitima = garota;
                        else
                        {
                            //analisa quem é a garota mais bonita
                            if (garota.Beleza > vitima.Beleza && garota.Alcool != 0)
                            {
                                vitima = garota;
                            }

                            //aqui podemos processar se a vitima ja tem pretendentes ou outros parametros de escolha
                           

                        }
                    }

                    if (vitima != null)
                        Paquerar(vitima);
                }
            }
        }
    }
}
