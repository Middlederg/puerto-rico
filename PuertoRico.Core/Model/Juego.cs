using PuertoRico.Core.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using PuertoRico.Core.Negocio;
using PuertoRico.Core.Enums;

namespace PuertoRico.Core.Model
{
    public class Market
    {

    }

    public class Juego
    {
        public int NumeroReinicios { get; private set; }
        private readonly ConfiguracionInicial c;

        public int Gobernador { get; set; }
        public int Turno { get; set; }
        public List<Player> Jugadores { get; set; }

        public int Colonos { get; set; }
        public int Puntos { get; set; }
        public List<ICampo> Campos { get; set; }
        public List<IEdificio> Edificios { get; set; }
        public List<Mercancia> MercanciasDisponibles { get; set; }
        public List<Profesion> ProfesionesDisponibles { get; set; }
        public List<Barco> Barcos { get; set; }
        public Market Mercado { get; set; }
        public List<string> Log { get; set; }

        public Juego(string[] nombres)
        {
            Jugadores = new List<Player>();
            for (int i = 0; i < nombres.Length; i++)
                Jugadores.Add(new Player(i, nombres[i]));

            Log = new List<string> { $"Comienza el juego. Partida a {Jugadores.Count} jugadores" };
            c = new ConfiguracionInicial(Jugadores.Count);
            Campos = new List<ICampo>();
            Edificios = new List<IEdificio>();
            MercanciasDisponibles = new List<Mercancia>();
            ResetGame();
        }

        /// <summary>
        /// Reinicia el juego
        /// </summary>
        public void ResetGame()
        {
            NumeroReinicios++;
            if (NumeroReinicios > 1) Log.Add("Partida reiniciada");

            //Repartición inicial
            Turno = R.Instance.PrepararJugadorInicial(Jugadores.Count);
            Gobernador = Turno;
            int doblones = c.Dinero();
            for (int indxOrden = 0; indxOrden < Jugadores.Count; indxOrden++)
            {
                ICampo campo = c.CampoInicio(indxOrden);
                ElTurno().Reset(doblones, campo);
                AvanzaTurno();
            }
            Log.Add($"{Jugadores[Turno].Nombre} comienza la partida");

            //Preparación tablero
            Colonos = c.Colonos();
            Puntos = c.PuntosVictoria();
            foreach (var campo in ObjectFactory.GetCampos())
            {
                foreach (int i in Enumerable.Range(0, c.NumPlantaciones(campo)))
                    Campos.Add(campo);

            }
            foreach (int i in Enumerable.Range(0, c.NumPlantaciones(ObjectFactory.Create(TipoRecurso.Cantera))))
                Campos.Add(ObjectFactory.Create(TipoRecurso.Cantera));
            ProfesionesDisponibles = c.Personajes();
            Barcos = c.Barcos().ToList();
        }

        /// <summary>
        /// Devuelve el jugador que tiene el turno
        /// </summary>
        /// <returns></returns>
        public Player ElTurno() => Jugadores[Turno];

        /// <summary>
        /// Devuelve el jugador que es gobernador
        /// </summary>
        /// <returns></returns>
        public Player ElGobernador() => Jugadores[Gobernador];

        /// <summary>
        /// El turno pasa al siguiente jugador
        /// </summary>
        public void AvanzaTurno() => Turno = (Turno == Jugadores.Count - 1) ? 0 : Turno + 1;

        /// <summary>
        /// El gobernador pasa al siguiente jugador
        /// </summary>
        public void AvanzaGobernador() => Gobernador = (Gobernador == Jugadores.Count - 1) ? 0 : Gobernador + 1;

        /// <summary>
        /// Todos los jugadores han hecho elegido ya las profesiones que les correspondían
        /// </summary>
        /// <returns></returns>
        public bool TurnoCompletado()
        {
            int numProfesiones = Jugadores.Count == 2 ? 2 : 1;
            return Jugadores.Select(x => x.Profesiones).Count() >= numProfesiones;
        }

        /// <summary>
        /// Un jugador planta un campo o cantera en su isla
        /// </summary>
        /// <param name="p">Jugador</param>
        /// <param name="campo">Campo o cantera</param>
        public void ColonizarCampo(Player p, ICampo campo)
        {
            if (p.ColonizarCampo(campo, Colonos > 0))
                Colonos--;
            Campos.Remove(campo);
        }

        /// <summary>
        /// Un jugador construye un edificio en su isla
        /// </summary>
        /// <param name="p">Jugador</param>
        /// <param name="edificio">Edificio</param>
        public void ConstruirEdificio(Player p, IEdificio edificio)
        {
            if (p.Construir(edificio, Colonos > 0))
                Colonos--;
            Edificios.Remove(edificio);
        }
    }
}
