using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[Table("County")]
public partial class County : IEntity
{
    [Key]
    public int Id { get; set; }

    public int CityId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [ForeignKey("CityId")]
    [InverseProperty("Counties")]
    public virtual City City { get; set; } = null!;

    [InverseProperty("County")]
    public virtual ICollection<Hometown> Hometowns { get; set; } = new List<Hometown>();

}
