namespace Bora.Inventory.Application.Common.CQRS;

public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery
{
    Task<TResult> HandleAsync(TQuery query); 
}