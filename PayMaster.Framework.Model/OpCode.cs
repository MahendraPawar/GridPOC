using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web.Mvc;

namespace PayMaster.Framework.Model
{
    [DataContract]
    public class OpCode 
    {
        [DataMember]
        public Int64 OpcodeId { get; set; }

        [DataMember]
        [Required]
        [StringLength(40)]
        [Display(Name = "Opcode Name")]
        [Remote("CheckOpCodeName", "OpCode", HttpMethod = "POST", ErrorMessage = "Opcode Name already exist!", AdditionalFields = "OpcodeId")]
        public string OpcodeName { get; set; }

        [DataMember]
        [StringLength(50)]
        [Display(Name = "Opcode Description")]
        public string OpcodeDescription { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Program")]
        public string ProgramId { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [IgnoreDataMember]
        public SelectList ProgramList { get; set; }
    }
}
