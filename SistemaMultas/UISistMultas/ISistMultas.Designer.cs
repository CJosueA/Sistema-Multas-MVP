/*
 * Sistema de Gestión de Multas de Tránsito (MVP)
 * Desarrollado por: Celer Josué A.
 * 
 * Este sistema permite gestionar multas de tránsito aplicando conceptos de:
 * - Programación Orientada a Objetos (Herencia, Polimorfismo, Encapsulamiento)
 * - Patrones de Diseño (Singleton, Facade)
 * - Validaciones y manejo de estados
 */

namespace SistemaMultas

{
    partial class ISistMultas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ISistMultas));
            gBoxTiposMultas = new GroupBox();
            txtCantAlcohol = new TextBox();
            checkBoxAlcohol = new CheckBox();
            checkBoxVelocidad = new CheckBox();
            checkBoxEstacionamiento = new CheckBox();
            gBoxDatosConductor = new GroupBox();
            txtNombre = new TextBox();
            txtNumLicencia = new TextBox();
            radBtnMasculino = new RadioButton();
            radBtnFemenino = new RadioButton();
            labelSexo = new Label();
            labelNombre = new Label();
            labelNumLicencia = new Label();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnFactura = new Button();
            btnSalir = new Button();
            grillaDatos = new DataGridView();
            gBoxTiposMultas.SuspendLayout();
            gBoxDatosConductor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grillaDatos).BeginInit();
            SuspendLayout();
            // 
            // gBoxTiposMultas
            // 
            resources.ApplyResources(gBoxTiposMultas, "gBoxTiposMultas");
            gBoxTiposMultas.Controls.Add(txtCantAlcohol);
            gBoxTiposMultas.Controls.Add(checkBoxAlcohol);
            gBoxTiposMultas.Controls.Add(checkBoxVelocidad);
            gBoxTiposMultas.Controls.Add(checkBoxEstacionamiento);
            gBoxTiposMultas.ForeColor = SystemColors.ControlLightLight;
            gBoxTiposMultas.Name = "gBoxTiposMultas";
            gBoxTiposMultas.TabStop = false;
            // 
            // txtCantAlcohol
            // 
            resources.ApplyResources(txtCantAlcohol, "txtCantAlcohol");
            txtCantAlcohol.BackColor = Color.FromArgb(34, 13, 69);
            txtCantAlcohol.Cursor = Cursors.IBeam;
            txtCantAlcohol.ForeColor = SystemColors.ControlLightLight;
            txtCantAlcohol.Name = "txtCantAlcohol";
            // 
            // checkBoxAlcohol
            // 
            resources.ApplyResources(checkBoxAlcohol, "checkBoxAlcohol");
            checkBoxAlcohol.Cursor = Cursors.Hand;
            checkBoxAlcohol.ForeColor = SystemColors.ControlLightLight;
            checkBoxAlcohol.Name = "checkBoxAlcohol";
            checkBoxAlcohol.UseVisualStyleBackColor = true;
            checkBoxAlcohol.CheckedChanged += checkBoxAlcohol_CheckedChanged;
            // 
            // checkBoxVelocidad
            // 
            resources.ApplyResources(checkBoxVelocidad, "checkBoxVelocidad");
            checkBoxVelocidad.Cursor = Cursors.Hand;
            checkBoxVelocidad.ForeColor = SystemColors.ControlLightLight;
            checkBoxVelocidad.Name = "checkBoxVelocidad";
            checkBoxVelocidad.UseVisualStyleBackColor = true;
            // 
            // checkBoxEstacionamiento
            // 
            resources.ApplyResources(checkBoxEstacionamiento, "checkBoxEstacionamiento");
            checkBoxEstacionamiento.Cursor = Cursors.Hand;
            checkBoxEstacionamiento.ForeColor = SystemColors.ControlLightLight;
            checkBoxEstacionamiento.Name = "checkBoxEstacionamiento";
            checkBoxEstacionamiento.UseVisualStyleBackColor = true;
            // 
            // gBoxDatosConductor
            // 
            resources.ApplyResources(gBoxDatosConductor, "gBoxDatosConductor");
            gBoxDatosConductor.Controls.Add(txtNombre);
            gBoxDatosConductor.Controls.Add(txtNumLicencia);
            gBoxDatosConductor.Controls.Add(radBtnMasculino);
            gBoxDatosConductor.Controls.Add(radBtnFemenino);
            gBoxDatosConductor.Controls.Add(labelSexo);
            gBoxDatosConductor.Controls.Add(labelNombre);
            gBoxDatosConductor.Controls.Add(labelNumLicencia);
            gBoxDatosConductor.ForeColor = SystemColors.ControlLightLight;
            gBoxDatosConductor.Name = "gBoxDatosConductor";
            gBoxDatosConductor.TabStop = false;
            // 
            // txtNombre
            // 
            resources.ApplyResources(txtNombre, "txtNombre");
            txtNombre.BackColor = Color.FromArgb(34, 13, 69);
            txtNombre.Cursor = Cursors.IBeam;
            txtNombre.ForeColor = SystemColors.ControlLightLight;
            txtNombre.Name = "txtNombre";
            // 
            // txtNumLicencia
            // 
            resources.ApplyResources(txtNumLicencia, "txtNumLicencia");
            txtNumLicencia.BackColor = Color.FromArgb(34, 13, 69);
            txtNumLicencia.Cursor = Cursors.IBeam;
            txtNumLicencia.ForeColor = SystemColors.ControlLightLight;
            txtNumLicencia.Name = "txtNumLicencia";
            // 
            // radBtnMasculino
            // 
            resources.ApplyResources(radBtnMasculino, "radBtnMasculino");
            radBtnMasculino.Cursor = Cursors.Hand;
            radBtnMasculino.Name = "radBtnMasculino";
            radBtnMasculino.TabStop = true;
            radBtnMasculino.UseVisualStyleBackColor = true;
            // 
            // radBtnFemenino
            // 
            resources.ApplyResources(radBtnFemenino, "radBtnFemenino");
            radBtnFemenino.Cursor = Cursors.Hand;
            radBtnFemenino.Name = "radBtnFemenino";
            radBtnFemenino.TabStop = true;
            radBtnFemenino.UseVisualStyleBackColor = true;
            // 
            // labelSexo
            // 
            resources.ApplyResources(labelSexo, "labelSexo");
            labelSexo.Cursor = Cursors.PanEast;
            labelSexo.Name = "labelSexo";
            // 
            // labelNombre
            // 
            resources.ApplyResources(labelNombre, "labelNombre");
            labelNombre.Cursor = Cursors.Hand;
            labelNombre.Name = "labelNombre";
            labelNombre.Click += labelNombre_Click;
            // 
            // labelNumLicencia
            // 
            resources.ApplyResources(labelNumLicencia, "labelNumLicencia");
            labelNumLicencia.Cursor = Cursors.Hand;
            labelNumLicencia.ForeColor = SystemColors.ControlLightLight;
            labelNumLicencia.Name = "labelNumLicencia";
            labelNumLicencia.Click += labelNumLicencia_Click;
            // 
            // btnNuevo
            // 
            resources.ApplyResources(btnNuevo, "btnNuevo");
            btnNuevo.BackColor = Color.FromArgb(34, 13, 69);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.ForeColor = SystemColors.ControlLightLight;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            resources.ApplyResources(btnAceptar, "btnAceptar");
            btnAceptar.BackColor = Color.FromArgb(34, 13, 69);
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.ForeColor = SystemColors.ControlLightLight;
            btnAceptar.Name = "btnAceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // btnFactura
            // 
            resources.ApplyResources(btnFactura, "btnFactura");
            btnFactura.BackColor = Color.FromArgb(34, 13, 69);
            btnFactura.Cursor = Cursors.Hand;
            btnFactura.ForeColor = SystemColors.ControlLightLight;
            btnFactura.Name = "btnFactura";
            btnFactura.UseVisualStyleBackColor = false;
            btnFactura.Click += btnFactura_Click;
            // 
            // btnSalir
            // 
            resources.ApplyResources(btnSalir, "btnSalir");
            btnSalir.BackColor = Color.FromArgb(98, 81, 127);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.ForeColor = SystemColors.ControlLightLight;
            btnSalir.Name = "btnSalir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // grillaDatos
            // 
            resources.ApplyResources(grillaDatos, "grillaDatos");
            grillaDatos.AllowUserToAddRows = false;
            grillaDatos.AllowUserToDeleteRows = false;
            grillaDatos.AllowUserToResizeColumns = false;
            grillaDatos.AllowUserToResizeRows = false;
            grillaDatos.BackgroundColor = Color.FromArgb(98, 81, 127);
            grillaDatos.BorderStyle = BorderStyle.None;
            grillaDatos.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            grillaDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillaDatos.Cursor = Cursors.No;
            grillaDatos.GridColor = SystemColors.GradientInactiveCaption;
            grillaDatos.Name = "grillaDatos";
            // 
            // ISistMultas
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 13, 69);
            Controls.Add(grillaDatos);
            Controls.Add(btnSalir);
            Controls.Add(btnFactura);
            Controls.Add(btnAceptar);
            Controls.Add(btnNuevo);
            Controls.Add(gBoxDatosConductor);
            Controls.Add(gBoxTiposMultas);
            Name = "ISistMultas";
            gBoxTiposMultas.ResumeLayout(false);
            gBoxTiposMultas.PerformLayout();
            gBoxDatosConductor.ResumeLayout(false);
            gBoxDatosConductor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grillaDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gBoxTiposMultas;
        private CheckBox checkBoxAlcohol;
        private CheckBox checkBoxVelocidad;
        private CheckBox checkBoxEstacionamiento;
        private TextBox txtCantAlcohol;
        private GroupBox gBoxDatosConductor;
        private Label labelNumLicencia;
        private TextBox txtNumLicencia;
        private RadioButton radBtnMasculino;
        private RadioButton radBtnFemenino;
        private Label labelSexo;
        private Label labelNombre;
        private TextBox txtNombre;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnFactura;
        private Button btnSalir;
        private DataGridView grillaDatos;
    }
}
