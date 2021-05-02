namespace EventHorizon.Blazor.UX.Form
{
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class SelectBoxModel
        : ComponentBase
    {
        private SelectBoxOption _value = new ();

        [Parameter]
        public string id { get; set; } = null!;
        public string Uid { get; private set; } = Guid.NewGuid().ToString();
        [Parameter]
        public string name { get; set; } = null!;
        [Parameter]
        public string @class { get; set; } = null!;
        [Parameter]
        public bool disabled { get; set; }

        [Parameter]
        public string LabelDisplay { get; set; } = null!;
        [Parameter]
        public IList<SelectBoxOption> Options { get; set; } = null!;
        [Parameter]
        public string DefaultValue { get; set; } = string.Empty;
        [Parameter]
        public SelectBoxOption Value
        {
            get => _value;
            set
            {
                var newValue = value?.Value?.ToString(
                    CultureInfo.InvariantCulture
                ) ?? DefaultValue;
                _value = Options.FirstOrDefault(
                    option => option.Value == newValue
                ) ?? new SelectBoxOption();
            }
        }
        [Parameter]
        public EventCallback<SelectBoxOption> ValueChanged { get; set; }

        public string TextValue
        {
            get => _value.Value;
            set
            {
                var newValue = value ?? DefaultValue;
                var newOption = Options.FirstOrDefault(
                    option => option.Value == newValue
                );
                if (newOption is not null)
                {
                    Value = newOption;
                    ValueChanged.InvokeAsync(_value);
                }
            }
        }

        protected bool IsDisabled => Options.Count == 0 || disabled;

        protected override void OnInitialized()
        {
            if (Options == null)
            {
                Options = new List<SelectBoxOption>();
            }
        }

        protected Task HandleSelectChanged(
            ChangeEventArgs changeEventArgs
        )
        {
            var newValue = changeEventArgs.Value?.ToString() ?? DefaultValue;
            return ValueChanged.InvokeAsync(
                Options.FirstOrDefault(
                    option => option.Value == newValue
                )
            );
        }

    }

    public class SelectBoxOption
    {
        public string Value { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
