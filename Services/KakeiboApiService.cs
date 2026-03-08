using System.Net.Http.Json;
using System.Text.Json;
using Kakeibo_Front.Models;

namespace Kakeibo_Front.Services;

public class KakeiboApiService
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };

    public KakeiboApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Transactions
    public async Task<IReadOnlyList<TransactionResponse>> GetAllTransactionsAsync(CancellationToken ct = default)
    {
        var response = await _httpClient.GetAsync("getAllTransactions", ct);
        response.EnsureSuccessStatusCode();
        var list = await response.Content.ReadFromJsonAsync<List<TransactionResponse>>(JsonOptions, ct);
        return list ?? new List<TransactionResponse>();
    }

    public async Task AddTransactionAsync(CreateTransactionRequest request, CancellationToken ct = default)
    {
        var response = await _httpClient.PostAsJsonAsync("addTransaction", request, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTransactionAsync(UpdateTransactionRequest request, CancellationToken ct = default)
    {
        var response = await _httpClient.PutAsJsonAsync("updateTransaction", request, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTransactionAsync(int id, CancellationToken ct = default)
    {
        var response = await _httpClient.DeleteAsync($"deleteTransaction/{id}", ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task RegisterSubscriptionsAsync(CancellationToken ct = default)
    {
        var response = await _httpClient.PostAsync("registerSubscriptions", null, ct);
        response.EnsureSuccessStatusCode();
    }

    // Categories
    public async Task<IReadOnlyList<CategoryResponse>> GetAllCategoriesAsync(CancellationToken ct = default)
    {
        var response = await _httpClient.GetAsync("getAllCategories", ct);
        response.EnsureSuccessStatusCode();
        var list = await response.Content.ReadFromJsonAsync<List<CategoryResponse>>(JsonOptions, ct);
        return list ?? new List<CategoryResponse>();
    }

    // Subscriptions
    public async Task<IReadOnlyList<SubscriptionResponse>> GetAllSubscriptionsAsync(CancellationToken ct = default)
    {
        var response = await _httpClient.GetAsync("getAllSubscriptions", ct);
        response.EnsureSuccessStatusCode();
        var list = await response.Content.ReadFromJsonAsync<List<SubscriptionResponse>>(JsonOptions, ct);
        return list ?? new List<SubscriptionResponse>();
    }

    public async Task CreateSubscriptionsAsync(CreateSubscriptionRequest request, CancellationToken ct = default)
    {
        var response = await _httpClient.PostAsJsonAsync("createSubscriptions", request, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateSubscriptionsAsync(UpdateSubscriptionRequest request, CancellationToken ct = default)
    {
        var response = await _httpClient.PutAsJsonAsync("updateSubscriptions", request, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteSubscriptionsAsync(int id, CancellationToken ct = default)
    {
        var response = await _httpClient.DeleteAsync($"deleteSubscriptions/{id}", ct);
        response.EnsureSuccessStatusCode();
    }

    // Summary (API は Summay の typo)
    public async Task<IReadOnlyList<MonthlySummaryResponse>> GetAllSummayAsync(CancellationToken ct = default)
    {
        var response = await _httpClient.GetAsync("getAllSummay", ct);
        response.EnsureSuccessStatusCode();
        var list = await response.Content.ReadFromJsonAsync<List<MonthlySummaryResponse>>(JsonOptions, ct);
        return list ?? new List<MonthlySummaryResponse>();
    }

    public async Task CreateSummayAsync(CancellationToken ct = default)
    {
        var response = await _httpClient.PostAsync("createSummay", null, ct);
        response.EnsureSuccessStatusCode();
    }
}
