using System.Linq;
using System.Reflection;

namespace FVA.IPV.ReportPublication.WebUtil
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class GridColumnAttribue : Attribute
    {
        public GridColumnAttribue()
        {
            ViewName = string.Empty;
            ColumnOrder = 0;
            ColumnName = string.Empty;
            DisplayMember = false;
            ValueMember = false;
            Visible = false;
            Caption = string.Empty;
        }

        public string ViewName { get; set; } = string.Empty;
        public int ColumnOrder { get; set; } = 0;
        public string ColumnName { get; set; } = string.Empty;
        public bool DisplayMember { get; set; } = false;
        public bool ValueMember { get; set; } = false;
        public bool Visible { get; set; } = false;
        public string Caption { get; set; } = string.Empty;


        public static GridColumnAttribue? GetAttribueFromPeopertyInfo(PropertyInfo pi, string viewName)
        {
            GridColumnAttribue? gridColumnAttribue = null;

            object[] attributes = pi.GetCustomAttributes(typeof(GridColumnAttribue), true);

            if (attributes.Length > 0)
            {
                IEnumerable<GridColumnAttribue> gridColumnAttribues = attributes.Cast<GridColumnAttribue>();
                gridColumnAttribue = gridColumnAttribues.FirstOrDefault(i => i.ViewName.Equals(viewName, StringComparison.Ordinal));
            }

            return gridColumnAttribue;
        }
    }
}