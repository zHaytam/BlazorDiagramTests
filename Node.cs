namespace BlazorDiagramTests
{
    public class Node : Model
    {

        public (double left, double top) Offset { get; set; } = (0, 0);
        public (double left, double top) Position { get; set; } = (0, 0);
        public bool Selected { get; set; }
        public Port Port { get; set; }

        public Node AddPort()
        {
            Port = new Port(this)
            {
                Position = Position
            };
            return this;
        }

    }
}
