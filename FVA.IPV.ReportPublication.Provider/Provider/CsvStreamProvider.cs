using FVA.IPV.ReportPublication.Model.Data;
using System.Text;

namespace FVA.IPV.ReportPublication.Provider.Provider
{
    public interface ICsvStreamProvider
    {
        string GenerateCsvStream(IEnumerable<DataModel> dataModel);
    }

    public class CsvStreamProvider : ICsvStreamProvider
    {
        public string GenerateCsvStream(IEnumerable<DataModel> dataModel)
        {
            var sb = new StringBuilder();

            sb.AppendLine(dataModel.First().GetCsvHeaders());
            var property = dataModel.First().GetProperties();
            
            foreach ( var model in dataModel)
            {
                sb.AppendLine(model.ToCsvString(property));
            }
            return sb.ToString();
        }
    }
}
