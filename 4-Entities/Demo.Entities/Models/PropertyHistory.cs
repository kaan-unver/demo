using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[PrimaryKey("Key", "Environment", "IsDeleted")]
public partial class PropertyHistory : IEntity
{
    public Guid Id { get; set; }

    [Key]
    [StringLength(50)]
    public string Key { get; set; } = null!;

    [StringLength(500)]
    public string OldValue { get; set; } = null!;

    [StringLength(500)]
    public string NewValue { get; set; } = null!;

    [Key]
    [StringLength(50)]
    public string Environment { get; set; } = null!;

    public Guid? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [Key]
    public bool IsDeleted { get; set; }
}
