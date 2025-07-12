using DisabilitySupport.DAL.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.Disabled
{
    public class EditPatientProfileDto : EditCommonProfileDto
    {
        public string? DisabilityType { get; set; }
        public string? MedicalConditionDescription { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? EmergencyContactRelation { get; set; }
    }
}
