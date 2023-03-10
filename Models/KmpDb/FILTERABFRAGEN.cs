using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using Microsoft.EntityFrameworkCore;

namespace QwTest7.Models.KmpDb;

[Table("FILTERABFRAGEN")]
[Index("ANWE", "FORM", "NAME", Name = "UK_FLTR", IsUnique = true)]
public partial class FILTERABFRAGEN
{
    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string ANWE { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string FORM { get; set; }

    [Required]
    [StringLength(80)]
    [Unicode(false)]
    public string NAME { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string FLTRLIST { get; set; }

    [StringLength(80)]
    [Unicode(false)]
    public string KEYFIELDS { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string ISPUBLIC { get; set; }

    [Key]
    [Precision(9)]
    public int FLTR_ID { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string ERFASST_VON { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? ERFASST_AM { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string ERFASST_DATENBANK { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string GEAENDERT_VON { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime? GEAENDERT_AM { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string GEAENDERT_DATENBANK { get; set; }

    [Precision(9)]
    public int? ANZAHL_AENDERUNGEN { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string BEMERKUNG { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string COLUMNLIST { get; set; }
}
