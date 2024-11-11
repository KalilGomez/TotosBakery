﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Pedido
    {
        private int id;
        private string estado;
        private string met_pago;
        private DateTime fecha;
        private string direccion;
        private int clienteid;

        public int Id { get => id; set => id = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Met_pago { get => met_pago; set => met_pago = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Clienteid { get => clienteid; set => clienteid = value; }

        public Pedido(int id, string estado, string met_pago, DateTime fecha, string direccion, int clienteid)
        {
            this.id = id;
            this.estado = estado;
            this.met_pago = met_pago;
            this.fecha = fecha;
            this.direccion = direccion;
            this.Clienteid = clienteid;
        }
        public Pedido() { }
    }
}
