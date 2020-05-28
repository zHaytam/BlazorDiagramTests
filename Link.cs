namespace BlazorDiagramTests
{
    public class Link : Model
    {

        public Port FromPort { get; set; }
        public Port ToPort { get; set; }

        public Link(Port from, Port to)
        {
            FromPort = from;
            ToPort = to;
        }

    }
}
