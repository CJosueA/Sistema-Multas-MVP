# Sistema de Gestión de Multas de Tránsito (MVP)

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

## 📖 Descripción General

Este proyecto es un **Producto Mínimo Viable (MVP)** de una aplicación de escritorio para la gestión de multas de tránsito. Fue desarrollado como parte de mi formación como **Técnico en Desarrollo de Software**, con el objetivo de aplicar y demostrar habilidades en el desarrollo de aplicaciones robustas y funcionales utilizando C# y la plataforma .NET con Windows Forms.

El sistema permite registrar conductores, seleccionar una o varias infracciones cometidas y calcular automáticamente el monto a pagar y los puntos a deducir de la licencia, generando una factura con el detalle de las sanciones.

## ✨ Características Principales

* **Registro de Conductores:** Ingreso de datos básicos del conductor (Nº de Licencia, Nombre Completo, Sexo).
* **Sistema de Puntos:** Cada conductor inicia con 1000 puntos que se deducen con cada infracción.
* **Selección de Multas:** Permite aplicar múltiples infracciones a un conductor en un solo proceso. Los tipos de multa incluyen:
    * Mal estacionamiento.
    * Exceso de velocidad.
    * Conducción bajo los efectos del alcohol.
* **Cálculos Dinámicos:**
    * El monto y los puntos a rebajar varían según la infracción.
    * Para la multa por alcohol, el sistema calcula la sanción basándose en la cantidad de gramos de alcohol en sangre ingresados.
* **Generación de Factura:** Muestra un resumen detallado de las multas aplicadas, los montos y los puntos rebajados.
* **Alerta de Revocación de Licencia:** Si los puntos de un conductor llegan a cero o menos, el sistema notifica que la licencia será revocada.
* **Procesamiento Individual:** La lógica está diseñada para procesar un único conductor a la vez, asegurando la integridad de los datos en cada transacción.

## 🛠️ Tecnologías y Conceptos Aplicados

Este proyecto fue una excelente oportunidad para aplicar fundamentos teóricos en un escenario práctico.

* **Lenguaje:** C#
* **Plataforma:** .NET Framework
* **Interfaz Gráfica:** Windows Forms (WinForms)
* **Paradigma de Programación:** Programación Orientada a Objetos (POO)
    * **Herencia:** Se utilizó una clase base `Multa` y clases derivadas (`Estacionamiento`, `Velocidad`, `Alcohol`) para estructurar los tipos de infracciones.
    * **Polimorfismo:** Se sobrescribieron los métodos `Monto()` y `RebajoPuntos()` en las clases hijas para implementar cálculos específicos para cada tipo de multa.
    * **Encapsulamiento:** Se protegió el estado interno de las clases mediante el uso de modificadores de acceso.
* **Patrones de Diseño de Software:**
    * **Singleton:** Aplicado en la clase `Tiquete` para garantizar una única instancia que gestione la información de la factura a generar, evitando datos duplicados o inconsistentes.
    * **Facade:** Utilizado para crear la clase `FacadeMulta`, que proporciona una interfaz simplificada y unificada para interactuar con la lógica más compleja del sistema (manejo de clases, cálculos, etc.) desde la interfaz de usuario.
* **Manejo de Excepciones:** Implementación de bloques `try-catch` y validaciones para controlar errores de formato (ej. en la entrada de datos de alcohol) y asegurar que el usuario ingrese toda la información necesaria antes de procesar los datos.

## 🖼️ Captura de Pantalla

*Aquí puedes ver la interfaz principal de la aplicación:*

<img width="688" height="369" alt="1-Interfaz Principal Vacía" src="https://github.com/user-attachments/assets/dfdd904f-edd3-415e-ba9e-6f12073258a4" />
<img width="688" height="369" alt="2-Interfaz Principal Con Datos" src="https://github.com/user-attachments/assets/a81f3f51-6029-46e6-b09d-ccb3884b4999" />
<img width="688" height="369" alt="3 0-Interfaz Principal Llena" src="https://github.com/user-attachments/assets/d2fef251-8fd8-4e70-a797-a7fb88c1a1d5" />
<img width="265" height="289" alt="3 1- Factura" src="https://github.com/user-attachments/assets/450738fc-13de-45ed-805e-9e82f860087e" />
<img width="688" height="369" alt="4- Datos Desplegados" src="https://github.com/user-attachments/assets/1bfbc64e-b507-4263-9f0d-deb5989cb6a1" />


## 🚀 Cómo Empezar

Para ejecutar este proyecto en tu máquina local, sigue estos pasos:

1.  **Clonar el repositorio:**
    ```bash
    git clone https://github.com/CJosueA/Sistema-Multas-MVP.git
    ```
2.  **Abrir en Visual Studio:**
    * Navega a la carpeta del proyecto y abre el archivo de solución (`.sln`) con Visual Studio.
3.  **Construir la Solución:**
    * En el menú superior, ve a `Build` > `Build Solution` (o presiona `Ctrl+Shift+B`). Esto restaurará las dependencias de .NET.
4.  **Ejecutar el Proyecto:**
    * Presiona el botón `Start` (o `F5`) para iniciar la aplicación.

## 🎓 Contexto del Proyecto

Este software fue desarrollado como proyecto final del segundo año de formación para la especialidad de **Informática en Desarrollo de Software** en el **Colegio Técnico Profesional de Aserrí**. El objetivo era consolidar los conocimientos adquiridos en programación orientada a objetos, diseño de interfaces gráficas y arquitectura de software básica, resolviendo un problema definido y cumpliendo con un conjunto de requerimientos específicos.

---

**Desarrollado por Celer Josué Agüero Gamboa**
