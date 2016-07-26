using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui.Controls
{
    public partial class RadioButtonEnumViewControl<T> : UserControl where T : struct
    {
        public RadioButtonEnumViewControl()
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enum type");

            InitializeComponent();

            Point p = new Point(0, 0);
            foreach(T i in typeof(T).GetEnumValues())
            {
                RadioButton button = new RadioButton();
                _buttonValues[button] = i;
                _buttonsByValue[i] = button;
                button.CheckedChanged += (s, e) => 
                {
                    if (button.Checked) _selectedItem = _buttonValues[button];
                };
                button.Location = p;
                Controls.Add(button);
                p.Y += 24;
                Height = button.Bottom;
            }
        }

        public int SelectedIntValue
        {
            get { return (int) (ValueType) _selectedItem; }
            set
            {
                if (!typeof(T).IsEnumDefined(value))
                {
                    throw new ArgumentException("The given value does not correspond to a member of the enumeration " 
                        + typeof(T).Name);
                }
                _buttonsByValue[(T)(object)value].Checked = true;
            }
        }

        public T SelectedValue
        {
            get { return _selectedItem; }
            set
            {
                if (!typeof(T).IsEnumDefined(value))
                {
                    throw new ArgumentException("The given value does not correspond to a member of the enumeration "
                        + typeof(T).Name);
                }
                _buttonsByValue[(T)(object)value].Checked = true;
            }
        }

        public void SetLabel(T enumValue, string text)
        {
            _buttonsByValue[enumValue].Text = text;
        }

        private Dictionary<RadioButton, T> _buttonValues = new Dictionary<RadioButton, T>();
        private Dictionary<T, RadioButton> _buttonsByValue = new Dictionary<T, RadioButton>();
        private T _selectedItem = default(T);
    }
}
