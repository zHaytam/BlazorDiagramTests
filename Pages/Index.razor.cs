using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDiagramTests.Pages
{
    public partial class Index
    {

        private List<Node> _nodes;
        private List<Link> _links;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var node = new Node();

            _nodes = new List<Node>
            {
                new Node().AddPort(),
                new Node() { Position = (150, 150) }.AddPort()
            };

            _links = new List<Link>
            {
                _nodes[0].Port.AddLink(_nodes[1].Port)
            };

            Task.Run(async () =>
            {
                await Task.Delay(1000);
                await InvokeAsync(StateHasChanged);
            });
        }

        protected override bool ShouldRender() => _nodes.Any(n => n.Selected);

        protected void OnMouseUp()
        {
            var selectedNode = _nodes.FirstOrDefault(n => n.Selected);
            if (selectedNode == null)
                return;

            selectedNode.Selected = false;
        }

        protected void OnMouseMove(MouseEventArgs e)
        {
            var selectedNode = _nodes.FirstOrDefault(n => n.Selected);
            if (selectedNode == null)
                return;

            selectedNode.Position = (e.ClientX + selectedNode.Offset.left, e.ClientY + selectedNode.Offset.top);
            selectedNode.Port.Position = (selectedNode.Position.left + selectedNode.Port.Offset.left,
                selectedNode.Position.top + selectedNode.Port.Offset.top);
            Console.WriteLine(selectedNode.Port.Position);
        }

    }
}
