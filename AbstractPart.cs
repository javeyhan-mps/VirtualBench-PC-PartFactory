using MPS.Common.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.PartFactory
{
    public abstract class AbstractPart : IPart
    {
        private bool _canLsbMonitor = true;
        public bool CanLsbMonitor
        {
            get
            {
                return this._canLsbMonitor;
            }
            set
            {
                this._canLsbMonitor = value;
            }
        }

        public object lockFocus = new object();
        public string Partnumber { get; set; }


        private ObservableCollection<GroupItemInfo> _ControlGroupItems;
        public ObservableCollection<GroupItemInfo> ControlGroupItems
        {
            get
            {
                return this._ControlGroupItems;
            }
            set
            {
                this._ControlGroupItems = value;
            }
        }

        public ProjectConfig PjConfig { get; set; }

        public abstract ProjectConfig LoadConfig();

    }
}
