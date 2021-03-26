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
        [Column("educForm_id")]
        public int EducFormId { get; set; }
        [Column("educForm_name")]
        [StringLength(50)]
        public string EducFormName { get; set; }
        [Column("educForm_adjective")]
        [StringLength(50)]
        public string EducFormAdjective { get; set; }

        [InverseProperty(nameof(Direction.EducForm))]
        public virtual ICollection<Direction> Directions { get; set; }
    }
}
