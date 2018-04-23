using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils.Drawing.Animation;

namespace WindowsApplication1
{
    [System.ComponentModel.DesignerCategory("")]
    public class AutoHideBar : Bar
    {


        private EventSubscriber _EventSubscriber;
        public EventSubscriber EventSubscriber
        {
            get
            {
                if (_EventSubscriber == null)
                    _EventSubscriber = new EventSubscriber(this);
                return _EventSubscriber;
            }
        }

        private BarDockControl DockControl
        {
            get
            {
                return Manager.DockControls[DockStyle];
            }
        }
        public AutoHideBar(BarManager manager, BarDockStyle style)
            : base(manager)
        {
            if (style == BarDockStyle.Bottom)
                DockStyle = BarDockStyle.Bottom;
            else
                DockStyle = BarDockStyle.Top;
            OptionsBar.AllowCollapse = true;
            OptionsBar.DrawDragBorder = false;
            OptionsBar.AllowQuickCustomization = false;
        }

        protected override Size CalcBarEndSize()
        {
            if (OptionsBar.BarState == BarState.Expanded)
                return base.CalcBarEndSize();
            Size size = BarControl.Bounds.Size;
            size.Height = 5;
            return size;
        }

        public void HideBar()
        {
            OptionsBar.BarState = BarState.Collapsed;
        }

        public void ShowBar()
        {
            OptionsBar.BarState = BarState.Expanded;
        }

        protected override void OnBarChanged()
        {
            base.OnBarChanged();
            if (!DesignMode)
                EventSubscriber.CheckChange(BarControl, DockControl);
        }
    }
}