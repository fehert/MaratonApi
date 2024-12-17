using MaratonApi.Models;

namespace MaratonApi.Repositories.Interfaces
{
    public interface FutokInterface
    {
        Task<List<Futok>> AllRunner();
        Task<Futok> ById(int id);
        Task<Futok> RunnerWithAllData(int id);

        Task<List<GetFemaleDto>> AllFemaleRunner();
        Task<Futok> RunnerAge();
        Task<List<BestRunnersDto>> GetBestRunner();
    }
}
