using FVA.IPV.ReportPublication.Data;
using FVA.IPV.ReportPublication.Model.Data;

namespace FVA.IPV.ReportPublication.Provider.Provider
{
    public interface IReportOutputProvider
    {
        Task<IEnumerable<ReportOutputModel>> GetReportOutputAsync(DateTime asOfDate, string site);
    }
    public class ReportOutputProvider : IReportOutputProvider
    {
        private readonly IReportHeaderDal _reportHeaderDal;
        private readonly IReportOutputModelDal _reportOutputModelDal;

        public ReportOutputProvider(IReportHeaderDal reportHeaderDal, IReportOutputModelDal reportOutputModelDal)
        {
            _reportHeaderDal = reportHeaderDal;
            _reportOutputModelDal = reportOutputModelDal;
        }

        public async Task<IEnumerable<ReportOutputModel>> GetReportOutputAsync(DateTime asOfDate, string site)
        {
            int siteId = 0;
            int.TryParse(site, out siteId);

            IEnumerable<ReportOutputModel> result = new List<ReportOutputModel>();

            var header = _reportHeaderDal.GetForSite(asOfDate, siteId);

            var maxHeader = header.OrderByDescending(u => u.Id).FirstOrDefault();
            if (maxHeader != null)
            {
                return await _reportOutputModelDal.GetAsync(maxHeader.Id);
            }

            return result;
        }
    }
}
