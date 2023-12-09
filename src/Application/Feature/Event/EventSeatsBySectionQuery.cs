﻿using Ticketing.Application.CQRS;
using Ticketing.Domain;

namespace Ticketing.Application;

public record EventSeatsBySectionResponse(IEnumerable<EventSeatDetails> EventSeats);
public record EventSeatsBySectionRequest(int EventId, int SectionId);

/// <summary>
/// Returns the list of seats (section_id, row_id, seat_id)
/// with seats’ status (id, name) and price options (id, name)
/// </summary>
public class EventSeatsBySectionQuery : IQueryHandler<EventSeatsBySectionRequest, EventSeatsBySectionResponse>
{
    private readonly IEventRepository repository;

    public EventSeatsBySectionQuery(IEventRepository repository)
    {
        this.repository = repository;
    }

    public async Task<EventSeatsBySectionResponse> ExecuteAsync(
        EventSeatsBySectionRequest request,
        CancellationToken cancellation
    )
    {
        var seats = await this.repository.GetSeatsAsync(request.EventId, request.SectionId, cancellation);
        var seatDetails = seats.Select(EventSeatMapper.ToDetailedResponse);

        return new EventSeatsBySectionResponse(seatDetails);
    }
}
