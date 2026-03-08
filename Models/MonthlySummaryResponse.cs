namespace Kakeibo_Front.Models;

public record MonthlySummaryResponse(
    string Month,
    int Shuusi,
    int Shokuhi,
    int Gaishokuhi,
    int Kounetsuhi,
    int Tsuusinhi,
    int Suidouhi,
    int Koutsuhi,
    int Iryouhi,
    int Zeikin,
    int Yachin,
    int Subscription,
    int Sonota,
    int Kyuryo,
    int RinjiShunyu
);
