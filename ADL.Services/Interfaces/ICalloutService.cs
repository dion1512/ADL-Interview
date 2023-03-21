using ADL.Data.Entities;

namespace ADL.Services.Interfaces
{
    public interface ICalloutService
    {
        IEnumerable<Callout> GetCallouts();
        Callout GetCallout(long id);
        Task InsertCallout(Callout callout);
    }
}