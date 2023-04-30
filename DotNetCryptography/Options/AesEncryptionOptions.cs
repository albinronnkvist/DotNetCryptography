namespace DotNetCryptography.Options;

public record AesEncryptionOptions
{
    public required byte[] EncryptionKey { get; init; }
}
