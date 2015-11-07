﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using AerolineaFrba.Dominio;
namespace AerolineaFrba.Compra
{
    public static class Compra
    {
        public static PasajeEncomienda persona;
        public static  compraForm compra;
        public static bool pagaEnEfectivo = false;
        public static PasajeEncomienda comprador { get; set; }
        public static Tarjeta tarjeta;

        public static void inicializar(){
            pagaEnEfectivo = false;
            tarjeta = new Tarjeta("0", "", new DateTime(), "id_tipo", "cuotas_elegidas", "0");
        }
        internal static void realizarCompra()
        {
            //TO-DO 

            string qGenerarCompra =  "execute  DBAS.generarCompra "+comprador.id+","+ tarjeta.numeroTarjeta+" , "+tarjeta.codigo+","+tarjeta.dateTime+","+ tarjeta.tipoTarjetaId+","+tarjeta.cuotasElegidas+" ,"+ tarjeta.tipo;

            //obtengo el ultimo
            DataTable dt = (new ConexionSQL()).cargarTablaSQL("select top 1 (id_compra +1)AS codigo FROM DBAS.compras ORDER BY 1 DESC");
            DataRow row = dt.Rows[0];
            string idCompra = row[0].ToString();
         
            PasajeEncomienda encomienda=  compra.encomiendas;
            string queryEncomienda = "Insert into DBAS.encomiendas (id_cliente,encomienda_cliente_KG,id_viaje,precio_encomienda,id_compra_PNR) values (" +
            encomienda.id + ", " + encomienda.butacaKg + ", " + compra.viaje.idViaje + " , " + compra.viaje.precioKg + " , " + idCompra;

      /*      foreach(PasajeEncomienda pasajero in compra.pasajes){
                string queryPasaje = "Insert into DBAS.encomiendas (id_cliente,encomienda_cliente_KG,id_viaje,precio_encomienda,id_compra_PNR) values (" +
            encomienda.id + ", " + encomienda.butacaKg + ", " + compra.viaje.idViaje + " , " + compra.viaje.precioKg + " , " + idCompra;
            }*/
        }


    }
}