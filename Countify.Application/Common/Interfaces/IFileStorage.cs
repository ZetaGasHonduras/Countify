namespace Countify.Application.Common.Interfaces;

/// <summary>
/// Almacenamiento de archivos adjuntos (documentos por cobrar, etc.).
/// </summary>
public interface IFileStorage
{
    /// <summary>Guarda el contenido y devuelve la ruta relativa almacenada.</summary>
    Task<string> SaveAsync(Stream content, string fileName, string folder, CancellationToken cancellationToken = default);

    /// <summary>Abre un archivo para lectura, o <c>null</c> si no existe.</summary>
    Task<Stream?> OpenReadAsync(string storagePath, CancellationToken cancellationToken = default);

    Task DeleteAsync(string storagePath, CancellationToken cancellationToken = default);

    bool Exists(string storagePath);
}
