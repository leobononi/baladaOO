using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaladaOO
{
    public class Balada
    {
        private List<Pessoa> pessoas = new List<Pessoa>();

        public List<Pessoa> Pessoas
        {
            get { return pessoas; }
            set { pessoas = value; }
        }

        public bool Finalizada
        {
            get {
                foreach (Pessoa pessoa in pessoas)
                {
                    if ((pessoa.Estado != EstadoPessoa.Ficando) && (pessoa.Estado != EstadoPessoa.Bebado))
                        return false;
                }

                return true; 
            }
        }

        public void Atualizar()
        {
            foreach (Pessoa pessoa in pessoas)
            {
                pessoa.Agir();
            }
        }

        public int NovoIdentificador()
        {
            return (pessoas.Count + 1);
        }

        public Menininha NovaMenininha()
        {
            Menininha instancia = new Menininha(this);

            pessoas.Add(instancia);

            return instancia;
        }

        public Menininho NovaMenininho()
        {
            Menininho instancia = new Menininho(this);

            pessoas.Add(instancia);

            return instancia;
        }

        //Retorna todas as meninas que nãoe stejam ficando com ninguem
        public List<Menininha> BuscaMenininhas()
        {
            List<Menininha> retorno = new List<Menininha>();

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa is Menininha)
                {
                    Menininha temp = (Menininha)pessoa;
                    if (temp.Estado != EstadoPessoa.Ficando)
                        retorno.Add(temp);
                }
            }

            return retorno;
        }

        //Vou explicar isso na aula. Isso é um método estatico
        public static string GeraNome(bool Masculino)
        {
            string[] maleNames = new string[] { "João", "Paulo", "Felipe", "Mateus", "Thiago", "Diego", "Giovani", "Ariel", "Maicon", "Adriano" };
            string[] femaleNames = new string[] { "Juliana", "Tarise", "Talita", "Janaina", "Fabiola", "Jessica", "Jenoveva", "Jaqueline", "Natalia", "Camila" };
            string[] lastNames = new string[] { "Santos", "Silva", "Golçalvez", "Pestana", "Aguiar", "Valadão", "Batista", "Boldrin", "Rodriguez", "da Costa" };

            Random random = new Random();
            string retorno = "";

            if (Masculino)
                retorno = maleNames[random.Next(maleNames.Length)];
            else
                retorno = femaleNames[random.Next(femaleNames.Length)];

            System.Threading.Thread.Sleep(80);
            retorno += " " + lastNames[random.Next(lastNames.Length)];

            return retorno;
        }
    }
}
