using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[Table("Hometown")]
public partial class Hometown : IEntity
{
    [Key]
    public int Id { get; set; }

    public int CountyId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [ForeignKey("CountyId")]
    [InverseProperty("Hometowns")]
    public virtual County County { get; set; } = null!;
}
