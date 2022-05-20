﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace TdAmeritrade;

using Internal;
using Microsoft.Extensions.Primitives;

public partial class TdAmeritradeApi
{
	#region Initialization
	private readonly string _clientId;
	private readonly string? _refreshToken;
	private readonly ITdAmeritradeApi _api;
	private readonly IMemoryCache _memoryCache;
	private readonly ILogger _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="TdAmeritradeApi"/> class.
	/// </summary>
	/// <param name="clientId">The client id provided by TD Ameritrade for this application.</param>
	/// <param name="refreshToken">A refresh token generated by TD Ameritrade APIs for authentication. If not provided, a <c>refreshToken</c> will be required on all API calls that need them.</param>
	/// <param name="api">The instance of the <see cref="ITdAmeritradeApi"/> interface, provided by Refit library, to use for API calls. If not provided, this constructor will generate one automatically.</param>
	/// <param name="memoryCache">The instance of the memory cache to use for caching access tokens. If not provided, this constructor will generate one automatically.</param>
	/// <param name="logger">The instance of the logger to be used for logging events.</param>
	public TdAmeritradeApi(
		string clientId,
		string? refreshToken = default,
		ITdAmeritradeApi? api = default,
		IMemoryCache? memoryCache = default,
		ILogger<TdAmeritradeApi>? logger = default)
	{
		if (api == null || memoryCache == null)
		{
			var collection = new ServiceCollection();
			collection.AddITdAmeritradeApiRefitClient();
			collection.AddMemoryCache();

			var sp = collection.BuildServiceProvider();
			api ??= sp.GetRequiredService<ITdAmeritradeApi>();
			memoryCache ??= sp.GetRequiredService<IMemoryCache>();
		}

		_clientId = clientId;
		_refreshToken = refreshToken;
		_api = api;
		_memoryCache = memoryCache;
		_logger = logger ?? new NullLogger<TdAmeritradeApi>();
	}
	#endregion

	#region Access Token Management
	private static readonly Action<ILogger, Exception?> s_logAccessTokenFound =
		LoggerMessage.Define(
			LogLevel.Trace, 101, "Access token found in cache; using cached value.");

	private static readonly Action<ILogger, Guid, Exception?> s_logGeneratingToken =
		LoggerMessage.Define<Guid>(
			LogLevel.Trace, 102, "Generating access token (Attempt id: {AttemptId})");

	private static readonly Action<ILogger, Guid, Exception?> s_logGeneratedToken =
		LoggerMessage.Define<Guid>(
			LogLevel.Trace, 103, "Generated access token (Attempt id: {AttemptId})");

	private static readonly Action<ILogger, string, string, EvictionReason, Exception?> s_logEviction =
		LoggerMessage.Define<string, string, EvictionReason>(
			LogLevel.Trace, 201, "Token Evicted. (Refresh Token: {RefreshToken}, Access Token: {AccessToken}, Reason: {Reason})");

	private static readonly Action<ILogger, Guid, string?, Exception?> s_logAccessTokenFail =
		LoggerMessage.Define<Guid, string?>(
			LogLevel.Error, 501, "Unable to generate access token. (Attempt id: {AttemptId}, Response: {Response})");

	private async Task<string> GetAccessToken(string refreshToken)
	{
		if (_memoryCache.TryGetValue(refreshToken, out string accessToken))
		{
			s_logAccessTokenFound(_logger, default);
			return accessToken;
		}

		return await _memoryCache.GetOrCreateAsync(
			refreshToken,
			async ce =>
			{
				var token = new CancellationChangeToken(
					new CancellationTokenSource(TimeSpan.FromMinutes(30)).Token);
				ce.ExpirationTokens.Add(token);
				if (_logger.IsEnabled(LogLevel.Trace))
					ce.PostEvictionCallbacks.Add(
						new()
						{
							State = _logger,
							EvictionCallback = (key, value, reason, logger) =>
							{
								s_logEviction(
									(logger as ILogger)!,
									(key as string)!,
									(value as string)!,
									reason,
									default);
							},
						});

				var attemptId = Guid.NewGuid();
				s_logGeneratingToken(_logger, attemptId, default);

				try
				{
					var content = await _api
						.Login(new Models.Authentication.LoginRequest
						{
							ClientId = _clientId,
							RefreshToken = refreshToken,
							GrantType = Models.Authentication.GrantType.RefreshToken,
						})
						.ConfigureAwait(false);

					s_logGeneratedToken(_logger, attemptId, default);

					return content.TokenType + " " + content.AccessToken;
				}
				catch (ApiException ex)
				{
					s_logAccessTokenFail(_logger, attemptId, ex.Content, ex);
					throw;
				}
			}).ConfigureAwait(false);
	}
	#endregion

	public Uri GetOAuthUrl(string applicationUrl) =>
		new($"https://auth.tdameritrade.com/auth?response_type=code&redirect_uri={Uri.EscapeDataString(applicationUrl)}&client_id={_clientId}%40AMER.OAUTHAP");
}
