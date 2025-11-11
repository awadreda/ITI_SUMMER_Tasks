using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentMVC_ITI.Models;

[Table("Topic")]
public partial class Topic
{
    [Key]
    [Column("Top_Id")]
    public int TopId { get; set; }

    [Column("Top_Name")]
    [StringLength(50)]
    public string? TopName { get; set; }

    [InverseProperty("Top")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
