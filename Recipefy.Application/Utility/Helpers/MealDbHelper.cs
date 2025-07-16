namespace Recipefy.Application.Utility.Helpers;

public static class MealDbHelper
{
    public static string GetImageUrl(string basePath, string modelName, string extension)
    {
        var convertedName = modelName.ToLower().Replace(" ", "_");
        
        return $"{basePath}/{convertedName}{extension}";
    }
}