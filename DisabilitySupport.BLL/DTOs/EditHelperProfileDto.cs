using DisabilitySupport.DAL.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs
{
    public class EditHelperProfileDto : EditCommonProfileDto
    {
        public string? Bio { get; set; }
    }
}
