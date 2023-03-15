using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVA.IPV.ReportPublication.Model.Data
{
    public class UploadModel
    {
        [Required(AllowEmptyStrings = false)]
        public string UploadKey { get; set; }

        [Required]
        public bool Compress { get; set; }
        public int RowCount { get; set; }
        public string OutPutStream { get; set; }
    }
}
