using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;
namespace VodovozWpfApp
{
    public class SubdivisionsRepository : ISubdivisionsRepo
    {
        private VodovozClientDbContext _context;
        public SubdivisionsRepository(VodovozClientDbContext ctx) 
        {
            _context = ctx;                       
        }

        public IEnumerable<Subdivision> Subdivisions => _context.Subdivisions
            .Include(e => e.Employees).ToArray();

        public async Task<Subdivision> GetSubdivisionAsync(long id)
        {           
            Subdivision subdivision =  await _context.Subdivisions.Include(e => e.Manager).FirstOrDefaultAsync(s => s.Id == id);
            return subdivision;
        }

        public async Task<Subdivision> UpdateOrAddSubdivisionAsync(Subdivision Subdivision)
        {
            Subdivision subdivision = await _context.Subdivisions.FindAsync(Subdivision.Id);
            bool isItAdd = false;
            if (subdivision != null)
            {
                subdivision.Name = Subdivision.Name;
                subdivision.Manager = Subdivision.Manager;
            }
            else
            {
                isItAdd = true;
                //employee = Employee;
                await _context.Subdivisions.AddAsync(Subdivision);
            }
            await _context.SaveChangesAsync();

            return isItAdd ? Subdivision : null;

        }

        public async Task DeleteSubdivisionAsync(Subdivision Subdivision)
        {
            _context.Subdivisions.Remove(Subdivision);
            await _context.SaveChangesAsync();
        }
    }
}
