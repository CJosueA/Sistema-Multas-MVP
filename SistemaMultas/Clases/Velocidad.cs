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
    /// Clase que representa las multas por exceso de velocidad.
    /// Hereda de Mayores implementando los cálculos específicos para este tipo de infracción.
    /// </summary>
    internal class Velocidad : Mayores
    {

        /// <summary>
        /// Constructor que inicializa el tipo de multa como "Velocidad".
        /// </summary>
        public Velocidad()
        {
            Tipo = "Velocidad";
        }

        /// <summary>
        ///     Calcula el monto fijo a pagar por exceso de velocidad.
        ///     Según las reglas de negocio: ₡150,000.
        /// </summary>
        /// <returns>Monto de ₡150,000 por exceso de velocidad</returns>
        public override double Monto() 
        {
            return 150000;
        }

        /// <summary>
        /// Calcula los puntos a rebajar por exceso de velocidad.
        /// Según las reglas de negocio: 200 puntos.
        /// </summary>
        /// <returns>200 puntos a rebajar de la licencia</returns>
        public override double RebajoPuntos()
        {
            return 200;
        }
    }
}
