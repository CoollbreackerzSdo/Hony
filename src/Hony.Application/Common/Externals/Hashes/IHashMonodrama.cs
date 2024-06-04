namespace Hony.Application.Common.Externals.Hashes;

/// <summary>
/// Interfaz que define métodos para hashear y validar texto.
/// </summary>
public interface IHashMonodrama
{
    /// <summary>
    /// Genera un hash para el texto proporcionado.
    /// </summary>
    /// <param name="text">El texto a hashear.</param>
    /// <returns>El hash generado del texto.</returns>
    string Hash(string text);

    /// <summary>
    /// Valida un texto comparándolo con un hash dado.
    /// </summary>
    /// <param name="text">El texto a validar.</param>
    /// <param name="testHash">El hash con el que se comparará el texto.</param>
    /// <returns><c>true</c> si el hash del texto coincide con el hash proporcionado; de lo contrario, <c>false</c>.</returns>
    bool Validate(string text, string testHash);
}