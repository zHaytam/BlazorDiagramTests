using System;

namespace BlazorDiagramTests
{
    public abstract class Model
    {
        public string Id { get; }
        public event Action Changed;

        public Model()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void Refresh() => Changed?.Invoke();
    }
}
