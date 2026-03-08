namespace Kakeibo_Front.Models;

public class UpdateSubscriptionRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Amount { get; set; }
}
