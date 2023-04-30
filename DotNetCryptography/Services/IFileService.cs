using DotNetCryptography.Dtos;
using File = DotNetCryptography.Entities.File;

namespace DotNetCryptography.Services;

public interface IFileService
{
    Task<DecryptedFile?> GetDecryptedFile(int id);
    Task<File?> GetEncryptedFile(int id);
    int CreateEncryptedFile(CreateFile file);
}
