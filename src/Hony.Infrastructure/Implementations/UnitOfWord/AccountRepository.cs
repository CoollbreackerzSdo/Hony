using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Domain.Models.Account;
using Hony.Infrastructure.Database;

namespace Hony.Infrastructure.Implementations.UnitOfWord;

/// <summary>
/// Inicializa una nueva instancia de la clase <see cref="AccountRepository"/>.
/// Clase interna que representa un repositorio de cuentas que proporciona operaciones CRUD para entidades de cuenta.
/// Hereda de <see cref="Repository{T}"/> donde <c>T</c> es <see cref="AccountEntity"/>, e implementa <see cref="IAccountRepository"/>.
/// </summary>
/// <param name="context">El contexto de la base de datos utilizado por el repositorio.</param>
internal class AccountRepository(HonyAccountsNpSqlContext context) : Repository<AccountEntity>(context), IAccountRepository;