namespace Kakeibo_Front.Models;

public class CreateTransactionRequest
{
    public int CategoryId { get; set; }
    public string Memo { get; set; } = "";
    public int Amount { get; set; }
    public DateTime Date { get; set; } = DateTime.Today;
}
