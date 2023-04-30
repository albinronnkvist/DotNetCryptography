namespace DotNetCryptography.Entities;

public class File
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required byte[] EncryptedContent { get; set; }
    public required byte[] Iv { get; set; }
}
