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

        public static IEnumerable<Control> ChildControls(this Control control)
            => control.Controls.Cast<Control>();
        public static IEnumerable<T> ChildControls<T>(this Control control) where T : Control
            => control.Controls.Cast<T>();

        /// <summary>
        /// Retrieves all descendant controls of a specified type from the control hierarchy, 
        /// optionally filtered by a predicate.
        /// </summary>
        /// <typeparam name="T">
        /// The type of controls to retrieve. Must derive from <see cref="Control"/>.
        /// </typeparam>
        /// <param name="control">
        /// The root control from which to search for descendant controls.
        /// </param>
        /// <param name="predicate">
        /// An optional predicate to filter the descendant controls. If <c>null</c>, all controls
        /// of the specified type are included.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the descendant controls of the specified type
        /// that match the predicate, if provided.
        /// </returns>
        /// <remarks>
        /// https://github.com/microsoft/winforms-designer-extensibility/blob/4959e7c5076faf3d8b095db36951fa3c6d77cb79/Samples/NET%209/Async%20in%20NET%209/WinFormsAsync/FormExtensions.cs
        /// </remarks>
        public static IEnumerable<T> DescendantControls<T>(this Control control, Func<Control, bool>? predicate = default) where T : Control
        {
            foreach (Control childControl in control.ChildControls())
            {
                if (childControl is T t && (predicate == null || predicate(t)))
                {
                    yield return t;
                }

                foreach (T grandChildControl in childControl.DescendantControls<T>(predicate))
                {
                    yield return grandChildControl;
                }
            }
        }
        public static IEnumerable<T> Descendants<T>(this Control control) where T : class
        {
            foreach (Control child in control.Controls)
            {
                if (child is T thisControl)
                {
                    yield return (T)thisControl;
                }

                if (child.HasChildren)
                {
                    foreach (T descendant in Descendants<T>(child))
                    {
                        yield return descendant;
                    }
                }
            }
        }
}
