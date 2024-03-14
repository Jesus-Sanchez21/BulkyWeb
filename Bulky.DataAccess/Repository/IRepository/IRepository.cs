using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        /* -------------------------------------------------------------------------------
         * 
         * T - Category
         * T will be category or any other generic model 
         * on which we want to perform the CRUD operation,or rather, 
         * we want to interact with the DB context. 
         * 
         * --------------------------------------------------------------------------------
         * 
         * 1 - We need to retrieve all the category where we are displaying all of them.
         * So we can say the return type will be IEnumerable of T,
         * and we can call that method as GetAll.
         * 
         * ------------------------------------------------------------------------------- 
         * 
         * 2- If we have to retrieve only one category
         * 
         * -------------------------------------------------------------------------------
         * 
         * 3- Generic Repository
         * 
         * -------------------------------------------------------------------------------
         *
         */

        //------  1  ---------

        IEnumerable<T> GetAll();

        //------  2  ---------
        T Get(Expression<Func<T,bool>> filter); //Using a LINQ operator to get one record

        //------  3  ---------
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
