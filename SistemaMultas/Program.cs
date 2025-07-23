/*
 * Sistema de Gestión de Multas de Tránsito (MVP)
 * Desarrollado por: Celer Josué A.
 * 
 * Este sistema permite gestionar multas de tránsito aplicando conceptos de:
 * - Programación Orientada a Objetos (Herencia, Polimorfismo, Encapsulamiento)
 * - Patrones de Diseño (Singleton, Facade)
 * - Validaciones y manejo de estados
 */

using SistemaMultas.Clases;

namespace SistemaMultas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ISistMultas());            
        }
    }
}