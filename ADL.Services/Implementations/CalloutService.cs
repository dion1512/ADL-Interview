using ADL.Data.Entities;
using ADL.Repositories;
using ADL.Repositories.Interfaces;
using ADL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Services.Implementations
{
    public class CalloutService : ICalloutService
    {
        private IRepository<Callout> calloutRepository;

        public CalloutService(IRepository<Callout> calloutRepository)
        {
            this.calloutRepository = calloutRepository;
        }

        public IEnumerable<Callout> GetCallouts()
        {
            return calloutRepository.GetAll();
        }

        public Callout GetCallout(long id)
        {
            return calloutRepository.Get(id);
        }

        public async Task InsertCallout(Callout callout)
        {
            await calloutRepository.Insert(callout);
        }
        public void UpdateCallout(Callout callout)
        {
            calloutRepository.Update(callout);
        }

        public void DeleteCallout(long id)
        {
            Callout callout = GetCallout(id);
            calloutRepository.Remove(callout);
            calloutRepository.SaveChanges();
        }
    }
}
