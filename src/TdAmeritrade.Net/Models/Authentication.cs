﻿namespace TdAmeritrade.Models.Authentication;

/// <summary>
/// The parameters for the login API
/// </summary>
public class LoginRequest
{
	/// <summary>
	/// The grant type of the oAuth scheme.
	/// </summary>
	/// <value>Valid values are <c>"authorization_code"</c> if <see cref="Code"/> is provided, or <c>"refresh_token"</c> if <see cref="RefreshToken"/> is provided.</value>
	[AliasAs("grant_type")]
	public string GrantType { get; set; } = string.Empty;

	/// <summary>
	/// Previously provided Refresh Token
	/// </summary>
	/// <remarks>
	/// Required if using refresh token grant
	/// </remarks>
	[AliasAs("refresh_token")]
	public string? RefreshToken { get; set; }

	/// <summary>
	/// Set to <c>"offline"</c> to receive a refresh token on an <c>"authorization_code"</c> grant type request. 
	/// Do not set to offline on a <c>"refresh_token"</c> grant type request when getting an access token.
	/// </summary>
	[AliasAs("access_type")]
	public string? AccessType { get; set; }

	/// <summary>
	/// A code provided by the TD Ameritrade website upon login. 
	/// </summary>
	/// <remarks>
	/// Required if trying to use authorization code grant
	/// </remarks>
	[AliasAs("code")]
	public string? Code { get; set; }

	/// <summary>
	/// OAuth User ID of your application
	/// </summary>
	/// <remarks>
	/// Labeled Consumer Key under My Applications
	/// </remarks>
	[AliasAs("client_id")]
	public string ClientId { get; set; } = default!;

	/// <summary>
	/// Required if trying to use authorization code grant
	/// </summary>
	/// <remarks>
	/// Must match Redirect URI provided in My Applications for the application
	/// </remarks>
	[AliasAs("redirect_uri")]
	public string RedirectUri { get; set; } = default!;
}

/// <summary>
/// The response of the Login API
/// </summary>
public class LoginResponse
{
	/// <summary>
	/// The Access Token generated by this API
	/// </summary>
	/// <remarks>
	/// This token is required by all other APIs
	/// </remarks>
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; } = default!;

	/// <summary>
	/// The long-term storage refresh token
	/// </summary>
	[JsonPropertyName("refresh_token")]
	public string? RefreshToken { get; set; }

	/// <summary>
	/// The authentication type to be used with the <see cref="AccessToken"/> in other APIs
	/// </summary>
	[JsonPropertyName("token_type")]
	public string TokenType { get; set; } = default!;

	/// <summary>
	/// How many seconds before the <see cref="AccessToken"/> expires.
	/// </summary>
	[JsonPropertyName("expires_in")]
	public int? ExpiresIn { get; set; }

	/// <summary>
	/// Which APIs are allowed for the current token
	/// </summary>
	[JsonPropertyName("scope")]
	public string Scope { get; set; } = default!;

	/// <summary>
	/// How many seconds before the <see cref="RefreshToken"/> expires.
	/// </summary>
	[JsonPropertyName("refresh_token_expires_in")]
	public int? RefreshTokenExpiresIn { get; set; }
}
