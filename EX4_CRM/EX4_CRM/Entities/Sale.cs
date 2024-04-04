namespace EX4_CRM.Entities;

public class Sale
{
    public long Id { get; set; }

    public required long LeadId { get; set; }

    public required long SalesmanId { get; set; }

    public required DateTime SoldOn { get; set; }

    public Lead? Lead { get; set; }

    public User? Salesman { get; set; }
}
