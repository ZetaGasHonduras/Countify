using Countify.Application.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace Countify.Infrastructure.Storage;

public class LocalFileStorage : IFileStorage
{
    private readonly string _rootPath;

    public LocalFileStorage(IOptions<FileStorageOptions> options)
    {
        var root = options.Value.RootPath;
        _rootPath = Path.IsPathRooted(root)
            ? root
            : Path.Combine(AppContext.BaseDirectory, root);
    }

    public async Task<string> SaveAsync(Stream content, string fileName, string folder, CancellationToken cancellationToken = default)
    {
        var safeFolder = folder.Replace('\\', '/').Trim('/');
        var directory = Path.Combine(_rootPath, safeFolder.Replace('/', Path.DirectorySeparatorChar));
        Directory.CreateDirectory(directory);

        var extension = Path.GetExtension(fileName);
        var storedName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(directory, storedName);

        await using (var fileStream = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
        {
            await content.CopyToAsync(fileStream, cancellationToken);
        }

        return $"{safeFolder}/{storedName}";
    }

    public Task<Stream?> OpenReadAsync(string storagePath, CancellationToken cancellationToken = default)
    {
        var fullPath = Resolve(storagePath);
        if (!File.Exists(fullPath))
            return Task.FromResult<Stream?>(null);

        Stream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        return Task.FromResult<Stream?>(stream);
    }

    public Task DeleteAsync(string storagePath, CancellationToken cancellationToken = default)
    {
        var fullPath = Resolve(storagePath);
        if (File.Exists(fullPath))
            File.Delete(fullPath);

        return Task.CompletedTask;
    }

    public bool Exists(string storagePath) => File.Exists(Resolve(storagePath));

    private string Resolve(string storagePath)
        => Path.Combine(_rootPath, storagePath.Replace('/', Path.DirectorySeparatorChar));
}
