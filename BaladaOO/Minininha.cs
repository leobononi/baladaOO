using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaladaOO
{
    public class Menininha : Pessoa
    {
        public Menininha(Balada Balada)
            : base(Balada)
        {
            //Vou explicar isso na aula. Isso é um método estatico
            nome = Balada.GeraNome(false);
        }

        //Criado depois da aula
        public override void AgirGenero()
        {
            Random random = new Random();

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

        public override void Paquerar(Pessoa Parceiro)
        {
            //Se ja estiver ficando nem processa nada
            if (estado == EstadoPessoa.Ficando)
                return;

            int maxAceite = 0;

            //Se não estiver bebada calcula se aceita senão aceita qq coisa kkkkk
            if (estado != EstadoPessoa.Bebado)
            {
                int coeficienteAlcool = this.alcool;
                if (coeficienteAlcool < 3)
                    coeficienteAlcool = 3;

                //Sempre as mulheres se veem melhores do que são kkkkkk
                maxAceite = 4 * (this.beleza + this.simpatia);
                maxAceite = maxAceite - (coeficienteAlcool * Parceiro.Beleza + Parceiro.Simpatia);
                if (maxAceite <= 0)
                    maxAceite = 1;

                Random random = new Random();
                maxAceite = random.Next(maxAceite);
                System.Threading.Thread.Sleep(80);
            }

            if (maxAceite == 0)
            {
                //Aceitou ficar com o caboclo
                estado = EstadoPessoa.Ficando;
                parceiroPaquera = Parceiro;
            }
        }
    }
}
