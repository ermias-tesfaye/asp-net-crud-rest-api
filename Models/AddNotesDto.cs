using System;

namespace asp.net_crud.Models;

public class AddNotesDto
{
   public Guid Id { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }
}
