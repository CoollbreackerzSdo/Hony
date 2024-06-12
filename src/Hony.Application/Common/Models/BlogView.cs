using System.Collections.ObjectModel;

namespace Hony.Application.Common.Models;
/// <summary>
/// Representa una vista de un blog.
/// </summary>
/// <param name="Id">El identificador único del blog.</param>
/// <param name="Name">El nombre del blog.</param>
/// <param name="Content">El contenido del blog.</param>
/// <param name="Categories">Las categorías asociadas con el blog.</param>
/// <param name="Creation">La fecha de creación del blog.</param>
/// <param name="Cements">El número de comentarios en el blog.</param>
public readonly record struct BlogView(Guid Id, string Name, string Content, ReadOnlyCollection<string> Categories, DateTime Creation, int Cements);

/// <summary>
/// Representa una vista pública de un blog con su identificador, nombre, contenido, categorías, fecha de creación, número de comentarios y nombre de usuario del creador.
/// </summary>
/// <param name="Id">El identificador único del blog.</param>
/// <param name="Name">El nombre del blog.</param>
/// <param name="Content">El contenido del blog.</param>
/// <param name="Categories">Las categorías asociadas con el blog.</param>
/// <param name="Creation">La fecha de creación del blog.</param>
/// <param name="Cements">El número de comentarios en el blog.</param>
/// <param name="CreatorUserName">El nombre de usuario del creador del blog.</param>
public readonly record struct BlogPublicView(Guid Id, string Name, string Content, ReadOnlyCollection<string> Categories, DateTime Creation, int Cements, string CreatorUserName);