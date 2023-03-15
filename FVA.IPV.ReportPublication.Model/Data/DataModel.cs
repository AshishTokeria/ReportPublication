using FVA.IPV.ReportPublication.WebUtil;
using System.Reflection;

namespace FVA.IPV.ReportPublication.Model.Data
{
    public class DataModel
    {
        const char Separator = ',';

        public string ToCsvString(List<PropertyInfo> properties)
        {
            var orderedProperties = properties.OrderBy(m => m.GetCustomAttribute<GridColumnAttribue>() == null 
                                    ? -1
                                    : m.GetCustomAttribute<GridColumnAttribue>().ColumnOrder).ToList();

            var values = string.Join(Separator, orderedProperties.Select(PropertyValue));

            return values;
        }

        public virtual string GetCsvHeaders()
        {
            PropertyInfo[] pinfos = GetType().GetProperties();
            List<string> attributes = new List<string>();
            foreach (PropertyInfo pi in pinfos)
            {
                if (pi.CanRead)
                {
                    var ca = GridColumnAttribue.GetAttribueFromPeopertyInfo(pi, Constants.REPORT);

                    if (ca != null && ca.Visible)
                    {
                        attributes.Add(ca.Caption);
                    }
                }
            }

            return string.Join(Separator, attributes);
        }

        public List<PropertyInfo> GetProperties()
        {
            PropertyInfo[] propertyInfo = GetType().GetProperties();
            List<PropertyInfo> properties = new List<PropertyInfo>();

            foreach(PropertyInfo pi in propertyInfo)
            {
                if (pi.CanRead)
                {
                    GridColumnAttribue ca = GridColumnAttribue.GetAttribueFromPeopertyInfo(pi, Constants.REPORT);
                    if(ca != null && ca.Visible)
                    {
                        properties.Add(pi);
                    }
                }
            }

            return properties;
        }

        private object PropertyValue(PropertyInfo property)
        {
            var value = property.GetValue(this);

            if(value != null && property.PropertyType == typeof(string))
            {
                return $@"{((string)value)
                    .Replace("\n", "")
                    .Replace("\r","")
                    .Replace(Separator, ' ')
                    .Replace(@"""", @"'")}";
            }

            return value;
        }
    }
}
