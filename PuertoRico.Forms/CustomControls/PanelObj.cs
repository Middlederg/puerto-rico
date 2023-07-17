using PuertoRico.Core;
using PuertoRico.Core.Interfaces;
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
    public partial class PanelObj<T> : Panel
    {
        public T Objeto { get; }
        public bool Seleccionable { get; set; }

        private bool seleccionado;
        public bool Seleccionado
        {
            get { return seleccionado; }
            set
            {
                seleccionado = value;
                BackColor = seleccionado ? Constantes.ColorSeleccion : Color.Transparent;
            }
        }

        public PanelObj(IRuta ruta, int margen = 4, double escala = 1.0)
        {
            InitializeComponent();

            Objeto = (T)ruta;

            var imagen = MediaExtensions.GetImage(ruta.GetRuta());
            PbxImagen.Image = imagen;
            PbxImagen.Click += PbxImagen_Click;
            Padding = new Padding(margen);

            Width = (int)(imagen.Size.Width * escala);
            Height = (int)(imagen.Size.Height * escala);

            Controls.Add(PbxImagen);
        }

        private void PbxImagen_Click(object sender, EventArgs e)
        {
            if (Seleccionable)
                Seleccionado = !Seleccionado;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
