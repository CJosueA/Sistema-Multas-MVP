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
    ///     Clase que representa las multas por infracciones de estacionamiento.
    ///     Hereda de Multa e implementa los métodos específicos para este tipo de infracción.
    /// </summary>
    internal class Estacionamiento : Multa
    {

        /// <summary>
        ///     Constructor que inicializa el tipo de multa como "Estacionamiento".
        /// </summary>
        public Estacionamiento()
        {
            Tipo = "Estacionamiento";
        }

        /// <summary>
        ///     Calcula el monto fijo a pagar por multas de estacionamiento.
        ///     Según las reglas de negocio: ₡10,000.
        /// </summary>
        /// <returns>Monto de ₡10,000 por infracción de estacionamiento</returns>
        public override double Monto()
        {
            return 10000;
        }

        /// <summary>
        ///     Calcula los puntos a rebajar por multas de estacionamiento.
        ///     Según las reglas de negocio: 100 puntos.
        /// </summary>
        /// <returns>100 puntos a rebajar de la licencia</returns>
        public override double RebajoPuntos()
        {
            return 100;
        }

    }
}
