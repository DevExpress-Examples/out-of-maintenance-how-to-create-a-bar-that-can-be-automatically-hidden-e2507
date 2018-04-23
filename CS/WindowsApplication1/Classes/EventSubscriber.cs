using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.XtraBars.Controls;

namespace WindowsApplication1
{
    public class EventSubscriber
    {
        private CustomBarControl _BarControl;
        private BarDockControl _DockControl;
        private AutoHideBar _Bar;


        public EventSubscriber(AutoHideBar bar)
        {
            _Bar = bar;

        }

        public void CheckChange(CustomBarControl barControl, BarDockControl barDockControl)
        {
            if (BarControlChanged(barControl))
                OnBarControlChanged(barControl);

            if (BarDockControlChanged(barDockControl))
                OnBarDockControlChanged(barDockControl);
        }

        private bool BarControlChanged(CustomBarControl barControl)
        {
            return barControl != _BarControl;
        }
        private void OnBarControlChanged(CustomBarControl barControl)
        {
            if (_BarControl != null)
            {
                _BarControl.MouseEnter -= OnMouseEnter;
                _BarControl.MouseLeave -= OnMouseLeave;
                _BarControl.SizeChanged -= _BarControl_SizeChanged;
            }
            _BarControl = barControl;
            if (_BarControl != null)
            {
                _BarControl.MouseEnter += OnMouseEnter;
                _BarControl.MouseLeave += OnMouseLeave;
                _BarControl.SizeChanged += _BarControl_SizeChanged;
            }
        }

        void _BarControl_SizeChanged(object sender, EventArgs e)
        {
            //Control control = sender as Control;
            //if (control.Height == 0)
            //    control.Height = 13;
        }

 
        private bool BarDockControlChanged(BarDockControl barDockControl)
        {
            return barDockControl != _DockControl;
        }
        private void OnBarDockControlChanged(BarDockControl barDockControl)
        {
            if (_DockControl != null)
            {
                _DockControl.MouseEnter -= OnMouseEnter;
                _DockControl.MouseLeave -= OnMouseLeave;
            }
            _DockControl = barDockControl;
            if (barDockControl != null)
            {
                _DockControl.MouseEnter += OnMouseEnter;
                _DockControl.MouseLeave += OnMouseLeave;
            }
        }


        void OnMouseLeave(object sender, EventArgs e)
        {
            Console.WriteLine("Leave");
            _Bar.HideBar();
        }

        void OnMouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("Enter");
            _Bar.ShowBar();
        }

        
    }
}
