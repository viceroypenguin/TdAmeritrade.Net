namespace TdAmeritrade.Internal;

using Models.Transactions;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// Search transactions for a specific account
	/// </summary>
	/// <param name="token">
	/// A current and valid <see cref="Models.Authentication.LoginResponse.AccessToken"/>.
	/// </param>
	/// <param name="accountId">The account to search transactions</param>
	/// <param name="searchOptions">Search filters for the transactions</param>
	/// <returns>
	/// If successful, the return includes a list of associated accounts and information about each. 
	/// </returns>
	/// <exception cref="ApiException" />
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/transaction-history/apis/get/accounts/%7BaccountId%7D/transactions-0"/>
	/// </remarks>
	[Get("/v1/accounts/{accountId}/transactions")]
	Task<IReadOnlyList<Transaction>> GetTransactions([Authorize] string token, string accountId, TransactionSearchOptions? searchOptions);
}
