using PuertoRico.Core.Model;
using PuertoRico.Forms.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PuertoRico.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var e = Core.Negocio.ObjectFactory.Hacienda;
            Controls.Add(new PanelObj<Hacienda>(e) { Seleccionable = true });

            var c = Core.Negocio.ObjectFactory.Create(Core.Enums.TipoRecurso.Azucar);
            var p = new PanelObj<Azucar>(c) { Seleccionable = true };
            p.Location = new Point(300, 300);
            Controls.Add(p);
        }
    }
}
