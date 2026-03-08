namespace Kakeibo_Front.Models;

public record TransactionResponse(int Id, string Category, string Memo, int Amount, DateTime Date);
