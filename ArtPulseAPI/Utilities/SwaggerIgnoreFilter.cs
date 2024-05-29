using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArtPulseAPI.Utilities
{
    public class SwaggerIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null || context?.Type == null)
                return;

            var excludedProperties = context.Type.GetProperties()
                .Where(t => t.GetCustomAttributes(typeof(SwaggerIgnoreAttribute), true).Any());

            foreach (var excludedProperty in excludedProperties)
            {
                var propertyToRemove = schema.Properties.Keys
                    .SingleOrDefault(x => x.Equals(excludedProperty.Name, StringComparison.OrdinalIgnoreCase));
                if (propertyToRemove != null)
                {
                    schema.Properties.Remove(propertyToRemove);
                }
            }
        }
    }
}
