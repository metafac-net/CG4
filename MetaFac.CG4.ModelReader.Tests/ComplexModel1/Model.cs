using MetaFac.CG4.Attributes;
using System;

namespace MetaFac.CG4.ModelReader.Tests.ComplexModel1
{
    /// <summary>
    /// A deep model with one base type.
    /// </summary>

    // ==================== Level 0 fields ====================

    [Entity(1)]
    public class BaseMessage
    {
        [Member(1)] Guid RequestId { get; }
    }

    [Entity(2)]
    public class BaseRequest : BaseMessage
    {
    }

    [Entity(3)]
    public class BaseResponse : BaseMessage
    {
        [Member(2)] bool Succeeded { get; }
        [Member(3)] string? FailReason { get; }
        [Member(4)] LogMessage[]? Messages { get; }
    }

    [Entity(4)]
    public class LogMessage
    {
        [Member(1)] int Severity { get; }
        [Member(2)] string? MessageTemplate { get; }
        [Member(3)] string[]? MessageParameters { get; }
    }

    [Entity(5)]
    public class NameValuePair
    {
        [Member(1)] string? Name { get; }
        [Member(2)] string? Value { get; }
    }

    //==================== Level 1 fields ====================

    [Entity(11)]
    public class GetServerInfoRequest : BaseRequest
    {
    }

    [Entity(12)]
    public class GetServerInfoResponse : BaseResponse
    {
        [Member(11, ModelState.Deprecated, "Deprecated")] 
        string? Obsolete01 { get; } // was ServerInfo

        [Member(12)] NameValuePair[]? ServerProperties { get; }
    }

    [Entity(21)]
    public class AccountRequest : BaseRequest
    {
    }

    [Entity(22)]
    public class AccountResponse : BaseResponse
    {
    }

    //==================== Level 2 fields ====================

    [Entity(23)]
    public class GetNewAccountIdRequest : AccountRequest
    {
    }

    [Entity(24)]
    public class GetNewAccountIdResponse : AccountResponse
    {
        [Member(21)] string? CreateToken { get; }
    }

    [Entity(25)]
    public class CreateAccountRequest : AccountRequest
    {
        [Member(21)] string? CreateToken { get; }
        [Member(22)] string? ShortName { get; }
        [Member(23)] string? PrimaryEmailAddress { get; }
        [Member(24)] string? BackupEmailAddress { get; }
    }

    [Entity(26)]
    public class CreateAccountResponse : AccountResponse
    {
        [Member(21)] string? VerifyToken { get; }
    }

    [Entity(27)]
    public class VerifyAccountRequest : AccountRequest
    {
        [Member(21)] string? VerifyToken { get; }
        [Member(25)] string? PrimaryEmailVerifyCode { get; }
        [Member(26)] string? BackupEmailVerifyCode { get; }
    }

    [Entity(28)]
    public class VerifyAccountResponse : AccountResponse
    {
        [Member(21)] string? AccessToken { get; }
    }

    [Entity(29)]
    public class ModifyAccountRequest : AccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(22)] string? ShortName { get; }
        [Member(23)] string? PrimaryEmailAddress { get; }
        [Member(24)] string? BackupEmailAddress { get; }
    }

    [Entity(30)]
    public class ModifyAccountResponse : AccountResponse
    {
        [Member(21)] string? VerifyToken { get; }
    }

    [Entity(33)]
    public class GetSecretRequest : AccountRequest
    {
        [Member(20)] string? LicenseCode { get; }
        [Member(21)] Guid SecretGuid { get; }
    }

    [Entity(34)]
    public class GetSecretResponse : AccountResponse
    {
        [Member(21)] Guid SecretGuid { get; }
        [Member(22)] string? SecretText { get; }
    }

    [Entity(35)]
    public class GetAdminTokenRequest : AccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(22)] string? MasterToken { get; }
    }

    [Entity(36)]
    public class GetAdminTokenResponse : AccountResponse
    {
        [Member(21)] string? AdminToken { get; }
    }

    [Entity(37)]
    public class AddSecretRequest : AccountRequest
    {
        [Member(20)] string? AdminToken { get; }
        [Member(21)] Guid SecretGuid { get; }
        [Member(22)] string? SecretText { get; }
    }

    [Entity(38)]
    public class AddSecretResponse : AccountResponse
    {
    }

    [Entity(41)]
    public class CommencePurchaseRequest : AccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(22)] CreditCardDetails? CreditCard { get; }
        [Member(23)] string? LicenseTier { get; }
    }

    [Entity(42)]
    public class CommencePurchaseResponse : AccountResponse
    {
    }

    [Entity(43)]
    public class CompletePurchaseRequest : AccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(25)] string? VerifyCode { get; }
    }

    [Entity(44)]
    public class CompletePurchaseResponse : AccountResponse
    {
        [Member(21)] string? LicenseCode { get; }
    }

    [Entity(45)]
    public class CreditCardDetails
    {
        [Member(1)] string? Number { get; }
        [Member(2)] ushort ExpiryYear { get; } // YYYY
        [Member(3)] byte ExpiryMonth { get; } // MM
        [Member(4)] string? CVC { get; }
    }
}