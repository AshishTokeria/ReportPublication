using FVA.IPV.ReportPublication.Data.Context;
using FVA.IPV.ReportPublication.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace FVA.IPV.ReportPublication.Data
{
    public interface IReportOutputModelDal
    {
        public Task<IEnumerable<ReportOutputModel>> GetAsync(int headerid);
    }

    public class ReportOutputModelDal : IReportOutputModelDal
    {
        private readonly CreateDbContext _context;
        public ReportOutputModelDal(CreateDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<ReportOutputModel>> GetAsync(int headerid)
        {
            var positionLevelResults = _context.ReportOutputModels
                .Where(x => x.HeaderId == headerid);

            var tradeLevelResults = _context.ReportTradeOutputModels
                .Where(x => x.HeaderId == headerid);

            var tradeLevelResultDictionary = tradeLevelResults
                .GroupBy(x => x.Isin)
                .ToDictionary(x => x.Key, x => x.ToList());

            positionLevelResults.ForEachAsync(positionLevel =>
            {
                if (positionLevelResults.Any())
                {
                    var tradeLevel = tradeLevelResultDictionary[positionLevel.Isin];

                    if (tradeLevel.Any())
                    {
                        positionLevel.Notional = tradeLevel.Sum(td => td.Notional);
                        positionLevel.FactoredNotional = tradeLevel.Sum(td => td.FactoredNotional);
                    }
                }
            });

            return (Task<IEnumerable<ReportOutputModel>>)positionLevelResults;
        }
    }
}
