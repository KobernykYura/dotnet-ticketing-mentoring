﻿namespace Ticketing.DataAccess.Models.Event;

public class EventSeat
{
    public required int Id { get; set; }
    public required int RowId { get; set; }
    public required decimal Price { get; set; }
}
