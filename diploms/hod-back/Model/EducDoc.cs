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
        public EducDoc()
        {
            InverseOrg = new HashSet<EducDoc>();
        }

        [Key]
        [Column("eDoc_id")]
        public int EDocId { get; set; }
        [Column("eDocT_id")]
        public int? EDocTId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateExpired { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DocDate { get; set; }
        [StringLength(100)]
        public string DocSeries { get; set; }
        [StringLength(100)]
        public string DocNumber { get; set; }
        [Column("org_id")]
        public int? OrgId { get; set; }

        [ForeignKey(nameof(EDocTId))]
        [InverseProperty(nameof(EducDocType.EducDocs))]
        public virtual EducDocType EDocT { get; set; }
        [ForeignKey(nameof(OrgId))]
        [InverseProperty(nameof(EducDoc.InverseOrg))]
        public virtual EducDoc Org { get; set; }
        [InverseProperty(nameof(EducDoc.Org))]
        public virtual ICollection<EducDoc> InverseOrg { get; set; }
    }
}
