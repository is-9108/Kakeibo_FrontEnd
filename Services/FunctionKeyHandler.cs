namespace Kakeibo_Front.Services;

/// <summary>
/// Azure Functions の function key をリクエストに ?code=xxx で付与するハンドラー。
/// </summary>
public sealed class FunctionKeyHandler : DelegatingHandler
{
    private readonly string? _functionKey;

    public FunctionKeyHandler(string? functionKey)
    {
        _functionKey = string.IsNullOrWhiteSpace(functionKey) ? null : functionKey;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (_functionKey != null && request.RequestUri != null)
        {
            var uri = request.RequestUri.ToString();
            var separator = uri.Contains('?') ? "&" : "?";
            request.RequestUri = new Uri(uri + separator + "code=" + _functionKey);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
