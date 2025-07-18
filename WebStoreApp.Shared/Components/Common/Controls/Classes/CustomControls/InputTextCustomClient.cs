using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreApp.Shared.Components.Common.Controls.Classes.CustomControls
{
    public class InputTextCustomClient : InputText, IDisposable
    {
        [Parameter]
        public string Type { get; set; } = "text"; 
        [Parameter] 
        public int Delay { get; set; } = 2000;
        [Parameter]
        public EventCallback<string> OnTextChanged { get; set; }
            
        private Timer? _debounceTimer;
        private string _pendingValue = string.Empty;
        private bool _disposed = false;
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");

            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "type", Type);
            builder.AddAttribute(3, "class", CssClass);
            builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(5, "oninput", EventCallback.Factory.CreateBinder<string>(
            this,
            DebouncedInputHandler,
            CurrentValueAsString));

            builder.CloseElement();
        }

        private void DebouncedInputHandler(string value)
        {
            _pendingValue = value;

            _debounceTimer?.Dispose();

            _debounceTimer = new Timer(async _ =>
            {
                try
                {
                    await InvokeAsync(() =>
                    {
                        CurrentValueAsString = _pendingValue;
                        return OnTextChanged.InvokeAsync(_pendingValue);
                    });
                }
                catch (Exception ex)
                {
                    // لاگ کن یا ارور رو هندل کن
                    Console.Error.WriteLine($"Error in debounce timer: {ex}");
                }
            }, null, Delay, Timeout.Infinite);
        }


        public void Dispose()
        {
            if (!_disposed)
            {
                _debounceTimer?.Dispose();
                _disposed = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
