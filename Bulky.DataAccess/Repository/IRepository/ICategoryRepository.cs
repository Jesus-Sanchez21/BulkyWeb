﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    //Implementar a irepository interface AO iCategoryRepositoru
    public interface ICategoryRepository : IRepository<Category> 
    {
        void Update(Category obj); //Incluir o update
    }
}
