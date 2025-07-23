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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaMultas.Clases
{
    internal class Chofer
    {
        #region Propiedades Privadas
        /// <summary>Número de licencia del conductor</summary>
        private string Licencia { get; set; }

        /// <summary>Nombre completo del conductor</summary>
        private string Nombre { get; set; }

        /// <summary>Sexo del conductor (M/F)</summary>
        private string Sexo { get; set; }

        /// <summary>Cantidad actual de puntos en la licencia</summary>
        private double CantPuntos { get; set; }

        /// <summary>Monto total acumulado a pagar por multas</summary>
        private double MontoAPagar { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        ///     Constructor por defecto que inicializa un chofer con valores predeterminados.
        ///     Todos los conductores inician con 1000 puntos según las reglas del sistema.
        /// </summary>
        public Chofer() 
        {
            this.Licencia = string.Empty;
            this.Nombre = string.Empty;
            this.Sexo = string.Empty;
            this.CantPuntos = 1000; // Puntos iniciales según reglas del sistema
            this.MontoAPagar = 0;
        }

        /// <summary>
        ///     Constructor parametrizado que inicializa un chofer con datos específicos.
        /// </summary>
        /// <param name="licencia">Número de licencia del conductor</param>
        /// <param name="nombre">Nombre completo del conductor</param>
        /// <param name="sexo">Sexo del conductor</param>
        public Chofer(string licencia, string nombre, string sexo) 
        {
            this.Licencia = licencia ?? string.Empty;
            this.Nombre = nombre ?? string.Empty;
            this.Sexo = sexo ?? string.Empty;
            this.CantPuntos = 1000; // Puntos iniciales según reglas del sistema
            this.MontoAPagar = 0;
        }
        #endregion

        #region Métodos de Acceso (Getters)
        /// <summary>
        /// Obtiene el número de licencia del conductor.
        /// </summary>
        /// <returns>Número de licencia como string</returns>
        public string GetLicencia()
        {
            return Licencia;
        }

        /// <summary>
        /// Obtiene el nombre completo del conductor.
        /// </summary>
        /// <returns>Nombre completo como string</returns>
        public string GetNombre()
        {
            return Nombre;
        }

        /// <summary>
        /// Obtiene el sexo del conductor.
        /// </summary>
        /// <returns>Sexo como string (M/F)</returns>
        public string GetSexo()
        {
            return Sexo;
        }

        /// <summary>
        /// Obtiene la cantidad actual de puntos en la licencia.
        /// </summary>
        /// <returns>Puntos actuales como double</returns>
        public double GetCantPuntos()
        {
            return CantPuntos;
        }

        /// <summary>
        /// Obtiene el monto total acumulado a pagar.
        /// </summary>
        /// <returns>Monto total como double</returns>
        public double GetMontoAPagar()
        {
            return MontoAPagar;
        }
        #endregion

        #region Métodos de Modificación (Setters)
        /// <summary>
        /// Actualiza la cantidad de puntos del conductor.
        /// Útil para aplicar los descuentos por infracciones.
        /// </summary>
        /// <param name="cantPuntos">Nueva cantidad de puntos</param>
        public void SetCantPuntos(double cantPuntos)
        {
            // Validación para evitar puntos negativos
            this.CantPuntos = cantPuntos;
        }

        /// <summary>
        /// Acumula un monto adicional al total a pagar.
        /// Permite sumar múltiples multas al mismo conductor.
        /// </summary>
        /// <param name="montoPagar">Monto adicional a agregar</param>
        public void SetMontoPagar(double montoPagar)
        {
            // Solo suma si el monto es positivo
            if (montoPagar > 0)
                this.MontoAPagar += montoPagar;
        }
        #endregion
    }
}
