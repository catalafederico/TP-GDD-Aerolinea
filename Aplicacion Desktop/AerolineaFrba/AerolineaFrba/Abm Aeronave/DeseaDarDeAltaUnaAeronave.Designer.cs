﻿namespace AerolineaFrba.Abm_Aeronave
{
    partial class DeseaDarDeAltaUnaAeronave
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelarPasajes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "No existen aeronaves disponibles para reemplazar. ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonCancelarPasajes
            // 
            this.buttonCancelarPasajes.Location = new System.Drawing.Point(12, 82);
            this.buttonCancelarPasajes.Name = "buttonCancelarPasajes";
            this.buttonCancelarPasajes.Size = new System.Drawing.Size(75, 21);
            this.buttonCancelarPasajes.TabIndex = 42;
            this.buttonCancelarPasajes.Text = "Cancelar";
            this.buttonCancelarPasajes.UseVisualStyleBackColor = true;
            this.buttonCancelarPasajes.Click += new System.EventHandler(this.buttonCancelarPasajes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "¿Desea dar de alta una aeronave en este momento?";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 45;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeseaDarDeAltaUnaAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 140);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelarPasajes);
            this.Name = "DeseaDarDeAltaUnaAeronave";
            this.Text = "DeseaDarDeAltaUnaAeronave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelarPasajes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}