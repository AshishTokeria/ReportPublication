using FVA.IPV.ReportPublication.Data.Context;
using FVA.IPV.ReportPublication.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace FVA.IPV.ReportPublication.Data
{
    public interface IReportHeaderDal
    {
        Task<ReportHeader> GettHeader(int headerId);
        IEnumerable<ReportHeader> GetForSite(DateTime asOfDate, int siteId);
    }

    public class ReportHeaderDal : IReportHeaderDal
    {
        private readonly CreateDbContext _context;
        public ReportHeaderDal(CreateDbContext context) 
        {
            _context = context;
        }
        public IEnumerable<ReportHeader> GetForSite(DateTime asOfDate, int siteId)
            => from header in _context.ReportHeaders
               where header.AsOfDate == asOfDate && header.SiteId == siteId
               select header;

        public async Task<ReportHeader> GettHeader(int headerId) 
            => await _context.ReportHeaders.FirstOrDefaultAsync(x => x.Id == headerId);
    }
}