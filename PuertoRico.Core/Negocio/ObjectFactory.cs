using PuertoRico.Core.Enums;
using PuertoRico.Core.Model;
using System.Collections;
using System.Collections.Generic;

namespace PuertoRico.Core.Negocio
{
    public class ObjectFactory
    {
        public static Profesion Colonizador
           => new Profesion(1, "Colonizador", "Creación de nuevas plantaciones", "Toma una cantera en vez de una plantación");
        public static Profesion Alcalde
            => new Profesion(2, "Alcalde", "Llegada de nuevos colonos", "Toma un colono adicional de la reserva");
        public static Profesion Constructor
            => new Profesion(3, "Constructor", "Construcción de edificios", "Paga un doblón menos por construir un edificio");
        public static Profesion Capataz
            => new Profesion(4, "Capataz", "Producción de mercancías", "Toma un barril adicional de la reserva");
        public static Profesion Mercader
            => new Profesion(5, "Mercader", "Venta de mercancías", "Gana un doblón adicional al vender");
        public static Profesion Capitan
            => new Profesion(6, "Capitán", "Envío de mercancías", "Gana un PV adicional al cargar tus mercancías");
        public static Profesion BuscadorOro1
            => new Profesion(7, "Buscador de oro", "---", "Toma un doblón del banco");
        public static Profesion BuscadorOro2
            => new Profesion(8, "Buscador de oro", "---", "Toma un doblón del banco");

        public static Mercancia Maiz => new Mercancia(new Maiz());
        public static Mercancia Anil => new Mercancia(new Anil());
        public static Mercancia Azucar => new Mercancia(new Azucar());
        public static Mercancia Tabaco => new Mercancia(new Tabaco());
        public static Mercancia Cafe => new Mercancia(new Cafe());

        public static Campo Create(TipoRecurso recurso)
        {
            switch (recurso)
            {
                case TipoRecurso.Cantera: return new Cantera();
                case TipoRecurso.Maiz: return new Maiz();
                case TipoRecurso.Anil: return new Anil();
                case TipoRecurso.Azucar: return new Azucar();
                case TipoRecurso.Tabaco: return new Tabaco();
                case TipoRecurso.Cafe: return new Cafe();
                default: throw new System.Exception("Error");
            }
        }

        public static IEnumerable<Mercancia> GetMercancias()
        {
            return new List<Mercancia>()
            {
                Maiz,
                Anil,
                Azucar,
                Tabaco,
                Cafe
            };
        }

        public static IEnumerable<Mercancia> GetMercanciasExceptoMaiz()
        {
            return new List<Mercancia>()
            {
                Anil,
                Azucar,
                Tabaco,
                Cafe
            };
        }

        public static IEnumerable<Campo> GetCampos()
        {
            return new List<Campo>()
            {
                new Maiz(),
                new Anil(),
                new Azucar(),
                new Tabaco(),
                new Cafe()
            };
        }

        public static Aduana Aduana => new Aduana();
        public static AlmacenGrande AlmacenGrande => new AlmacenGrande();
        public static AlmacenPequeno AlmacenPequeno => new AlmacenPequeno();
        public static Anileria Anileria => new Anileria();
        public static AnileriaPequena AnileriaPequena => new AnileriaPequena();
        public static Ayuntamiento Ayuntamiento => new Ayuntamiento();
        public static Azucarera Azucarera => new Azucarera();
        public static AzucareraPequena AzucareraPequena => new AzucareraPequena();
        public static CasetaDeObra CasetaDeObra => new CasetaDeObra();
        public static Cofradia Cofradia => new Cofradia();
        public static Fabrica Fabrica => new Fabrica();
        public static Fortaleza Fortaleza => new Fortaleza();
        public static Hacienda Hacienda => new Hacienda();
        public static Hospicio Hospicio => new Hospicio();
        public static MercadoGrande MercadoGrande => new MercadoGrande();
        public static MercadoPequeno MercadoPequeno => new MercadoPequeno();
        public static Muelle Muelle => new Muelle();
        public static Oficina Oficina => new Oficina();
        public static Puerto Puerto => new Puerto();
        public static Residencia Residencia => new Residencia();
        public static SecaderoDeTabaco SecaderoDeTabaco => new SecaderoDeTabaco();
        public static TostaderoDeCafe TostaderoDeCafe => new TostaderoDeCafe();
        public static Universidad Universidad => new Universidad();
    }
}
