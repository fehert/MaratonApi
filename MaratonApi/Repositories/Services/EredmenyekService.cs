using MaratonApi.Models;
using MaratonApi.Repositories.Interfaces;

namespace MaratonApi.Repositories.Services
{
    public class EredmenyekService : EredmenyekInterface
    {
        private readonly MaratonvaltoContext _context;

        public EredmenyekService(MaratonvaltoContext context)
        {
            _context = context;
        }
        public async Task<Eredmenyek> NewResult(Eredmenyek eredmenyek)
        {
            var ered = new Eredmenyek { Futo = eredmenyek.Futo, Kor = eredmenyek.Kor, Ido = eredmenyek.Ido };
            await _context.Eredmenyeks.AddAsync(ered);
            await _context.SaveChangesAsync();
            return ered;
        }
        
        
    }
}
