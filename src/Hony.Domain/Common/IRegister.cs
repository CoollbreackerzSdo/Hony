namespace Hony.Domain.Common;

public interface IRegister
{
    TimeOnly RegisterTime { get; }
    DateOnly RegisterDate { get; }
}