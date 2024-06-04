using Hony.Domain.Models.Account;

namespace Hony.Application.Common.Externals.UnitOfWord;

/// <summary>
/// Interfaz que define un repositorio específico para las entidades de cuenta.
/// Hereda de <see cref="IRepository{T}"/> donde <c>T</c> es <see cref="AccountEntity"/>.
/// </summary>
public interface IAccountRepository : IRepository<AccountEntity>
{
}