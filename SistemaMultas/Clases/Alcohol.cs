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
    /// Clase que representa las multas por conducir bajo efectos del alcohol.
    /// Implementa cálculos variables basados en el nivel de alcohol en sangre.
    /// Hereda de Mayores por ser una infracción grave.
    /// </summary>
    internal class Alcohol : Mayores
    {
        /// <summary>
        /// Constructor que inicializa el tipo de multa como "Alcohol".
        /// </summary>
        public Alcohol()
        {
            Tipo = "Alcohol";
        }

        /// <summary>
        /// Calcula el monto a pagar basado en el nivel de alcohol en sangre.
        /// Implementa sobrecarga de métodos para manejar el parámetro adicional.
        /// Reglas de negocio:
        /// - 0.8 - 1.0 g/L: ₡100,000
        /// - 1.01 - 1.5 g/L: ₡200,000  
        /// - > 1.5 g/L: ₡1,000,000
        /// </summary>
        /// <param name="cantidadAlcohol">Nivel de alcohol en sangre en gramos por litro</param>
        /// <returns>Monto calculado según el nivel de alcohol detectado</returns>
        public double Monto(double pCantidadAlcohol)
        {
            // Aplicación de las reglas de negocio por rangos
            if (pCantidadAlcohol > 0.8 && pCantidadAlcohol <= 1)
            {
                return 100000;
            }
            else if (pCantidadAlcohol > 1.01 && pCantidadAlcohol <= 1.5)
            {
                return 200000;
            }
            else if (pCantidadAlcohol > 1.5)
            {
                return 1000000;
            }
            else 
            {
                return 0; // No aplica multa si está por debajo del límite legal
            }
        }

        /// <summary>
        /// Calcula los puntos a rebajar basado en el nivel de alcohol en sangre.
        /// Implementa sobrecarga de métodos para manejar el parámetro adicional.
        /// Reglas de negocio:
        /// - 0.8 - 1.0 g/L: 250 puntos
        /// - 1.01 - 1.5 g/L: 500 puntos
        /// - > 1.5 g/L: 1000 puntos
        /// </summary>
        /// <param name="cantidadAlcohol">Nivel de alcohol en sangre en gramos por litro</param>
        /// <returns>Puntos a rebajar según el nivel de alcohol detectado</returns>
        public double RebajoPuntos(double pCantidadAlcohol) 
        {
            // Aplicación de las reglas de negocio por rangos
            if (pCantidadAlcohol > 0.8 && pCantidadAlcohol <= 1)
            {
                return 250;
            }
            else if (pCantidadAlcohol > 1.01 && pCantidadAlcohol <= 1.5)
            {
                return 500;
            }
            else if (pCantidadAlcohol > 1.5)
            {
                return 1000;
            }
            else
            {
                return 0; // No aplica rebajo si está por debajo del límite legal
            }
        }
    }
}