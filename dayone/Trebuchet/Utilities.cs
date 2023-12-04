namespace Trebuchet;

public static class Utilities
{
    public static IEnumerable<string> ReadFileContents(string filePath)
    {
        return File.ReadAllLines(filePath);
    }
}