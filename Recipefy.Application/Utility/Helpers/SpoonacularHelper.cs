namespace Recipefy.Application.Utility.Helpers;

public static class SpoonacularHelper
{
    public static string GetUrl(string endpoint, string query, string apiKey) => $"{endpoint}?apiKey={apiKey}&{query}";
}