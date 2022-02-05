using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WindowsFormsCodeSamples.Extensions
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)), null);
            }
            else
            {
                action(control);


            }
        }
    }
}
