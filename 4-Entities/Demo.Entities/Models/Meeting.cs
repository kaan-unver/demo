using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[Table("Meeting")]
public partial class Meeting : IEntity
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public Guid? FileId { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
