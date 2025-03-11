using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[Table("User")]
public partial class User : IEntity
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [StringLength(500)]
    public string Password { get; set; } = null!;

    [StringLength(500)]
    public string? FirstName { get; set; }

    [StringLength(500)]
    public string? MiddleName { get; set; }

    [StringLength(500)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;
    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
    public Guid? PPId { get; set; }
}
