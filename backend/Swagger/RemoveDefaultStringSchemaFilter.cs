using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class RemoveStringDefaultsSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null) return;

        foreach (var prop in schema.Properties)
        {
            if (prop.Value.Type == "string")
            {
                prop.Value.Example = null;
                prop.Value.Default = null;
            }
        }
    }
}
