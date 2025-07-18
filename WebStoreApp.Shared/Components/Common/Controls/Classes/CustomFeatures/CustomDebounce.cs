using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreApp.Shared.Components.Common.Controls.Classes.CustomFeatures
{
    public class DebounceDispatcher : IDisposable
    {
        private Timer? _timer;

        public void Debounce(int milliseconds, Func<Task> action)
        {
            _timer?.Dispose();

            _timer = new Timer(async _ =>
            {
                await action.Invoke();
            }, null, milliseconds, Timeout.Infinite);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}
