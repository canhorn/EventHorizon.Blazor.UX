namespace EventHorizon.Blazor.Mockup
{
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text.Json;

    public class ComponentMockupModel
        : ComponentBase
    {

        [Parameter]
        public Type ComponentType { get; set; } = null!;
        [Parameter]
        public ComponentArgumentDetailsMap Arguments { get; set; } = new();
        [Parameter, MaybeNull]
        public RenderFragment<Dictionary<string, object?>> Template { get; set; }

        public Dictionary<string, object?> ComponentParametersWithDefaults { get; set; } = new();

        public IEnumerable<ComponentPropertyDocumentation> Documentation { get; set; } = new List<ComponentPropertyDocumentation>();

        public List<(string, string)> TriggeredEventCallbackList { get; set; } = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            // Primitive Types will be Editable
            // Complex Types will point to the <Namespace>.<Name>
            // EventCallback will Log to an Actions Area

            // Get Parameters
            var parameterList = ComponentType
                .GetPropertyDescriptions()
                .Where(a => a.Attributes.Any(b => b.Type == typeof(ParameterAttribute).Name));
            Documentation = parameterList.Select(
               a => FillFArgumentDetails(
                    new ComponentPropertyDocumentation
                    {
                        Name = a.PropertyName,
                        Type = a.TypeName,
                        Metadata = a,
                    }
                )
            );

            ComponentParametersWithDefaults = parameterList.Select(
                a => new KeyValuePair<string, object?>(
                    a.PropertyName,
                    GetDefaultValue(
                        a
                    )
                )
            ).Where(
                a => a.Value != null
            ).ToDictionary(
                a => a.Key,
                a => a.Value
            );
        }

        private object? GetDefaultValue(
            PropertyDescription a
        )
        {
            if (Arguments.TryGetValue(
                a.PropertyName,
                out var argument
            ))
            {
                if (a.TypeName == "RenderFragment"
                    && argument.PropertyValue is string stringProperty)
                {
                    return stringProperty.ToRenderFragment();
                }
                else if (a.TypeName == "EventCallback")
                {
                    return EventCallback.Factory.Create(this, () => CaptureEventCallback(a.PropertyName));
                }
                else if (a.TypeName.StartsWith("EventCallback"))
                {
                    var callbackType = a.Type;
                    Action<object> action = (object arg) => { CaptureEventCallback(a.PropertyName, arg); };
                    return Activator.CreateInstance(callbackType, this, action);
                }
                return argument.PropertyValue;
            }
            return null;
        }

        public void CaptureEventCallback(string eventCallbackName, object? args = null)
        {
            if (args == null)
            {
                args = new { };
            }

            TriggeredEventCallbackList.Add((
                eventCallbackName,
                JsonSerializer.Serialize(
                    args,
                    new JsonSerializerOptions { WriteIndented = true }
                )
            ));
        }

        private ComponentPropertyDocumentation FillFArgumentDetails(
            ComponentPropertyDocumentation details
        )
        {
            if (Arguments.TryGetValue(
                details.Name,
                out var argumentDetails
            ))
            {
                details.Description = argumentDetails.Description;
                details.Default = JsonSerializer.Serialize(argumentDetails.DefaultValue);
                details.Property = JsonSerializer.Serialize(argumentDetails.PropertyValue);
            }

            return details;
        }
    }
}
