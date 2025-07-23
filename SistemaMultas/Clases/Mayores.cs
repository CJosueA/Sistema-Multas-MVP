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
    internal class Mayores : Multa
    {
        // Clase intermedia en la jerarquía de herencia
        // Permite agrupar infracciones de mayor gravedad
    }
}
