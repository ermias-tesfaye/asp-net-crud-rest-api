using System;

namespace asp.net_crud.Models.Entities;

public class Note
{
    public Guid Id { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

}
