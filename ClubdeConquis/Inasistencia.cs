﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClubdeConquis
{
    public partial class Inasistencia : Form
    {
        public Inasistencia()
        {
            InitializeComponent();
        }
        private bool valida()
        {

            try
            {
                if (txtRut.Text == "")
                    return false;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (valida())
            {

                
                conexion cn = new conexion();
                try
                {

                    string sql = "INSERT INTO inasistencia(cantidad,fecha, integrante_idIntegrante)VALUES ('" + txtValor.Text + "','" + txtFecha.Text + "', '" + txtRut.Text + "')";

                    MySqlCommand cmd = new MySqlCommand(sql, cn.getconex());
                    int N = cmd.ExecuteNonQuery();

                    if (N > 0)
                    {
                        MessageBox.Show("El Ingreso de datos ha sido insertado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("El Ingreso de datos ha sido insertado como las weas");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Esta enviando dos veces los mismos datos");
                    throw;
                }
            }
            else
            {
                txtRut.Focus();
                txtRut.SelectAll();
                MessageBox.Show("faltan campos");
            }
        }
    }
}
