using File = DotNetCryptography.Entities.File;

namespace DotNetCryptography.Repositories;

public interface IFileRepository
{
    Task<File?> FindAsync(int id);
    int Create(File file);
}
