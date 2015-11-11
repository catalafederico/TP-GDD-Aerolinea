﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AerolineaFrba.Dominio;
using AerolineaFrba.Utils;
namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultarMillasForm : Form
    {
        public ConsultarMillasForm()
        {
            InitializeComponent();
        }

        private void btMillas_Click(object sender, EventArgs e)
        {
            if(txtDni.Text==""){
                MessageBox.Show("Complete su dni");
                return;
            }

            if(!validarExtraDNI())return;



            string query = "select  top 1 dbas.millasVigentes ("+txtDni.Text+") from dbas.servicios";
            DataTable dt = (new ConexionSQL()).cargarTablaSQL(query);

            string millas = dt.Rows[0][0].ToString();
            if(millas=="")//millas="0";
            {MessageBox.Show("El dni: "+txtDni.Text+" no se encuentra en la base ");
            return;
            }

            MessageBox.Show("Usted tiene "+millas+" millas");
        }

        private bool validarExtraDNI()
        {
            Int32 a;

            try
            {
                a = Convert.ToInt32(txtDni.Text);

            }
            catch
            {
                MessageBox.Show("El DNI no posee un tipo de datos valido", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (a < 0)
            {
                MessageBox.Show("El DNI no esta en un rango valido", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (a < 1122696 || a > 99999999)//a partir de ahi comienzan los dni
            {
                MessageBox.Show("El DNI no se encuentra en la base", "Error", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            inicializar();
            this.Hide();
        }

        private void inicializar()
        {
            txtDni.Text = "";
            dgvmillas.DataSource = null;
        }

        private void btPuntos_Click(object sender, EventArgs e)
        {
            if (txtDni.Text == "")
            {
                MessageBox.Show("Complete su dni");
                return;
            }

            if (!validarExtraDNI()) return;

            CompletadorDeTablas.hacerQuery("select * from dbas.historialMillas ("+txtDni.Text+")", ref dgvmillas);

            if(dgvmillas.Columns.Count != 0)dgvmillas.Columns.Remove("seleccionar");
        }

        private void ConsultarMillasForm_Load(object sender, EventArgs e)
        {

        }
    }
}
