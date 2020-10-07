namespace EventHorizon.Blazor.UX.Controls.Form
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;

    public class TextFieldModel
        : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        [Parameter]
        public string name { get; set; }
        [Parameter]
        public string @class { get; set; }
        [Parameter]
        public string LabelDisplay { get; set; }
        [Parameter]
        public bool disabled { get; set; }
        private string _value;
        [Parameter]
        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                ValueChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }

        public string Uid { get; private set; } = Guid.NewGuid().ToString();
    }
}
