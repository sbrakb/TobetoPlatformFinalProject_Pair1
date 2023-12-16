﻿using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
	public class EfUserDal : EfRepositoryBase<User, Guid, TobetoPlatformContext>, IUserDal
    {
        public EfUserDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}
