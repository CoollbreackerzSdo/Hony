namespace Hony.Application.Common.Models;
/// <summary>
/// Representa una vista de un blog.
/// </summary>
/// <param name="Id">El identificador único del blog.</param>
/// <param name="Name">El nombre del blog.</param>
/// <param name="Content">El contenido del blog.</param>
/// <param name="Creation">La fecha de creación del blog.</param>
/// <param name="Cements">El número de comentarios en el blog.</param>
public readonly record struct BlogView(Guid Id, string Name, string Content, DateTime Creation, int Cements);