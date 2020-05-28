using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorDiagramTests.Pages
{
    public class NodeWidgetComponent : ComponentBase
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public Node Node { get; set; }

        protected ElementReference _element;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Node.Changed += () => StateHasChanged();
        }

        protected async Task OnMouseDown(MouseEventArgs e)
        {
            Node.Selected = true;
            var leftTopOffsets = await JSRuntime.InvokeAsync<double[]>("getOffset", _element);
            Node.Offset = (leftTopOffsets[0] - e.ClientX, leftTopOffsets[1] - e.ClientY);
            Console.WriteLine("{0} {1} {2} {3}", leftTopOffsets[0], leftTopOffsets[1], e.ClientX, e.ClientY);
        }
    }
}
