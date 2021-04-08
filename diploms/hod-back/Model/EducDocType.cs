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
        [Column("eDocT_id")]
        public int EDocTId { get; set; }
        [Column("eDocT_name")]
        [StringLength(100)]
        public string EDocTName { get; set; }

        [InverseProperty(nameof(EducDoc.EDocT))]
        public virtual ICollection<EducDoc> EducDocs { get; set; }
    }
}
