using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("EducDocs", Schema = "Import")]
    public partial class EducDoc
    {
        [Key]
        [Column("educDoc_id")]
        public int EducDocId { get; set; }
        [Column("educDocType_id")]
        public int? EducDocTypeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateExpired { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DocDate { get; set; }

        [ForeignKey(nameof(EducDocTypeId))]
        [InverseProperty("EducDocs")]
        public virtual EducDocType EducDocType { get; set; }
    }
}
