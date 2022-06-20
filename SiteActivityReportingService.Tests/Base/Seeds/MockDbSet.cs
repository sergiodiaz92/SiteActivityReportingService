using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Tests.Base.Seeds
{
    public class MockDbSet<TEntity> : DbSet<TEntity>
       where TEntity : class, new()
    {
        public void LoadJson(DbSet<TEntity> dbset, string file)
        {
            if (dbset.Any())
                return;

            var text = File.ReadAllText(file);
            var list = JsonConvert.DeserializeObject<List<TEntity>>(text);

            foreach (var item in list)
            {
                dbset.Add(item);
            }
        }
    }
}
