namespace Hony.Application.Common.Models;

public readonly record struct PaginationCommandHandler(int Skip, int Count, PageOrderMode OrderMode);

public enum PageOrderMode
{
    Asc,
    Desc
}