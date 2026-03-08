namespace Kakeibo_Front.Models;

public class UpdateTransactionRequest
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Memo { get; set; } = "";
    public int Amount { get; set; }
    public DateTime Date { get; set; }
}
