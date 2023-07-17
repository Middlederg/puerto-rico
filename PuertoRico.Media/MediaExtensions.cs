using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    public static class MediaExtensions
    {
        /// <summary>
        /// Recupera la imagen almacenada como recurso
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Image GetImage(string fileName)
            => (Image)PuertoRico.Media.Properties.Resources.ResourceManager.GetObject(fileName);
        
    }
}
