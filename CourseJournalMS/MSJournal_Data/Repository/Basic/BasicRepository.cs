using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.DbContexts;

namespace MSJournal_Data.Repository.Basic
{
    /// <summary>
    /// Podstawowe repozytorium po którym dziedziczą wszystkie. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BasicRepository<T>
    {
        /// <summary>
        /// Dodawanie modelu do bazydanych
        /// </summary>
        /// <param name="model"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public abstract bool Add(T model);

        /// <summary>
        /// Pobieranie modelu po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T Get(int id);

        /// <summary>
        /// Pobieranie wszystkich modeli z bazy
        /// </summary>
        /// <returns></returns>
        public abstract List<T> GetAll();

        /// <summary>
        /// Sprawdzenie czy dany obiekt istnieje w bazie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public abstract bool Exist(T model);

        /// <summary>
        /// Odpalanie kwerendy
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public TResult ExecuteQuery<TResult>(Func<JournalDbContext, TResult> func)
        {
            TResult result;

            using (var dbContext = new JournalDbContext())
            {
                result = func(dbContext);
                dbContext.SaveChanges();
            }

            return result;
        }
    }
}
