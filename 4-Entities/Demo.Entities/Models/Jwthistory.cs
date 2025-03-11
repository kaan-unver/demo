using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Models;

namespace Demo.Entities.Models;

[Table("JWTHistory")]
public partial class Jwthistory : IEntity
{
    [Key]
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public Guid UserId { get; set; }

    public Guid CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
