using System;
using System.Collections.Generic;

namespace SitecoreInstaller.UI.Navigation
{
    using System.Collections;
    using System.Windows.Forms;

    public class NavigationCtrlList<T> : IEnumerable<T> where T : SIButton
    {
        private readonly IList<T> _buttons;

        public NavigationCtrlList()
        {
            _buttons = new List<T>();
        }

        public void Add(T control, EventHandler onClick)
        {
            control.Click += control_Click;
            if (onClick != null)
                control.Click += onClick;
            _buttons.Add(control);
            Init();
        }

        void control_Click(object sender, EventArgs e)
        {
            var button = sender as T;
            if (button == null)
                return;
            
            foreach (var button1 in _buttons)
            {
                button1.DeActivate();
            }
            button.Activate();
            ActiveControl = button;
        }

        public void RemoveAt(int index)
        {
            _buttons.RemoveAt(index);
            Init();
        }

        public T ActiveControl { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return _buttons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Init()
        {
            var index = 0;
            foreach (var buttons in _buttons)
            {
                buttons.Top = index * buttons.Height;
                buttons.TabIndex = index;
                buttons.Name = "btn" + buttons.Text.Replace(" ", string.Empty);
                index++;
            }
        }
    }
}
