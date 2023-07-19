using QuestaEnneagram.DbLayer;
using QuestaEnneagram.ServiceLayer.EF.Interface;
using QuestaEnneagram.ServiceLayer.Interface;
using QuestaEnneagram.ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestaEnneagram.ServiceLayer.EF.Service
{
    public class UnitofWorkRepo : IUnitofWork
    {
        public ICandidateRepo Candidaterepo { get; private set; }

        private readonly QuestaDbContext QuestaDbContext;

        public UnitofWorkRepo(QuestaDbContext QuestaDbContext)
        {
            this.QuestaDbContext = QuestaDbContext;
            Candidaterepo = new CandidateRepos(QuestaDbContext);
        }

        public async Task CompleteAsync()
        {
            await this.QuestaDbContext.SaveChangesAsync();
        }
    }
}
