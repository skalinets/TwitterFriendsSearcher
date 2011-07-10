using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using Test.TwitterFriendsSearcher.Shared;

namespace TwitterFriendsSearcher.Runner
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    class TwitterFriendsSearcherUiInfoProvider : ITwitterFriendsSearcherUiInfoProvider
    {
        public TwitterFriendsSearcherUiInfoProvider(Form mainForm)
        {
            MainForm = mainForm;
        }

        public Form MainForm { get; set; }

        public ControlCenter GetButtonCenterByName(string buttonName)
        {
            return GetControlCenterByName(buttonName);
        }

        public ControlCenter GetTextBoxCenterByName(string textBoxName)
        {
            return GetControlCenterByName(textBoxName);
        }

        public ListBoxInfo GetListBoxInfo(string listBoxInfoName)
        {
            var listBox = (ListBox)FindControlByName(listBoxInfoName);

            var items = (from int item in listBox.Items select item.ToString()).ToArray();

            return new ListBoxInfo { Items = items };
        }

        private ControlCenter GetControlCenterByName(string controlName)
        {
            var button = FindControlByName(controlName);

            var screenRectangle = button.RectangleToScreen(button.ClientRectangle);

            return new ControlCenter
            {
                X = screenRectangle.X + screenRectangle.Width / 2,
                Y = screenRectangle.Y + screenRectangle.Height / 2
            };
        }

        private Control FindControlByName(string name)
        {
            return (Control)DelayedSearcher.FindUiElement(() => FindControlByNameRecursively(MainForm.Controls, name));
        }

        private Control FindControlByNameRecursively(Control.ControlCollection controls, string name)
        {
            foreach (Control control in controls)
            {
                if (control.Name == name)
                    return control;

                var foundChildButton = FindControlByNameRecursively(control.Controls, name);

                if (foundChildButton != null)
                    return foundChildButton;
            }

            return null;
        }
    }
}