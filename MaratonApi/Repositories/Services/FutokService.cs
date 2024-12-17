using MaratonApi.Models;
using MaratonApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaratonApi.Repositories.Services
{
    public class FutokService : FutokInterface
    {
        private readonly MaratonvaltoContext _context;

        public FutokService(MaratonvaltoContext context)
        {
            _context = context;
        }

        public async Task<List<GetFemaleDto>> AllFemaleRunner()
        {
            var females = await _context.Futoks.Where(futo => futo.Ffi == 0).Select(futo => new GetFemaleDto( futo.Fnev, futo.Szulev )).ToListAsync();
            return females;
        }

        public async Task<List<Futok>> AllRunner()
        {
            var runners = await _context.Futoks.ToListAsync();
                return runners;
        }

        public async Task<Futok> ById(int id)
        {
            var runner = await _context.Futoks.FirstOrDefaultAsync(futo=>futo.Ffi==id);
            return runner;
        }
        public async Task<Futok> RunnerWithAllData(int id)
        {
            var runner = await _context.Futoks.Include(futo=>futo.Eredmenyeks).FirstOrDefaultAsync(futo=>futo.Fid==id);
            return runner;
        }
        public async Task<List<GetRunnersDto>> RunnerAge()
        {
            var age = await _context.Futoks.Select(futo=>new GetRunnersDto(futo.Fnev,2016-futo.Szulev)).ToListAsync();
            return age;

        }

        public async Task<List<BestRunnersDto>> BestRunner()
        {
            var best = await _context.Futoks.Include(futo => futo.Eredmenyeks).OrderByDescending(futo => futo.Eredmenyeks.Select(ered => ered.Ido)).Select(futo=>new BestRunnersDto(futo.Fnev,futo.Eredmenyeks.Select(ered=>ered.Ido))).ToListAsync();
        }
    }
}
