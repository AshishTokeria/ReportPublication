using FVA.IPV.ReportPublication.Data.Context;
using FVA.IPV.ReportPublication.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FVA.IPV.ReportPublication.Data
{
    public interface IReportSettingsDal
    {
        Task<ReportSettings> GetByName(string name);
    }
    public class ReportSettingsDal : IReportSettingsDal
    {
        private readonly CreateDbContext _context;
        public ReportSettingsDal(CreateDbContext context)
        {
            _context = context;
        }

        public async Task<ReportSettings> GetByName(string name)
        {
            return await _context.ReportSettings.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
