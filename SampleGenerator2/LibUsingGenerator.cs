using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using SharedLib;

namespace SampleGenerator2;

[Generator]
public class NugetUsingGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static context =>
        {
            context.AddSource("LibGenerator.Source.g.cs", SourceText.From(
                $$"""
                  namespace LibNamespace
                  {
                      public class LibClass
                      {
                          public const string LibContent = "{{LibConstants.SourceName}}";
                      }
                  }
                  """, Encoding.UTF8));
        });
    }
}