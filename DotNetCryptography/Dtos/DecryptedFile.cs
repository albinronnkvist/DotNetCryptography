namespace DotNetCryptography.Dtos;

public class DecryptedFile
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string DecryptedContent { get; set; }
}
