using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using Microsoft.EntityFrameworkCore;

namespace QwTest7.Models.KmpDb;

[Table("INITIALISIERUNGEN")]
[Index("ANWENDUNG", "TYP", "NAME", "SECTION", "PARAM", Name = "UK_INIT", IsUnique = true)]
public partial class INITIALISIERUNGEN
{
    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string ANWENDUNG { get; set; }

    [Required]
    [StringLength(1)]
    [Unicode(false)]
    public string TYP { get; set; }

    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string NAME { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string SECTION { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string PARAM { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string WERT { get; set; }

    [Key]
    [Precision(9)]
    public int INIT_ID { get; set; }

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
}
