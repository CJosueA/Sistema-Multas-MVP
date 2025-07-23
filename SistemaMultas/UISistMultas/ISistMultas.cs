// Las declaraciones 'using' importan los espacios de nombres necesarios para los componentes de la UI,
// el manejo de datos y las clases personalizadas de la lógica de negocio.
using SistemaMultas.Clases;
using System.Data;
using System.Data.Common;

namespace SistemaMultas
{
    /// <summary>
    ///  Representa la interfaz de usuario principal para el Sistema de Gestión de Multas de Tránsito.
    ///     Esta clase maneja la entrada del usuario, activa los cálculos de la lógica de negocio a través
    ///     del patrón Facade y muestra los resultados. Es el código subyacente (code-behind) de la ventana principal de la aplicación.
    /// </summary>
    public partial class ISistMultas : Form
    {
        // --- CAMPOS ---

        /// <summary>
        ///     Un DataTable que se utiliza como fuente de datos para el DataGridView (grillaDatos).
        ///     Almacena y muestra la información procesada del conductor y la multa.
        /// </summary>
        private DataTable Tabla;

        /// <summary>
        ///     Una instancia de la clase FacadeMulta. Este objeto actúa como una interfaz central y simplificada
        ///     para la lógica compleja del sistema (gestión de choferes, cálculo de multas),
        ///     demostrando el patrón de diseño Facade
        /// </summary>
        private FacadeMulta Facademulta1 = new();

        /// <summary>
        ///     Objetos pre-instanciados para cada tipo específico de multa
        ///     Estos objetos se utilizan para aplicar las multas de forma polimórfica, llamando a sus respectivos
        ///     métodos Monto() y RebajoPuntos().
        /// </summary>
        private Estacionamiento MultaPorEstacionamiento = new();
        private Velocidad MultaPorVelocidad = new();
        private Alcohol MultaPorAlcohol = new();

        /// <summary>
        ///     Una bandera booleana para controlar el estado de la aplicación. Asegura que solo el conjunto de multas
        ///     de un conductor pueda ser procesado a la vez, como lo indican los requerimientos.
        ///     Se restablece al hacer clic en el botón "Nuevo".
        /// </summary>
        private bool procesandoChofer = false;


        // --- CONSTRUCTOR ---

        /// <summary>
        /// Inicializa los componentes del formulario y configura el estado inicial de la UI,
        /// incluyendo la creación de las columnas para la cuadrícula de datos.
        /// </summary>
        public ISistMultas()
        {
            InitializeComponent();
            // Prepara el DataGridView con las columnas necesarias al cargar.
            mostrarTabla();
        }

        // --- MANEJADORES DE EVENTOS (EVENT HANDLERS) ---

        /// <summary>
        ///     Maneja el evento de clic para el botón "Aceptar". Este es el método principal que
        ///     orquesta la validación, el cálculo y la visualización de los datos de la multa.
        /// </summary>
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            // Un bloque try-catch para manejar de forma segura posibles FormatExceptions si el usuario
            // introduce un valor no numérico para el nivel de alcohol en sangre.
            try
            {
                // Verifica que no se esté procesando ya un conductor, aplicando la regla de "un conductor a la vez"
                if (procesandoChofer == false)
                {
                    // Recopila la información del conductor desde la UI y la asigna al objeto Chofer a través del Facade
                    AgregarDatosChoferAObjetoChofer();

                    // Esta serie de sentencias condicionales comprueba todas las combinaciones posibles de multas seleccionadas.
                    // También valida que los datos esenciales del conductor estén presentes antes de realizar cualquier cálculo.
                    if (checkBoxEstacionamiento.Checked && checkBoxVelocidad.Checked == false
                        && checkBoxAlcohol.Checked == false && estanLosDatosRequeridos())
                    {
                        // Caso 1: Solo se selecciona la multa por Estacionamiento.
                        MultaEstacionamientoMonto();
                        MultaEstacionamientoPuntos();
                        Facademulta1.AgregarMultas(MultaPorEstacionamiento);
                    }
                    else if (checkBoxVelocidad.Checked && checkBoxEstacionamiento.Checked == false
                        && checkBoxAlcohol.Checked == false && estanLosDatosRequeridos())
                    {
                        // Caso 2: Solo se selecciona la multa por Velocidad.
                        MultaVelocidadMonto();
                        MultaVelocidadPuntos();
                        Facademulta1.AgregarMultas(MultaPorVelocidad);

                    }
                    else if (checkBoxAlcohol.Checked && checkBoxVelocidad.Checked == false
                        && checkBoxEstacionamiento.Checked == false && estanLosDatosRequeridos())
                    {
                        // Caso 3: Solo se selecciona la multa por Alcohol.

                        // Valida que el nivel de alcohol introducido esté dentro del rango sancionable.
                        if (double.Parse(txtCantAlcohol.Text) < 0.81)
                        {
                            MessageBox.Show("La cantidad mínima de alcohol en sangre penalizada es de: 0.81 g/Ls.", "Cantidad de Alcohol No Penalizada!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MultaAlcoholMonto(double.Parse(txtCantAlcohol.Text));
                            MultaAlcoholPuntos(double.Parse(txtCantAlcohol.Text));
                            Facademulta1.AgregarMultas(MultaPorAlcohol);
                        }

                    }
                    else if (checkBoxVelocidad.Checked && checkBoxEstacionamiento.Checked
                        && checkBoxAlcohol.Checked == false && estanLosDatosRequeridos())
                    {
                        // Caso 4: Se seleccionan multas por Estacionamiento y Velocidad.

                        double montoTotal = MultaPorEstacionamiento.Monto() + MultaPorVelocidad.Monto();
                        double puntosRestantes = MultaPorEstacionamiento.RebajoPuntos() + MultaPorVelocidad.RebajoPuntos();
                        puntosRestantes = Facademulta1.GetNuevoChofer().GetCantPuntos() - puntosRestantes;

                        Facademulta1.AgregarMultas(MultaPorEstacionamiento);
                        Facademulta1.AgregarMultas(MultaPorVelocidad);

                        Facademulta1.GetNuevoChofer().SetMontoPagar(montoTotal);
                        Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);

                    }
                    else if (checkBoxEstacionamiento.Checked && checkBoxVelocidad.Checked == false && checkBoxAlcohol.Checked
                        && estanLosDatosRequeridos())
                    {
                        // Caso 5: Se seleccionan multas por Estacionamiento y Alcohol.

                        if (double.Parse(txtCantAlcohol.Text) < 0.81)
                        {
                            MessageBox.Show("La cantidad mínima de alcohol en sangre penalizada es de: 0.81 g/Ls.",
                                "Cantidad de Alcohol No Penalizada!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            double montoTotal = MultaPorEstacionamiento.Monto() + MultaPorAlcohol.Monto(double.Parse(txtCantAlcohol.Text));
                            double puntosRestantes = MultaPorEstacionamiento.RebajoPuntos() + MultaPorAlcohol.RebajoPuntos(
                                double.Parse(txtCantAlcohol.Text));
                            puntosRestantes = (Facademulta1.GetNuevoChofer().GetCantPuntos()) - puntosRestantes;

                            Facademulta1.GetNuevoChofer().SetMontoPagar(montoTotal);
                            Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);

                            Facademulta1.AgregarMultas(MultaPorEstacionamiento);
                            Facademulta1.AgregarMultas(MultaPorAlcohol);
                        }
                    }
                    else if (checkBoxEstacionamiento.Checked == false && checkBoxVelocidad.Checked && checkBoxAlcohol.Checked
                        && estanLosDatosRequeridos())
                    {
                        // Caso 6: Se seleccionan multas por Velocidad y Alcohol.

                        if (double.Parse(txtCantAlcohol.Text) < 0.81)
                        {
                            MessageBox.Show("La cantidad mínima de alcohol en sangre penalizada es de: 0.81 g/Ls.",
                                "Cantidad de Alcohol No Penalizada!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            double montoTotal = MultaPorVelocidad.Monto() + MultaPorAlcohol.Monto(double.Parse(txtCantAlcohol.Text));
                            double puntosRestantes = MultaPorVelocidad.RebajoPuntos() +
                                MultaPorAlcohol.RebajoPuntos(double.Parse(txtCantAlcohol.Text));
                            puntosRestantes = Facademulta1.GetNuevoChofer().GetCantPuntos() - puntosRestantes;

                            Facademulta1.GetNuevoChofer().SetMontoPagar(montoTotal);
                            Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);

                            Facademulta1.AgregarMultas(MultaPorVelocidad);
                            Facademulta1.AgregarMultas(MultaPorAlcohol);
                        }
                    }
                    else if (checkBoxEstacionamiento.Checked && checkBoxVelocidad.Checked && checkBoxAlcohol.Checked &&
                        estanLosDatosRequeridos())
                    {
                        // Caso 7: Se seleccionan las tres multas.

                        if (double.Parse(txtCantAlcohol.Text) < 0.81)
                        {
                            MessageBox.Show("La cantidad mínima de alcohol en sangre penalizada es de: 0.81 g/Ls.",
                                "Cantidad de Alcohol No Penalizada!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            double montoTotal = MultaPorEstacionamiento.Monto() + MultaPorVelocidad.Monto() +
                            MultaPorAlcohol.Monto(double.Parse(txtCantAlcohol.Text));
                            double puntosRestantes = MultaPorEstacionamiento.RebajoPuntos() + MultaPorVelocidad.RebajoPuntos() +
                                MultaPorAlcohol.RebajoPuntos(double.Parse(txtCantAlcohol.Text));
                            puntosRestantes = (Facademulta1.GetNuevoChofer().GetCantPuntos()) - puntosRestantes;

                            Facademulta1.GetNuevoChofer().SetMontoPagar(montoTotal);
                            Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);

                            Facademulta1.AgregarMultas(MultaPorEstacionamiento);
                            Facademulta1.AgregarMultas(MultaPorVelocidad);
                            Facademulta1.AgregarMultas(MultaPorAlcohol);
                        }
                    }

                    // Validación final antes de mostrar los datos. Esto asegura que los resultados solo se muestren
                    // si se proporcionaron todas las entradas requeridas y se procesó al menos una multa válida.
                    if (estanLosDatosRequeridos() && checkBoxAlcohol.Checked && double.Parse(txtCantAlcohol.Text) > 0.8 ||
                        estanLosDatosRequeridos() && checkBoxAlcohol.Checked == false)
                    {
                        // Rellena el DataGridView con los datos finales calculados
                        mostrarDatosEnGrid();
                        // Bloquea el formulario para no procesar otro conductor hasta que se presione "Nuevo".
                        // volver a introducir más.
                        procesandoChofer = true;

                        // Comprueba si el conductor ha perdido todos los puntos de su licencia y emite una advertencia
                        if (Facademulta1.GetNuevoChofer().GetCantPuntos() <= 0)
                        {
                            MessageBox.Show("El chofer perdio todos sus puntos, la licencia le sera revocada para siempre!...", "Aviso de Licencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // --- PERSISTENCIA DE DATOS PARA LA FACTURA ---
                        // El siguiente bucle itera a través de la lista de multas aplicadas y guarda sus detalles
                        // en el objeto Singleton 'Tiquete', preparando los datos para la factura.
                        int cantidadMultas = Facademulta1.GetListaMultas().Count;
                        for (int i = 0; i < cantidadMultas; i++)
                        {
                            // Manejo especial para la multa de Alcohol, ya que requiere el nivel específico de alcohol en sangre
                            if (Facademulta1.GetListaMultas()[i] == MultaPorAlcohol)
                            {
                                Tiquete.Salvar($"> Multa #{i + 1}:\n- Tipo de Multa: {Facademulta1.GetListaMultas()[i].GetTipoMulta()}\n" +
                                $"- Alcohol en Sangre: {txtCantAlcohol.Text} g/LS \n- Monto a Pagar: " +
                                $"${MultaPorAlcohol.Monto(double.Parse(txtCantAlcohol.Text))}\n- Puntos a Rebajar: " +
                                $"{MultaPorAlcohol.RebajoPuntos(double.Parse(txtCantAlcohol.Text))}\n\n\n");
                            }
                            else
                            {
                                Tiquete.Salvar($"-> Multa #{i + 1}:\n- Tipo de Multa: {Facademulta1.GetListaMultas()[i].GetTipoMulta()}\n" +
                                $"- Monto a Pagar: ${Facademulta1.GetListaMultas()[i].Monto()}\n- Puntos a Rebajar: " +
                                $"{Facademulta1.GetListaMultas()[i].RebajoPuntos()}\n\n\n");
                            }
                        }

                    }
                    else
                    {
                        // Muestra un mensaje de error si faltan datos requeridos.
                        MessageBox.Show("Ingrese los datos requeridos para aplicar la multa!...", "Faltan Datos!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    // Informa al usuario que no se puede procesar una nueva entrada hasta que se reinicie el formulario.
                    MessageBox.Show("Solo se puede procesar un sujeto a la vez!...", "Estado de la Solicitud",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                // Captura y maneja el error por una entrada no válida en el nivel de alcohol.
                MessageBox.Show($"La cantidad de alcohol en sangre indicada NO es valida, esta tiene que ser indicada en números y con coma!...",
                    "Formato no valido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        ///     Maneja el evento de clic del botón "Muestra Factura"[cite: 156].
        ///     Recupera la cadena de texto formateada con los detalles de las multas desde el Singleton Tiquete y la muestra.
        /// </summary>
        private void btnFactura_Click(object sender, EventArgs e)
        {
            // Comprueba si se han guardado datos de multas antes de intentar mostrar la factura.
            if (String.IsNullOrWhiteSpace(Tiquete.GetDatosMultas()))
            {
                // Mensaje para indicar que no se han aplicado multas por lo tanto no se puede emitir una factura.
                MessageBox.Show("No se han aplicado multas, NO hay datos para mostrar!", "No hay Multas!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Se muestra el tiquete con la factura de las multas.
                MessageBox.Show(Tiquete.GetDatosMultas(), "Factura de Multas Aplicadas: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     Maneja el evento de clic para el botón "Salir". Cierra la aplicación.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Maneja el evento de clic para el botón "Nuevo". Restablece el estado de la aplicación
        ///     y limpia la UI para permitir una nueva entrada de conductor.
        /// </summary>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Restablece la bandera de procesamiento para permitir procesar a un nuevo conductor.
            procesandoChofer = false;

            // Limpia los datos del Singleton Tiquete para preparar una nueva factura.
            Tiquete.SetDatosMultas("");

            // Restablece el objeto del conductor y limpia la lista de multas en el Facade
            Facademulta1.AsignarChofer(null, null, null);
            Facademulta1.EliminarMultas();

            // Limpia todos los controles de entrada en la UI.
            txtNumLicencia.Text = null;
            txtNombre.Text = null;
            txtCantAlcohol.Text = null;
            radBtnFemenino.Checked = false;
            radBtnMasculino.Checked = false;
            checkBoxEstacionamiento.Checked = false;
            checkBoxVelocidad.Checked = false;
            checkBoxAlcohol.Checked = false;

            // Limpia las filas del DataGridView.
            Tabla.Rows.Clear();
        }

        // --- MÉTODOS DE AYUDA (HELPER METHODS) ---

        /// <summary>
        ///     Recopila el número de licencia, nombre y género del conductor desde los controles de la UI
        ///     y utiliza el Facade para crear una nueva instancia de Chofer[cite: 122].
        /// </summary>
        private void AgregarDatosChoferAObjetoChofer()
        {
            // Condicional usado para determinar si el sujeto de la multa es hombre o mujer.
            if (radBtnFemenino.Checked == true)
            {
                Facademulta1.AsignarChofer(txtNumLicencia.Text, txtNombre.Text, "Femenino");
            }
            else if (radBtnMasculino.Checked == true)
            {
                Facademulta1.AsignarChofer(txtNumLicencia.Text, txtNombre.Text, "Masculino");
            }
        }

        /// <summary>
        ///     Agrega una nueva fila al DataGridView con los resultados finales del procesamiento de la multa.
        /// </summary>
        private void mostrarDatosEnGrid()
        {
            Tabla.Rows.Add(Facademulta1.GetNuevoChofer().GetLicencia(), Facademulta1.GetNuevoChofer().GetNombre(),
                Facademulta1.GetNuevoChofer().GetSexo(), Facademulta1.GetNuevoChofer().GetMontoAPagar(),
                Facademulta1.GetNuevoChofer().GetCantPuntos());
        }

        /// <summary>
        ///     Calcula y aplica la sanción monetaria para una multa por estacionamiento.
        ///     Actualiza el monto total a pagar del conductor a través del Facade.
        /// </summary>
        private double MultaEstacionamientoMonto()
        {
            Facademulta1.GetNuevoChofer().SetMontoPagar(Facademulta1.GetNuevoChofer().GetMontoAPagar() +
                MultaPorEstacionamiento.Monto());

            return Facademulta1.GetNuevoChofer().GetMontoAPagar();
        }

        /// <summary>
        ///     Calcula y aplica la deducción de puntos por una multa de estacionamiento.
        ///     Actualiza los puntos restantes del conductor a través del Facade.
        /// </summary>
        private double MultaEstacionamientoPuntos()
        {
            double puntosRestantes = ((Facademulta1.GetNuevoChofer().GetCantPuntos()) -
                MultaPorEstacionamiento.RebajoPuntos());

            Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);
            return Facademulta1.GetNuevoChofer().GetCantPuntos();
        }

        /// <summary>
        ///     Calcula y aplica la sanción monetaria por una multa de velocidad.
        /// </summary>
        private double MultaVelocidadMonto()
        {
            Facademulta1.GetNuevoChofer().SetMontoPagar(Facademulta1.GetNuevoChofer().GetMontoAPagar() +
                MultaPorVelocidad.Monto());

            return Facademulta1.GetNuevoChofer().GetMontoAPagar();
        }

        /// <summary>
        ///     Calcula y aplica la deducción de puntos por una multa de velocidad.
        /// </summary>
        private double MultaVelocidadPuntos()
        {
            double puntosRestantes = (Facademulta1.GetNuevoChofer().GetCantPuntos()) -
                MultaPorVelocidad.RebajoPuntos();

            Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);
            return Facademulta1.GetNuevoChofer().GetCantPuntos();
        }

        /// <summary>
        ///     Calcula y aplica la sanción monetaria por una multa relacionada con el alcohol.
        ///     Este método está sobrecargado y requiere el nivel de alcohol en sangre.
        /// </summary>
        /// <param name="pCantAlcohol">El contenido de alcohol en sangre medido.</param>
        private double MultaAlcoholMonto(double pCantAlcohol)
        {
            double montoTotal = (Facademulta1.GetNuevoChofer().GetMontoAPagar()) + MultaPorAlcohol.Monto(pCantAlcohol);
            Facademulta1.GetNuevoChofer().SetMontoPagar(montoTotal);
            return Facademulta1.GetNuevoChofer().GetMontoAPagar();
        }

        /// <summary>
        ///     Calcula y aplica la deducción de puntos por una multa relacionada con el alcohol.
        ///     Este método está sobrecargado y requiere el nivel de alcohol en sangre[cite: 52].
        /// </summary>
        /// <param name="pCantidadAlcohol">El contenido de alcohol en sangre medido.</param>
        private double MultaAlcoholPuntos(double pCantidadAlcohol)
        {
            double puntosRestantes = ((Facademulta1.GetNuevoChofer().GetCantPuntos()) - MultaPorAlcohol.RebajoPuntos(pCantidadAlcohol));
            Facademulta1.GetNuevoChofer().SetCantPuntos(puntosRestantes);
            return Facademulta1.GetNuevoChofer().GetCantPuntos();
        }

        /// <summary>
        ///     Inicializa el esquema del DataTable (columnas) y lo enlaza al control DataGridView.
        /// </summary>
        private DataTable mostrarTabla()
        {
            Tabla = new DataTable();
            Tabla.Columns.Add("Número Licencia");
            Tabla.Columns.Add("Nombre");
            Tabla.Columns.Add("Sexo");
            Tabla.Columns.Add("Monto a Pagar");
            Tabla.Columns.Add("Puntos Disponibles");
            grillaDatos.DataSource = Tabla;

            return Tabla;
        }

        /// <summary>
        ///     Un método de validación completo que comprueba si se han proporcionado todas las entradas
        ///     de usuario necesarias antes de permitir que continúe el procesamiento de la multa.
        /// </summary>
        /// <returns>True si todos los datos requeridos están presentes; de lo contrario, false.</returns>
        private bool estanLosDatosRequeridos()
        {
            // Variables utilizadas para determinar si faltan los datos necesarios.
            bool textBoxLlenos = false;
            bool radioBtmSeleccionado = false;
            bool checkBoxSeleccionado = false;
            bool cantidadAlcoholEspecificada = true;

            // Comprueba el número de licencia y el nombre del conductor
            if (string.IsNullOrWhiteSpace(txtNumLicencia.Text) == false &&
                string.IsNullOrWhiteSpace(txtNombre.Text) == false)
            {
                textBoxLlenos = true;
            }

            // Comprueba si se ha seleccionado el género.
            if (radBtnMasculino.Checked || radBtnFemenino.Checked)
            {
                radioBtmSeleccionado = true;
            }

            // Comprueba si se ha seleccionado al menos un tipo de multa
            if (checkBoxEstacionamiento.Checked || checkBoxVelocidad.Checked || checkBoxAlcohol.Checked)
            {
                checkBoxSeleccionado = true;
            }

            // Comprobación especial: si se selecciona la multa por alcohol, asegura que se haya introducido la cantidad
            if (checkBoxAlcohol.Checked && String.IsNullOrWhiteSpace(txtCantAlcohol.Text) == true)
            {
                cantidadAlcoholEspecificada = false;
            }

            // Todas las condiciones deben ser verdaderas para proceder.
            if (textBoxLlenos && radioBtmSeleccionado && checkBoxSeleccionado && cantidadAlcoholEspecificada)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // --- MEJORAS DE USABILIDAD DE LA UI ---

        /// <summary>
        ///     Una pequeña característica de usabilidad. Hacer clic en la etiqueta "Nombre"
        ///     establecerá el foco directamente en el cuadro de texto correspondiente para una entrada de datos más rápida.
        /// </summary>
        private void labelNombre_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        /// <summary>
        ///     Una pequeña característica de usabilidad. Hacer clic en la etiqueta "No Licencia"
        ///     establecerá el foco directamente en el cuadro de texto correspondiente.
        /// </summary>
        private void labelNumLicencia_Click(object sender, EventArgs e)
        {
            txtNumLicencia.Focus();
        }

        /// <summary>
        ///     Una mejora de usabilidad para el checkbox de la multa por alcohol.
        ///     Cuando se marca, enfoca automáticamente el cuadro de texto para el nivel de alcohol.
        ///     Cuando se desmarca, limpia el cuadro de texto.
        /// </summary>
        private void checkBoxAlcohol_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAlcohol.Checked)
            {
                txtCantAlcohol.Focus();
            }
            else
            {
                txtCantAlcohol.Clear();
            }
        }
    }
}