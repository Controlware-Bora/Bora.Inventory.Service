using Microsoft.EntityFrameworkCore;

namespace Bora.Inventory.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder ConvertAllToSnakeCase(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName((entity.GetTableName() ?? string.Empty).ToSnakeCase());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName((key.GetName() ?? string.Empty).ToSnakeCase());
            }

            foreach (var fKeys in entity.GetForeignKeys())
            {
                fKeys.SetConstraintName((fKeys.GetConstraintName() ?? string.Empty).ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName((index.GetDatabaseName() ?? string.Empty).ToSnakeCase());
            }
        }

        return builder;
    }
}