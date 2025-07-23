/*
 * Sistema de Gestión de Multas de Tránsito (MVP)
 * Desarrollado por: Celer Josué A.
 * 
 * Este sistema permite gestionar multas de tránsito aplicando conceptos de:
 * - Programación Orientada a Objetos (Herencia, Polimorfismo, Encapsulamiento)
 * - Patrones de Diseño (Singleton, Facade)
 * - Validaciones y manejo de estados
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMultas.Clases
{
    /// <summary>
    ///     Clase que implementa el patrón Facade para simplificar la interacción con el sistema de multas.
    ///     Proporciona una interfaz unificada para gestionar choferes, multas y cálculos complejos.
    ///     Oculta la complejidad interna del sistema y facilita su uso desde la interfaz gráfica.
    /// </summary>
    internal class FacadeMulta
    {
        #region Propiedades Privadas
        /// <summary>Instancia del chofer que está siendo procesado</summary>
        private Chofer NuevoChofer { get; set; } = new();

        /// <summary>Lista que almacena todas las multas aplicadas al chofer actual</summary>
        private List<Multa> ListaMultas { get; } = new List<Multa>();
        #endregion 

        #region Gestión de Multas
        /// <summary>
        ///     Agrega una nueva multa a la lista de infracciones del chofer actual.
        ///     Valida que la multa no sea nula antes de agregarla.
        /// </summary>
        /// <param name="tipoMulta">Objeto Multa a agregar a la lista</param>
        public void AgregarMultas(Multa tipoMulta)
        {
            if (tipoMulta != null)
            {
                ListaMultas.Add(tipoMulta);
            }
        }

        /// <summary>
        ///     Elimina todas las multas de la lista actual.
        ///     Útil al presionar el botón "Nuevo" para limpiar el estado.
        /// </summary>
        public void EliminarMultas()
        {
            ListaMultas.Clear();
        }

        /// <summary>
        ///     Obtiene la lista actual de multas.
        ///     Permite acceso de solo lectura desde el exterior.
        /// </summary>
        /// <returns>Lista de multas aplicadas al chofer actual</returns>
        public List<Multa> GetListaMultas()
        {
            return ListaMultas;
        }
        #endregion

        #region Gestión del Chofer
        /// <summary>
        ///     Asigna los datos del chofer capturados desde la interfaz gráfica.
        ///     Crea una nueva instancia de Chofer con los datos proporcionados.
        /// </summary>
        /// <param name="numLicencia">Número de licencia del conductor</param>
        /// <param name="nombre">Nombre completo del conductor</param>
        /// <param name="sexo">Sexo del conductor</param>
        public void AsignarChofer(string numLicencia, string nombre, string sexo)
        {
            NuevoChofer = new Chofer(numLicencia, nombre, sexo);
        }

        /// <summary>
        ///     Obtiene la instancia actual del chofer siendo procesado.
        ///     Permite acceso a todos los métodos y propiedades del chofer.
        /// </summary>
        /// <returns>Objeto Chofer actual</returns>
        public Chofer GetNuevoChofer()
        {
            return NuevoChofer;
        }
        #endregion

        #region Calculos
        /// <summary>
        /// Obtiene el monto total a pagar por todas las infracciones procesadas.
        /// </summary>
        /// <returns>Monto total en colones</returns>
        public double MontoPagar()
        {
            return NuevoChofer.GetMontoAPagar();
        }

        /// <summary>
        /// Obtiene los puntos disponibles después del procesamiento de multas.
        /// Convierte a entero para facilitar la visualización en el ProgressBar.
        /// </summary>
        /// <returns>Puntos restantes como entero</returns>
        public int PuntosDisponibles()
        {
            return Convert.ToInt32(NuevoChofer.GetCantPuntos());
        }
    #endregion
        
    }
}
