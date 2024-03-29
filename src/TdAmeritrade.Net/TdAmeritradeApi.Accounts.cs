﻿namespace TdAmeritrade;

using Models.Accounts;

public partial class TdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get a list of accounts for the specified login
	/// </summary>
	/// <param name="fields">
	/// Balances displayed by default, additional fields can be added here by adding <c>positions</c> or <c>orders</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes a list of associated accounts and information about each. 
	/// </returns>
	/// <exception cref="ArgumentNullException" />
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/account-access/apis/get/accounts-0"/>
	/// </remarks>
	public Task<IReadOnlyList<AccountContainer>> GetAccounts(IReadOnlyList<string>? fields = default) =>
		GetAccounts(refreshToken: default, fields);

	/// <summary>
	/// This API allows the developer to get a list of accounts for the specified login
	/// </summary>
	/// <param name="refreshToken">A refresh token generated by TD Ameritrade APIs for authentication.</param>
	/// <param name="fields">
	/// Balances displayed by default, additional fields can be added here by adding <c>positions</c> or <c>orders</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes a list of associated accounts and information about each. 
	/// </returns>
	/// <exception cref="ArgumentNullException" />
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/account-access/apis/get/accounts-0"/>
	/// </remarks>
	public async Task<IReadOnlyList<AccountContainer>> GetAccounts(string? refreshToken, IReadOnlyList<string>? fields = default)
	{
		refreshToken ??= _refreshToken;
		if (refreshToken == null)
			throw new ArgumentNullException(nameof(refreshToken), "GetAccounts API requires a refreshToken.");

		var accessToken = await GetAccessToken(refreshToken).ConfigureAwait(false);
		return await _api.GetAccounts(accessToken, fields).ConfigureAwait(false);
	}

	/// <summary>
	/// This API allows the developer to get information about a specific account
	/// </summary>
	/// <param name="accountId">
	/// The id of the account
	/// </param>
	/// <param name="fields">
	/// Balances displayed by default, additional fields can be added here by adding <c>positions</c> or <c>orders</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the requested account. 
	/// </returns>
	/// <exception cref="ArgumentNullException" />
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/account-access/apis/get/accounts/%7BaccountId%7D-0"/>
	/// </remarks>
	public Task<AccountContainer> GetAccount(string accountId, IReadOnlyList<string>? fields = default) =>
		GetAccount(refreshToken: default, accountId, fields);

	/// <summary>
	/// This API allows the developer to get information about a specific account
	/// </summary>
	/// <param name="refreshToken">A refresh token generated by TD Ameritrade APIs for authentication.</param>
	/// <param name="accountId">
	/// The id of the account
	/// </param>
	/// <param name="fields">
	/// Balances displayed by default, additional fields can be added here by adding <c>positions</c> or <c>orders</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the requested account. 
	/// </returns>
	/// <exception cref="ArgumentNullException" />
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/account-access/apis/get/accounts/%7BaccountId%7D-0"/>
	/// </remarks>
	public async Task<AccountContainer> GetAccount(string? refreshToken, string accountId, IReadOnlyList<string>? fields = default)
	{
		refreshToken ??= _refreshToken;
		if (refreshToken == null)
			throw new ArgumentNullException(nameof(refreshToken), "GetAccounts API requires a refreshToken.");

		var accessToken = await GetAccessToken(refreshToken).ConfigureAwait(false);
		return await _api.GetAccount(accessToken, accountId, fields).ConfigureAwait(false);
	}
}
