using MaratonApi.Models;

namespace MaratonApi.Repositories.Interfaces
{
    public interface EredmenyekInterface
    {
        Task<Eredmenyek> NewResult(Eredmenyek eredmenyek);
    }
}
