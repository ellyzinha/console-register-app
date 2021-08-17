using CadastroSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries
{
    class SeriesRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public void Delete(int Id)
        {
            listSeries[Id].Delete();
        }

        public void Insert(Series entity)
        {
            listSeries.Add(entity);
        }

        public List<Series> List()
        {
            return listSeries;
        }

        public int ProximoId()
        {
            return listSeries.Count;
        }

        public Series ReturnById(int Id)
        {
            return listSeries[Id];
        }

        public void Update(int Id, Series entity)
        {
            listSeries[Id] = entity;
        }
    }
}
