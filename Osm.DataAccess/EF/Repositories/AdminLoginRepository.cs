﻿using Osm.CommonTypesLayer.DataAccess.Implementaitons.EF;
using Osm.DataAccessLayer.EF.Context;
using Osm.DataAccessLayer.Interfaces;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.DataAccessLayer.EF.Repositories
{
    public class AdminLoginRepository : BaseRepository<AdminLogin, OsmanliMakinaContext>, IAdminLoginRepository
    {
        public async Task<AdminLogin> GetByIDAsync(int adminLoginID)
        {
            var result = await GetAsync(x => x.ID == adminLoginID);
            return result;
        }
    }
}
