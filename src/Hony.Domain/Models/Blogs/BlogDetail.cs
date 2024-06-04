using Hony.Domain.Models.Twits;

namespace Hony.Domain.Models.Blogs;

/// <summary>
/// Modelo que representa los detalles adicionales de un blog.
/// </summary>
public class BlogDetail
{
    /// <summary>
    /// Obtiene o establece el número de veces que el blog ha sido retwiteado.
    /// </summary>
    public int ReTwits { get; set; }
}