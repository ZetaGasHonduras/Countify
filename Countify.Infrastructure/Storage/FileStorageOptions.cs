namespace Countify.Infrastructure.Storage;

public class FileStorageOptions
{
    public const string SectionName = "FileStorage";

    /// <summary>Ruta raíz del almacenamiento de adjuntos (absoluta o relativa al directorio de la app).</summary>
    public string RootPath { get; set; } = "App_Data/attachments";
}
