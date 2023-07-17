using System;
using System.Collections.Generic;
using System.Linq;

namespace PuertoRico.Core.Model
{
    public class Barco
    {
        public Mercancia[] Contenido { get; private set; }
        public bool Vacio => Contenido.All(x => x == null);
        public void Clear() => Contenido = new Mercancia[Contenido.Length];
        public int EspaciosOcupado => Contenido.Count(x => x != null);
        public int EspaciosVacios => Contenido.Count(x => x == null);

        public Barco(int capacidad)
        {
            Contenido = new Mercancia[capacidad];
        }

        public void Add(List<Mercancia> m)
        {
            if (!PodriaContener(m))
                throw new Exception($"Barco de {m.Count} casillas no puede contener {m.Count} {m.FirstOrDefault()?.ToString() ?? "Vacío"}");

            int index = 0;
            if (!Vacio)
                index = Contenido.ToList().IndexOf(Contenido.FirstOrDefault(x => x != null));
            foreach (var item in m)
            {
                Contenido[index] = item;
                index++;
            }
        }

        public bool PodriaContener(List<Mercancia> m)
        {
            if (m != null && m.Count > 0 && m.Distinct().Count() == 1)
            {
                if (m.Count <= EspaciosVacios)
                {
                    if (Vacio)
                        return true;
                    else
                    {
                        if (Contenido.First().Equals(m))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
