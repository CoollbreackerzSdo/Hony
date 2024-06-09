using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Common.Models;

public readonly record struct CategoryView(string Name, OklhColor Color);