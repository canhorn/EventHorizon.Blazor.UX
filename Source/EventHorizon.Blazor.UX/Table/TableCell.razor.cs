namespace EventHorizon.Blazor.UX.Table
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TableCellModel
        : ComponentBase
    {
        [Parameter]
        public bool EnableNoWrap { get; set; } = true;
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; } = null!;

        public string ElementModifiers
        {
            get
            {
                var modifers = string.Empty;
                if (EnableNoWrap)
                {
                    modifers += "--no-wrap ";
                }

                return modifers;
            }
        }
    }
}
