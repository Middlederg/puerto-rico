using PuertoRico.Core.Enums;
using PuertoRico.Core.Interfaces;
using PuertoRico.Core.Model;
using System;
using System.Collections.Generic;

namespace PuertoRico.Core.Negocio
{
    public class ConfiguracionInicial
    {
        public readonly int NumMinimoJugadores = 2;
        public readonly int NumMaximoJugadores = 5;

        public readonly int NumJugadores;

        public ConfiguracionInicial(int numJugadores)
        {
            NumJugadores = numJugadores;
            if (numJugadores < NumMinimoJugadores || numJugadores > NumMaximoJugadores)
                throw new ArgumentOutOfRangeException($"Jugadores: {numJugadores}. Número de jugadores debe estar entre 2 y 5");
        }

        public int Dinero()
        {
            switch (NumJugadores)
            {
                case 2:
                case 4: return 3;
                case 3: return 2;
                case 5: return 5;
            }
            throw new NotImplementedException();
        }

        public ICampo CampoInicio(int indxJugador)
        {
            if (indxJugador >= NumJugadores) throw new ArgumentOutOfRangeException($"Indice de jugador ({indxJugador}) no puede ser mayor que el número de jugadores ({NumJugadores})");
            if (indxJugador == 0) return ObjectFactory.Create(TipoRecurso.Anil);
            if (indxJugador == 1 && NumJugadores <= 4) return ObjectFactory.Create(TipoRecurso.Anil);
            if (indxJugador == 2 && NumJugadores <= 5) return ObjectFactory.Create(TipoRecurso.Anil);
            return ObjectFactory.Create(TipoRecurso.Maiz);
        }

        public int PuntosVictoria()
        {
            switch (NumJugadores)
            {
                case 2: return 65;
                case 3: return 75;
                case 4: return 100;
                case 5: return 122;
            }
            throw new NotImplementedException();
        }

        public int Colonos()
        {
            switch (NumJugadores)
            {
                case 2: return 40;
                case 3: return 55;
                case 4: return 75;
                case 5: return 95;
            }
            throw new NotImplementedException();
        }

        public int Montones => NumJugadores + 1;

        public int NumPlantaciones(ICampo campo)
        {
            int modificador = NumJugadores == 2 ? 3 : 0;
            return campo.TotalReserva - modificador;
        }

        public int NumMercancias(ICampo campo)
        {
            int modificador = NumJugadores == 2 ? 2 : 0;
            return campo.TotalMercancias - modificador;
        }

        public List<Profesion> Personajes()
        {
            var lista = new List<Profesion>()
            {
                ObjectFactory.Colonizador,
                ObjectFactory.Alcalde,
                ObjectFactory.Constructor,
                ObjectFactory.Capataz,
                ObjectFactory.Mercader,
                ObjectFactory.Capitan
            };
            if (NumJugadores == 2 || NumJugadores == 4)
                lista.Add(ObjectFactory.BuscadorOro1);
            if (NumJugadores == 5)
                lista.Add(ObjectFactory.BuscadorOro2);
            return lista;
        }

        public IEnumerable<Barco> Barcos()
        {
            var numeroBarcos = new Dictionary<int, int[]>()
            {
                { 2, new int[]{ 4, 6 } },
                { 3, new int[]{ 4, 5, 6 } },
                { 4, new int[]{ 5, 6, 7 } },
                { 5, new int[]{ 6, 7, 8 } }
            };
            numeroBarcos.TryGetValue(NumJugadores, out int[] numeros);
            foreach (var capacidad in numeros)
                yield return new Barco(capacidad);
        }
    }
}
