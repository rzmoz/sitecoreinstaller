using System;
using System.Collections.Generic;

namespace SitecoreInstaller.UI.Navigation
{
    using System.Collections;
    using System.Windows.Forms;

    public class CtrlList<T> : IEnumerable<T> where T : Control
    {
        private readonly IList<T> _controls;

        public event EventHandler Click;

        public CtrlList()
        {
            _controls = new List<T>();
        }

        public void Add(T control, EventHandler onClick)
        {
            control.Click += control_Click;
            if (onClick != null)
                control.Click += onClick;
            _controls.Add(control);
            Update();
        }

        void control_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(sender, EventArgs.Empty);

            //must be after we broadcast event, so ActiveControl can be accessed
            ActiveControl = (T)sender;
        }

        public void RemoveAt(int index)
        {
            _controls.RemoveAt(index);
            Update();
        }

        public T ActiveControl { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return _controls.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Update()
        {
            var index = 0;
            foreach (var control in _controls)
            {
                control.Top = index * control.Height;
                control.TabIndex = index;
                control.Name = "btn" + control.Text.Replace(" ", string.Empty);
                index++;
            }
        }
    }
}
