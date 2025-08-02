namespace Recipefy.Application.Contracts.Common;

public interface IBaseRequester : IScopedService
{
    string BaseUrl { get;}
}