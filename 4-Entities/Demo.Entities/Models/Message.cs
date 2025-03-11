using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[PrimaryKey("Code", "Langu")]
public partial class Message : IEntity
{
    [Key]
    [StringLength(100)]
    public string Code { get; set; } = null!;

    [StringLength(500)]
    public string Desc { get; set; } = null!;

    public int GroupId { get; set; }

    [Key]
    [StringLength(5)]
    public string Langu { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("Messages")]
    public virtual MessageGroup Group { get; set; } = null!;
}
