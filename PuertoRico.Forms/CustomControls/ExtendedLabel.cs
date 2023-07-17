using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuertoRico.Forms.CustomControls
{
    public partial class ExtendedLabel : Label
    {
        public int FontSize { get; set; } = 12;

        public ExtendedLabel()
        {
            InitializeComponent();
            Font = new Font("Corbel", FontSize, FontStyle.Bold);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
