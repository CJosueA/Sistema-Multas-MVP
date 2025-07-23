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
    ///     Clase abstracta base que define la estructura común para todos los tipos de multas.
    ///     Implementa los métodos virtuales que serán sobrescritos por las clases derivadas.
    /// </summary>
    internal abstract class Multa
    {
        /// <summary>
        ///     Propiedad protegida que almacena el tipo de multa.
        ///     Accesible por las clases derivadas.
        /// </summary>
        protected String Tipo { get; set; }

        /// <summary>
        ///     Método virtual que calcula el monto monetario a pagar por la infracción.
        ///     Debe ser sobrescrito por las clases derivadas para implementar la lógica específica.
        /// </summary>
        /// <returns>Monto en colones a pagar por la multa</returns>
        public virtual double Monto()
        {
            return 0;
        }

        /// <summary>
        ///     Método virtual que calcula la cantidad de puntos a rebajar por la infracción.
        ///     Debe ser sobrescrito por las clases derivadas para implementar la lógica específica.
        /// </summary>
        /// <returns>Cantidad de puntos a rebajar de la licencia del conductor</returns>
        public virtual double RebajoPuntos()
        {
            return 0;
        }

        /// <summary>
        ///     Método virtual que retorna el tipo de multa aplicada.
        ///     Facilita la identificación del tipo de infracción cometida.
        /// </summary>
        /// <returns>String que describe el tipo de multa</returns>
        public virtual String GetTipoMulta() 
        {
            return Tipo ?? "No definido";
        }
    }
}