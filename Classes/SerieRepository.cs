using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> Series = new List<Serie>();

        public void Insert(Serie entity)
        {
            Series.Add(entity);
        }

        public void Update(int id, Serie entity)
        {
            Series[id] = entity;
        }

        public void Delete(int id)
        {
            Series[id].Exclude();
        }

        public List<Serie> List()
        {
            return Series;
        }

        public Serie ReturnId(int id)
        {
            return Series[id];
        }

        public int NextId()
        {
            return Series.Count;
        }
    }
}