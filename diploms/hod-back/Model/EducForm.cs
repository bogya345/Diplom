using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace hod_back.Model
{
    [Table("EducForms", Schema = "Import")]
    public partial class EducForm
    {
        public EducForm()
        {
            Directions = new HashSet<Direction>();
        }

        [Key]
        [Column("eForm_id")]
        public int EFormId { get; set; }
        [Column("eForm_name")]
        [StringLength(100)]
        public string EFormName { get; set; }
        [Column("eForm_adjactive")]
        [StringLength(100)]
        public string EFormAdjactive { get; set; }

        [InverseProperty(nameof(Direction.EForm))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
