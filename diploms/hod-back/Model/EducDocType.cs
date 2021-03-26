using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("EducDocTypes", Schema = "Import")]
    public partial class EducDocType
    {
        public EducDocType()
        {
            EducDocs = new HashSet<EducDoc>();
        }

        [Key]
        [Column("educDocType_id")]
        public int EducDocTypeId { get; set; }
        [Column("educDocType_name")]
        [StringLength(50)]
        public string EducDocTypeName { get; set; }
        [Column("isOld")]
        public bool? IsOld { get; set; }

        [InverseProperty(nameof(EducDoc.EducDocType))]
        public virtual ICollection<EducDoc> EducDocs { get; set; }
    }
}
