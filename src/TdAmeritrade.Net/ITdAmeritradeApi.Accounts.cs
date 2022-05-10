namespace TdAmeritrade;

using Models.Accounts;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to get a list of accounts for the specified login
	/// </summary>
	/// <param name="token">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>
	/// </param>
	/// <param name="fields">
	/// Balances displayed by default, additional fields can be added here by adding <c>positions</c> or <c>orders</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes a list of associated accounts and information about each. 
	/// Upon failure, the return will include information about the failure.
	/// </returns>
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/account-access/apis/get/accounts-0"/>
	/// </remarks>
	[Get("/v1/accounts")]
	Task<ApiResponse<IReadOnlyList<AccountContainer>>> GetAccounts([Authorize("Bearer")] string? token, [Query(CollectionFormat = CollectionFormat.Csv)] IReadOnlyList<string>? fields = default);

	/// <summary>
	/// This API allows the developer to get information about a specific account
	/// </summary>
	/// <param name="token">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>
	/// </param>
	/// <param name="accountId">
	/// The id of the account
	/// </param>
	/// <param name="fields">
	/// Balances displayed by default, additional fields can be added here by adding <c>positions</c> or <c>orders</c>.
	/// </param>
	/// <returns>
	/// If successful, the return includes information about the requested account. 
	/// Upon failure, the return will include information about the failure.
	/// </returns>
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/account-access/apis/get/accounts/%7BaccountId%7D-0"/>
	/// </remarks>
	[Get("/v1/accounts/{accountId}")]
	Task<ApiResponse<AccountContainer>> GetAccount([Authorize("Bearer")] string? token, string? accountId, [Query(CollectionFormat = CollectionFormat.Csv)] IReadOnlyList<string>? fields = default);
}
