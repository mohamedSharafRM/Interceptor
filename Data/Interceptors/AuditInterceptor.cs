using Interceptor.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Interceptor.Data.Interceptors;

public class AuditInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if(eventData.Context is null )
            return result;

        var changeTracker = eventData.Context.ChangeTracker;

        foreach (var entry in changeTracker.Entries<IAuditable>())
        {
            if(entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTime.UtcNow;

            else if(entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.UtcNow;


            else if(entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
        return result;
    }
}
