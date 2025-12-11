using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json;

namespace SampleGenerator1;

[Generator]
public class NugetUsingGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
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
    }
}