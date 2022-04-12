﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface INewServices
    {
        List<New> GetAll();
        New GetById(int id);
        void Create(New news);
        void Edit(New news);
        void Delete(New news);
    }
}
