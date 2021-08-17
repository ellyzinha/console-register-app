using CadastroSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries
{
    class Series : BaseEntity
    {
        private Gender genero { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int ano { get; set; }
        private bool excluido { get; set; }

        public Series(int Id, Gender genero, string titulo, string descricao, int ano)
        {
            this.Id = Id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            //Environment.NewLine = Quebra de linha para qualquer sistema operacional
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano de início: " + this.ano + Environment.NewLine;
            retorno += "Excluido: " + this.excluido;

            return retorno;
        }

        public string returnTitulo()
        {
            return this.titulo;
        }

        public int returnId()
        {
            return this.Id;
        }
        public bool returExcluido()
        {
            return this.excluido;
        }

        public void Delete()
        {
            this.excluido = true;
        }
    }

}
