using MoonlightNode.App.Models;

namespace MoonlightNode.App.Http.Resources;

public class DockerMetrics
{
    public Container[] Containers { get; set; } = Array.Empty<Container>();
}