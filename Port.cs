namespace BlazorDiagramTests
{
    public class Port : Model
    {
        public Node Node { get; }
        public (double left, double top) Offset { get; set; } = (0, 0);
        public (double left, double top) Position { get; set; } = (0, 0);
        public Link Link { get; set; }

        public Port(Node node)
        {
            Node = node;
        }

        public Link AddLink(Port to)
        {
            Link = new Link(this, to);
            to.Link = Link;
            return Link;
        }
    }
}
