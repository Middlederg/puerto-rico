using PuertoRico.Core.Enums;
using PuertoRico.Core.Interfaces;
using PuertoRico.Core.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuertoRico.Core.Model
{
    public interface IPlayer
    {
        int Id { get; }
        string Nombre { get; }
        int Doblones { get; set; }
        int Puntos { get; set; }
        int SanJuan { get; set; }
        List<ICampo> Campos { get; set; }
        List<IEdificio> Edificios { get; set; }
        List<Mercancia> Mercancias { get; set; }
        List<Profesion> Profesiones { get; set; }

        int Canteras { get; }
        int CanterasActivas { get; }
        int EspacioEdificado { get; }
        bool EdificioActivo(IEdificio e);
        IEnumerable<Mercancia> PuedeGenerar();
        int PuedeGenerar(TipoRecurso r);

        void Reset(int doblones, ICampo campoInicial);
    }

    public class Player : IPlayer
    {
        public int Id { get; }

        public string Nombre { get; }

        public int Doblones { get; set; }
        public int Puntos { get; set; }
        public int SanJuan { get; set; }
        public List<ICampo> Campos { get; set; }
        public List<IEdificio> Edificios { get; set; }
        public List<Mercancia> Mercancias { get; set; }
        public List<Profesion> Profesiones { get; set; }

        public int Canteras => Campos.Count(x => x.Recurso.Equals(TipoRecurso.Cantera));
        public int CanterasActivas => NumCamposActivos(TipoRecurso.Cantera);
        public int EspacioEdificado => Edificios.Sum(x => x.Casillas);

        public object TurnosJugados { get; internal set; }

        public bool EdificioActivo(IEdificio e) => Edificios.Where(x => x.NumColonos() > 0).Any(x => x.Equals(e));
        
        public Player(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void Reset(int doblones, ICampo campoInicial)
        {
            Doblones = doblones;
            Puntos = 0;
            SanJuan = 0;
            Campos = new List<ICampo>();
            Campos.Add(campoInicial);
            Edificios = new List<IEdificio>();
            Mercancias = new List<Mercancia>();
            Profesiones = new List<Profesion>();
        }

        public IEnumerable<Mercancia> PuedeGenerar() 
        {
            foreach (var r in new List<TipoRecurso>() { TipoRecurso.Anil, TipoRecurso.Azucar, TipoRecurso.Tabaco, TipoRecurso.Cafe })
            {
                int num = PuedeGenerar(r);
                foreach (Mercancia m in Mercancia.ListaMercancias(new Mercancia(r), num))
                    yield return m;
            }
            foreach (var item in Enumerable.Range(0, NumMaizQuePuedeGenerar()))
                yield return ObjectFactory.Maiz;
        }

        public int PuedeGenerar(TipoRecurso r)
        {
            if (r.Equals(TipoRecurso.Cantera))
                throw new ArgumentException("Las canteras no generan recursos");
            if (r.Equals(TipoRecurso.Maiz))
                return NumMaizQuePuedeGenerar();

            var numRecursosPorEdificios = Edificios
                .Where(x => x.Tipo.Equals(TipoEdificio.Produccion) && x.Genera.Recurso.Equals(r))
                .SelectMany(x=> PuedeGenerar()).Count();

            return Math.Min(numRecursosPorEdificios, NumCamposActivos(r));
        }

        private int NumCamposActivos(TipoRecurso r) => Campos.Count(x => x.Ocupado && x.Recurso.Equals(r));
        private int NumMaizQuePuedeGenerar() => Campos.Count(x => x.Ocupado && x.Recurso.Equals(TipoRecurso.Maiz));

      

    }
}
