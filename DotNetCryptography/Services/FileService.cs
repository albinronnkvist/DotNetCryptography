using DotNetCryptography.Dtos;
using DotNetCryptography.Encryptors;
using DotNetCryptography.Options;
using DotNetCryptography.Repositories;
using Microsoft.Extensions.Options;
using File = DotNetCryptography.Entities.File;

namespace DotNetCryptography.Services;

public class FileService : IFileService
{
    private readonly IOptions<AesEncryptionOptions> _encryptionOptions;
    private readonly IFileRepository _fileRepository;

    public FileService(IOptions<AesEncryptionOptions> encryptionOptions,
        IFileRepository fileRepository)
    {
        _encryptionOptions = encryptionOptions;
        _fileRepository = fileRepository;
    }

    public async Task<DecryptedFile?> GetDecryptedFile(int id)
    {
        var file = await _fileRepository.FindAsync(id);
        if (file == null)
        {
            return null;
        }

        return new DecryptedFile
        {
            Id = file.Id,
            Name = file.Name,
            DecryptedContent = AesEncryptor.Decrypt(file.EncryptedContent, 
                _encryptionOptions.Value.EncryptionKey, file.Iv)
        };
    }

    public async Task<File?> GetEncryptedFile(int id)
    {
        return await _fileRepository.FindAsync(id);
    }

    public int CreateEncryptedFile(CreateFile file)
    {
        var iv = AesEncryptor.GenerateRandomIv();
        var newFile = new File
        {
            Name = file.Name,
            EncryptedContent = AesEncryptor.Encrypt(file.Content,
                _encryptionOptions.Value.EncryptionKey, iv),
            Iv = iv
        };

        return _fileRepository.Create(newFile);
    }
}
