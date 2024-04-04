using Domain.Enums;

namespace Domain.Entities;

public class Lead
{
    public long Id { get; set; }

    public required long ContactId { get; set; }

    public required long SalesmanId { get; set; }

    public required LeadStatus Status { get; set; }

    public Contact? Contact { get; set; }

    public User? Salesman { get; set; }
}
