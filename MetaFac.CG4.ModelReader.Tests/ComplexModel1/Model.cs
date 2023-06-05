using MetaFac.CG4.Attributes;
using System;

namespace MetaFac.CG4.ModelReader.Tests.ComplexModel1
{
    // ==================== Level 0 fields ====================

    [Entity(1)]
    public interface IBaseMessage
    {
        [Member(1)] Guid RequestId { get; }
    }

    [Entity(2)]
    public interface IBaseRequest : IBaseMessage
    {
    }

    [Entity(3)]
    public interface IBaseResponse : IBaseMessage
    {
        [Member(2)] bool Succeeded { get; }
        [Member(3)] string? FailReason { get; }
        [Member(4)] ILogMessage[]? Messages { get; }
    }

    [Entity(4)]
    public interface ILogMessage
    {
        [Member(1)] int Severity { get; }
        [Member(2)] string? MessageTemplate { get; }
        [Member(3)] string[]? MessageParameters { get; }
    }

    [Entity(5)]
    public interface INameValuePair
    {
        [Member(1)] string? Name { get; }
        [Member(2)] string? Value { get; }
    }

    //==================== Level 1 fields ====================

    [Entity(11)]
    public interface IGetServerInfoRequest : IBaseRequest
    {
    }

    [Entity(12)]
    public interface IGetServerInfoResponse : IBaseResponse
    {
        [Obsolete]
        [Member(11)] string? obsolete01 { get; } // was ServerInfo

        [Member(12)] INameValuePair[]? ServerProperties { get; }
    }

    [Entity(21)]
    public interface IAccountRequest : IBaseRequest
    {
    }

    [Entity(22)]
    public interface IAccountResponse : IBaseResponse
    {
    }

    //==================== Level 2 fields ====================

    [Entity(23)]
    public interface IGetNewAccountIdRequest : IAccountRequest
    {
    }

    [Entity(24)]
    public interface IGetNewAccountIdResponse : IAccountResponse
    {
        [Member(21)] string? CreateToken { get; }
    }

    [Entity(25)]
    public interface ICreateAccountRequest : IAccountRequest
    {
        [Member(21)] string? CreateToken { get; }
        [Member(22)] string? ShortName { get; }
        [Member(23)] string? PrimaryEmailAddress { get; }
        [Member(24)] string? BackupEmailAddress { get; }
    }

    [Entity(26)]
    public interface ICreateAccountResponse : IAccountResponse
    {
        [Member(21)] string? VerifyToken { get; }
    }

    [Entity(27)]
    public interface IVerifyAccountRequest : IAccountRequest
    {
        [Member(21)] string? VerifyToken { get; }
        [Member(25)] string? PrimaryEmailVerifyCode { get; }
        [Member(26)] string? BackupEmailVerifyCode { get; }
    }

    [Entity(28)]
    public interface IVerifyAccountResponse : IAccountResponse
    {
        [Member(21)] string? AccessToken { get; }
    }

    [Entity(29)]
    public interface IModifyAccountRequest : IAccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(22)] string? ShortName { get; }
        [Member(23)] string? PrimaryEmailAddress { get; }
        [Member(24)] string? BackupEmailAddress { get; }
    }

    [Entity(30)]
    public interface IModifyAccountResponse : IAccountResponse
    {
        [Member(21)] string? VerifyToken { get; }
    }

    [Entity(33)]
    public interface IGetSecretRequest : IAccountRequest
    {
        [Member(20)] string? LicenseCode { get; }
        [Member(21)] Guid SecretGuid { get; }
    }

    [Entity(34)]
    public interface IGetSecretResponse : IAccountResponse
    {
        [Member(21)] Guid SecretGuid { get; }
        [Member(22)] string? SecretText { get; }
    }

    [Entity(35)]
    public interface IGetAdminTokenRequest : IAccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(22)] string? MasterToken { get; }
    }

    [Entity(36)]
    public interface IGetAdminTokenResponse : IAccountResponse
    {
        [Member(21)] string? AdminToken { get; }
    }

    [Entity(37)]
    public interface IAddSecretRequest : IAccountRequest
    {
        [Member(20)] string? AdminToken { get; }
        [Member(21)] Guid SecretGuid { get; }
        [Member(22)] string? SecretText { get; }
    }

    [Entity(38)]
    public interface IAddSecretResponse : IAccountResponse
    {
    }

    [Entity(41)]
    public interface ICommencePurchaseRequest : IAccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(22)] ICreditCardDetails? CreditCard { get; }
        [Member(23)] string? LicenseTier { get; }
    }

    [Entity(42)]
    public interface ICommencePurchaseResponse : IAccountResponse
    {
    }

    [Entity(43)]
    public interface ICompletePurchaseRequest : IAccountRequest
    {
        [Member(21)] string? AccessToken { get; }
        [Member(25)] string? VerifyCode { get; }
    }

    [Entity(44)]
    public interface ICompletePurchaseResponse : IAccountResponse
    {
        [Member(21)] string? LicenseCode { get; }
    }

    [Entity(45)]
    public interface ICreditCardDetails
    {
        [Member(1)] string? Number { get; }
        [Member(2)] ushort ExpiryYear { get; } // YYYY
        [Member(3)] byte ExpiryMonth { get; } // MM
        [Member(4)] string? CVC { get; }
    }
}