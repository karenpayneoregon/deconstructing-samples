using System;
using System.Windows.Forms;

namespace WindowsFormsLibrary.Classes
{
    public class Dialogs
    {
        /// <summary>
        /// displays a message with option to assign button text
        /// </summary>
        /// <param name="owner">control or form</param>
        /// <param name="heading">What to display</param>
        /// <param name="buttonText"></param>
        /// <remarks>Centers on owner</remarks>
        public static void Information(Control owner, string heading, string buttonText = "Ok")
        {

            TaskDialogButton okayButton = new(buttonText);

            TaskDialogPage page = new()
            {
                Caption = "Information",
                SizeToContent = true,
                Heading = heading,
                Footnote = new TaskDialogFootnote() { Text = "Code sample by Karen Payne" },
                Icon = new TaskDialogIcon(Properties.Resources.blueInformation_32),
                Buttons = new TaskDialogButtonCollection() { okayButton }
            };

            TaskDialog.ShowDialog(owner, page);

        }
        public static void Information(Control owner, string heading, string footNote, string buttonText = "Ok")
        {

            TaskDialogButton okayButton = new(buttonText);

            TaskDialogPage page = new()
            {
                Caption = "Information",
                SizeToContent = true,
                Heading = heading,
                Footnote = new TaskDialogFootnote() { Text = footNote },
                Icon = new TaskDialogIcon(Properties.Resources.blueInformation_32),
                Buttons = new TaskDialogButtonCollection() { okayButton }
            };

            TaskDialog.ShowDialog(owner, page);

        }
        /// <summary>
        /// Dialog to ask a question
        /// </summary>
        /// <param name="caption">text for dialog caption</param>
        /// <param name="heading">text for dialog heading</param>
        /// <param name="yesText">text for yes button</param>
        /// <param name="noText">text for no button</param>
        /// <param name="defaultButton">specifies the default button for this dialog</param>
        /// <returns>true for yes button, false for no button</returns>
        public static bool Question(string caption, string heading, string yesText, string noText, DialogResult defaultButton)
        {

            TaskDialogButton yesButton = new(yesText) { Tag = DialogResult.Yes };
            TaskDialogButton noButton = new(noText) { Tag = DialogResult.No };

            TaskDialogButtonCollection buttons = new();

            if (defaultButton == DialogResult.Yes)
            {
                buttons.Add(yesButton);
                buttons.Add(noButton);
            }
            else
            {
                buttons.Add(noButton);
                buttons.Add(yesButton);
            }

            TaskDialogPage page = new()
            {
                Caption = caption,
                SizeToContent = true,
                Heading = heading,
                Footnote = new TaskDialogFootnote() { Text = "Code sample by Karen Payne" },
                Icon = TaskDialogIcon.Information,
                Buttons = buttons
            };


            TaskDialogButton result = TaskDialog.ShowDialog(page);

            return (DialogResult)result.Tag == DialogResult.Yes;

        }

        public static bool Question(string caption, string heading, string footNote)
        {

            TaskDialogButton yesButton = new("Yes") { Tag = DialogResult.Yes };
            TaskDialogButton noButton = new("No") { Tag = DialogResult.No };

            TaskDialogButtonCollection buttons = new()
            {
                yesButton,
                noButton
            };

            TaskDialogPage page = new()
            {
                Caption = caption,
                SizeToContent = true,
                Heading = heading,
                Icon = TaskDialogIcon.Information,
                Buttons = buttons
            };

            if (!string.IsNullOrWhiteSpace(footNote))
            {
                page.Footnote = new TaskDialogFootnote() { Text = footNote };
            }

            TaskDialogButton result = TaskDialog.ShowDialog(page);

            return (DialogResult)result.Tag == DialogResult.Yes;

        }

        /// <summary>
        /// Used for development to display exception information
        /// </summary>
        /// <param name="exception">Exception thrown</param>
        /// <param name="buttonText">optional text for button</param>
        public static void ErrorBox(Exception exception, string buttonText = "Continue")
        {

            TaskDialogButton singleButton = new(buttonText);

            var text = $"Encountered the following\n{exception.Message}";


            TaskDialogPage page = new()
            {
                Caption = "Something went wrong",
                SizeToContent = true,
                Heading = text,
                Icon = TaskDialogIcon.Error,
                Buttons = new TaskDialogButtonCollection() { singleButton }
            };

            TaskDialog.ShowDialog(page);

        }
        public static void ErrorBox(string exceptionText, string buttonText = "Continue")
        {

            TaskDialogButton singleButton = new(buttonText);

            var text = $"Encountered the following\n{exceptionText}";


            TaskDialogPage page = new()
            {
                Caption = "Something went wrong",
                SizeToContent = true,
                Heading = text,
                Icon = TaskDialogIcon.Error,
                Buttons = new TaskDialogButtonCollection() { singleButton }
            };

            TaskDialog.ShowDialog(page);

        }
    }
}