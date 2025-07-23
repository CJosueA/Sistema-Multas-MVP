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
    ///     Clase que implementa el patrón Singleton para manejar la información del tiquete/factura.
    ///     Garantiza que solo exista una instancia para gestionar los datos de las multas procesadas.
    /// </summary>
    internal class Tiquete
    {
        #region Propiedades Singleton
        /// <summary>Almacena los datos de las multas procesadas para la facturación</summary>
        private static string DatosMultas { get; set; } = string.Empty;

        /// <summary>Instancia única de la clase siguiendo el patrón Singleton</summary>
        private static Tiquete InstanciaTiquete;
        #endregion

        #region Constructor Privado
        /// <summary>
        /// Constructor privado que impide la instanciación directa.
        /// Forma parte de la implementación del patrón Singleton.
        /// </summary>
        private Tiquete()
        {
            // Constructor vacío siguiendo el patrón Singleton
        }
        #endregion

        #region Métodos Singleton
        /// <summary>
        ///     Obtiene la única instancia de la clase Tiquete.
        ///     Implementa lazy initialization thread-safe del patrón Singleton.
        /// </summary>
        /// <returns>La instancia única de Tiquete</returns>
        public static Tiquete ObtenerTiquete()
        {
            if (InstanciaTiquete == null)
            {
                InstanciaTiquete = new Tiquete();
            }
            return InstanciaTiquete;
        }
        #endregion

        #region Gestión de Datos de Multas
        /// <summary>
        /// Agrega nueva información de multas a los datos existentes.
        /// Permite acumular múltiples multas en el mismo tiquete.
        /// </summary>
        /// <param name="datos">String con la información de la multa a agregar</param>
        public static void Salvar(string datos)
        {
            if (!string.IsNullOrEmpty(datos))
            {
                DatosMultas += datos;
            }
        }

        /// <summary>
        /// Limpia todos los datos de multas almacenados.
        /// Útil para preparar un nuevo procesamiento.
        /// </summary>
        public static void LimpiarDatosMultas()
        {
            DatosMultas = string.Empty;
        }

        /// <summary>
        /// Obtiene todos los datos de multas procesadas.
        /// </summary>
        /// <returns>String con la información completa para facturación</returns>
        public static string GetDatosMultas()
        {
            return DatosMultas ?? string.Empty;
        }

        /// <summary>
        /// Establece directamente los datos de multas.
        /// Permite sobrescribir completamente la información existente.
        /// </summary>
        /// <param name="datos">Nuevos datos de multas</param>
        public static void SetDatosMultas(string datos)
        {
            DatosMultas = datos ?? string.Empty;
        }
        #endregion

    }
}
