using File = DotNetCryptography.Entities.File;

namespace DotNetCryptography.Repositories;

public class FileRepository : IFileRepository
{
    private List<File> _files = new();

    public Task<File?> FindAsync(int id)
    {
        return Task.FromResult(_files.FirstOrDefault(x => x.Id == id));
    }

    public int Create(File file)
    {
        file.Id = _files.Count + 1;
        _files.Add(file);

        return file.Id;
    }
}
