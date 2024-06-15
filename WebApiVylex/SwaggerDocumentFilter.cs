using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using WebApiVylex.Controllers;

namespace WebApiVylex
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var schema in swaggerDoc.Components.Schemas)
            {
                if (schema.Value?.Properties == null) continue;

                foreach (var prop in schema.Value.Properties)
                {
                    var property = prop.Value;
                    if (property == null) continue;

                    var propertyInfo = typeof(EstudanteController).GetProperty(prop.Key);
                    if (propertyInfo != null)
                    {
                        var displayAttribute = propertyInfo.GetCustomAttribute<DisplayAttribute>();
                        if (displayAttribute != null)
                        {
                            if (!string.IsNullOrWhiteSpace(displayAttribute.Name))
                                property.Title = displayAttribute.Name;
                            if (!string.IsNullOrWhiteSpace(displayAttribute.Description))
                                property.Description = displayAttribute.Description;
                        }
                    }
                }
            }
        }
    }
}