﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AerolineaFrba.Utils;
using AerolineaFrba.Dominio;
namespace AerolineaFrba.Compra
{
    public partial class ListadoButacas : Form
    {
        private Viaje viaje;
        public datosPasajeroForm anterior;
        public List<PasajeEncomienda> pasajes = new List<PasajeEncomienda>();

        public ListadoButacas()
        {
            InitializeComponent();
        }

        public ListadoButacas(Viaje viaje)
        {
            InitializeComponent();
            this.viaje = viaje;
            chkPasillo.Checked = true;
            chkVentanilla.Checked = true;
            txtPiso.Text = "1";
            
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (!validaciones()) return;

            string query = "select distinct numero_butaca,tipo_butaca, piso_butaca  from dbas.butacasLibresEnViaje (" + viaje.idViaje + ") WHERE 1=1";// "  WHERE matricula_aeronave = '" + viaje.matriculaAeronave1 + "'";
             
            if(txtPiso.Text!="") query=query + " AND piso_butaca = "+txtPiso.Text;

            string agregado = " AND tipo_butaca IN (";
            if (chkPasillo.Checked)
            {
                agregado = agregado+"'Pasillo',";
            }
            if (chkVentanilla.Checked)
            {
                agregado = agregado + "'Ventanilla',";
            }
            agregado = agregado + " 'lalala')";


            string agregado2 = " AND id_butaca NOT IN (";
            foreach(PasajeEncomienda pasen in pasajes){
                agregado2 = agregado2 + pasen.butacaKg + ",";
            }
            agregado2 = agregado2 + "-1)";

            query = query + agregado +agregado2 +" Order BY 1";

            CompletadorDeTablas.hacerQuery(query,ref dgvbutaca);
        }

        private bool validaciones()
        {

            int a;
            try
            {
                a = Convert.ToInt32(txtPiso.Text);

            }
            catch
            {
                MessageBox.Show("El numero de piso no posee un tipo de datos valido", "Error", MessageBoxButtons.OK);
                return false;
            }

            if (txtPiso.Text == "")
            {
                MessageBox.Show("El numero de piso no es valido", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            anterior.Show();
            this.Close();
        }

        private void dgvbutaca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvbutaca.CurrentCell.ColumnIndex == dgvbutaca.Columns.Count - 1) {
                completar(dgvbutaca);
            }
        }

        private void completar(DataGridView dataGridView2)
        {
          
            string numero_butaca = dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString();
            string tipo_butaca = dataGridView2[1, dataGridView2.CurrentCell.RowIndex].Value.ToString();
            string piso_butaca = dataGridView2[2, dataGridView2.CurrentCell.RowIndex].Value.ToString();

     //       string queryid = "select id_butaca  from dbas.butacas  WHERE  numero_butaca = " + numero_butaca + " AND tipo_butaca = '" + tipo_butaca + "' AND piso_butaca =" + piso_butaca;
            string queryid = "select distinct id_butaca from dbas.butacasLibresEnViaje (" + viaje.idViaje + ") WHERE numero_butaca = " + numero_butaca;// viaje.matriculaAeronave1 + "'";
            
            DataTable dt =(new ConexionSQL()).cargarTablaSQL(queryid);
            queryid = dt.Rows[0][0].ToString();
            Butaca seleccionada = new Butaca(queryid,numero_butaca,tipo_butaca,piso_butaca,viaje.matriculaAeronave1);
            anterior.cargarButaca(seleccionada);
            anterior.Show();
            this.Close();
        }

        private void ListadoButacas_Load(object sender, EventArgs e)
        {

        }

    }
}
