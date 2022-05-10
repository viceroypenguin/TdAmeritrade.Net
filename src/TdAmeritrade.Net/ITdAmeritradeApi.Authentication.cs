namespace TdAmeritrade;

using Models.Authentication;

public partial interface ITdAmeritradeApi
{
	/// <summary>
	/// This API allows the developer to obtain access and refresh tokens used to access other APIs
	/// </summary>
	/// <param name="loginRequest">
	/// The parameters for the login API
	/// </param>
	/// <returns>
	/// If successful, the return includes tokens used to access other APIs. 
	/// Upon failure, the return will include information about the failure.
	/// </returns>
	/// <remarks>
	/// See also: <seealso href="https://developer.tdameritrade.com/content/authentication-faq"/>
	/// </remarks>
	[Post("/v1/oauth2/token")]
	Task<ApiResponse<LoginResponse>> Login([Body(BodySerializationMethod.UrlEncoded)] LoginRequest loginRequest);
}
