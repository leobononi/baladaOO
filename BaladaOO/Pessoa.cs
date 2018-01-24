using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaladaOO
{
    public abstract class Pessoa
    {
        protected Balada balada = null;
        protected int identificador = -1;
        protected string nome = string.Empty;
        //Random Maximo 10
        protected int beleza = 0;
        //Random Maximo 10
        protected int simpatia = 0;
        //Random Maximo 10
        protected int gostaDancar = 0;
        //Maximo 10
        protected int alcool = 0;
        protected EstadoPessoa estado = EstadoPessoa.Bebendo;
        protected int controleAlcool = 0;
        //Maximo de 3 ciclos
        protected int controleCiclo = 0;

        protected Pessoa parceiroPaquera = null;        

        public Pessoa(Balada Balada)
        {
            balada = Balada;
            //iniciar randomicamente os atributos
            Random random = new Random();

            beleza = random.Next(10);
            beleza++;
            System.Threading.Thread.Sleep(80);

            simpatia = random.Next(10);
            simpatia++;
            System.Threading.Thread.Sleep(80);

            gostaDancar = random.Next(10);
            gostaDancar++;
            System.Threading.Thread.Sleep(80);

            identificador = balada.NovoIdentificador();
        }

        public string Nome
        {
            get
            {
                return nome;
            }
        }

        public int Beleza
        {
            get
            {
                return beleza;
            }
        }

        public int Simpatia
        {
            get
            {
                return simpatia;
            }
        }

        public int Alcool
        {
            get
            {
                return alcool;
            }
        }

        public EstadoPessoa Estado
        {
            get
            {
                return estado;
            }
        }

        public int GostaDancar
        {
            get
            {
                return gostaDancar;
            }
        }

        //guarda a referencia do pretendente
        public Pessoa ParceiroPaquera
        {
            get { return parceiroPaquera; }
        }

        public virtual void Agir()
        {
            Random random = new Random();

            //Se estiver bebendo ou dançando
            if ((estado == EstadoPessoa.Bebendo) || (estado == EstadoPessoa.Dancando))
            {
                controleCiclo++;

                if (estado == EstadoPessoa.Bebendo)
                {
                    controleAlcool++;

                    if (controleAlcool >= 10)
                    {
                        alcool++;
                        controleAlcool = 0;
                    }

                    if (alcool == 10)
                        estado = EstadoPessoa.Bebado;
                }

                if (controleCiclo >= 3)
                {
                    controleCiclo = 0;

                    //1/5 de chances de agir por instinto
                    int acaoGenero = random.Next(5);
                    System.Threading.Thread.Sleep(80);
                    if (acaoGenero == 0)
                    {
                        AgirGenero();
                    }
                    else
                    {
                        int maxRandom = gostaDancar;
                        //if (maxRandom == 1)
                        //    maxRandom = 2;
                        int decisaoBeber = random.Next(maxRandom);
                        System.Threading.Thread.Sleep(80);

                        if (decisaoBeber == 0)
                            estado = EstadoPessoa.Bebendo;
                        else
                            estado = EstadoPessoa.Dancando;
                    }
                }
            }
            else if (estado == EstadoPessoa.Paquerando)
                AgirGenero();
        }

        //Isso é um método abstrato, vou explicar na aula
        //Implementado apenas nas classes filhas
        public abstract void Paquerar(Pessoa Parceiro);
        
        //Executa a ação relativo ao sexo da pessoa
        //Implementado apenas nas classes filhas
        public abstract void AgirGenero();
    }
}
