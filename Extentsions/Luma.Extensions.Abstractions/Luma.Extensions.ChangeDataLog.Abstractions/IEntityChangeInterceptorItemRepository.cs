using System.Data;

namespace Luma.Extensions.ChangeDataLog.Abstractions;

public interface IEntityChangeInterceptorItemRepository
{
    public void Save(List<EntityChangeInterceptorItem> entityChangeInterceptorItems, IDbTransaction transaction);
    public Task SaveAsync(List<EntityChangeInterceptorItem> entityChangeInterceptorItems, IDbTransaction transaction);
}