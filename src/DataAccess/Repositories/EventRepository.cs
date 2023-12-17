﻿using Microsoft.EntityFrameworkCore;
using Ticketing.Domain.Interfaces.Repositories;
using Ticketing.Domain.Entities.Event;

namespace Ticketing.DataAccess.Repositories;

public class EventRepository : IEventRepository
{
    private readonly DataContext context;

    public EventRepository(DataContext context)
    {
        this.context = context;
    }

    public async Task<Event?> GetAsync(int eventId, CancellationToken cancellation)
    {
        return await this.context.Events.SingleAsync(e => e.Id == eventId, cancellation);
    }

    public async Task<IEnumerable<EventSeat>> GetSeatsAsync(int eventId, int sectionId, CancellationToken cancellation)
    {
        return await this.context.EventSeats
            .Where(seat => seat.Row!.Section!.Id == sectionId && seat.Row!.Section!.Event!.Id == eventId)
            .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<Event>?> ListAsync(CancellationToken cancellation)
    {
        return await this.context.Events.ToArrayAsync(cancellation);
    }
}
