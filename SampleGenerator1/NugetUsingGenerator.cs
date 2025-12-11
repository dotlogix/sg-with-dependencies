using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;

namespace SampleGenerator1;

[Generator]
public class NugetUsingGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static context =>
        {
            var serializedContent = JsonConvert.SerializeObject(new { a = "a", b = 4 });
            context.AddSource("NugetGenerator.Source.g.cs", SourceText.From(
                $$""""
                  namespace NugetNamespace
                  {
                      public class NugetClass
                      {
                          public const string NugetContent = """{{serializedContent}}""";
                      }
                  }
                  """", Encoding.UTF8));
        });
    }
}