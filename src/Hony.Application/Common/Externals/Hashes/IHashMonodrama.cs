namespace Hony.Application.Common.Externals.Hashes;

public interface IHashMonodrama
{
    string Hash(string text);
    bool Validate(string text, string testHash);
}