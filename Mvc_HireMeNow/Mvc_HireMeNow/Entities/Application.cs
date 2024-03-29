﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mvc_HireMeNow.Models;

public partial class Application
{
	[Key]
	[Required]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
	[ForeignKey(nameof(User))]
	public Guid? UserId { get; set; }
	[ForeignKey(nameof(Job))]
	public Guid? JobId { get; set; }

	[ForeignKey(nameof(Company))]
	public Guid? CompanyId { get; set; }

	public DateTime? AppliedDate { get; set; }

    public string? Status { get; set; }

    public virtual Job? Job { get; set; }

    public virtual User? User { get; set; }
	public virtual Company? Company { get; set; }
}
