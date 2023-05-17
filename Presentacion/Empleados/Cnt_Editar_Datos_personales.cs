﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Soporte.Cache;
using Soporte.Utilidades;

namespace Presentacion
{
    public partial class Cnt_Editar_Datos_personales : UserControl
    {
        private string Mode = "Mi Perfil";
        public Cnt_Editar_Datos_personales()
        {
            InitializeComponent();
        }

        public Cnt_Editar_Datos_personales(string mode)
        {
            this.Mode = mode;
            var empleados = new EmpleadosModel();
            var result = empleados.BuscarPacienteId(Cache_Empleado.IdEmpleado);
            if (result)
            {

            }

            InitializeComponent();
        }


        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (this.Mode == "Mi Perfil")
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Editar_Perfil_Main);

                if (frm != null)
                {
                    //si la instancia existe la cierro
                    frm.Close();
                    return;
                }
            }
            else
            {
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Nuevo_Empleado_Main);

                if (frm != null)
                {
                    //si la instancia existe la cierro
                    frm.Close();
                    return;
                }
            }
         

        }

        private void Cnt_Editar_Datos_personales_Load(object sender, EventArgs e)
        {
            if (this.Mode == "Mi Perfil")
            {
                txtApellido.Text = Cache_Usuario.ApellidoEmpleado;
                txtNombre.Text = Cache_Usuario.NombreEmpleado;
                txtDni.Text = Cache_Usuario.DniEmpleado;
                txtTelefono.Text = Cache_Usuario.TelefonoEmpleado;
                cmbGenero.SelectedText = Cache_Usuario.GeneroEmpleado;
                DtpFechaNac.Value = Cache_Usuario.FechaNacimientoEmpleado;
                TxtDireccion.Text = Cache_Usuario.DireccionEmpleado;
            }
            else if (this.Mode == "Nuevo")
            {
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtDni.Text = "";
                txtTelefono.Text = "";
                cmbGenero.SelectedText = "";
                txtDni.Enabled = true;
                TxtDireccion.Text = "";
            }
            else
            {
                txtApellido.Text = Cache_Empleado.ApellidoEmpleado;
                txtNombre.Text = Cache_Empleado.NombreEmpleado;
                txtDni.Text = Cache_Empleado.DniEmpleado;
                txtDni.Enabled = true;
                txtTelefono.Text = Cache_Empleado.TelefonoEmpleado;
                cmbGenero.SelectedText = Cache_Empleado.GeneroEmpleado;
                DtpFechaNac.Value = Cache_Empleado.FechaNacimientoEmpleado;
                TxtDireccion.Text = Cache_Empleado.DireccionEmpleado;
            }

          

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (this.Mode == "Mi Perfil")
            {
                Utilidades utilidades = new Utilidades();
                if (utilidades.CampoVacio(txtNombre.Text) || utilidades.CampoVacio(txtApellido.Text) ||
                    utilidades.CampoVacio(txtTelefono.Text) || utilidades.CampoVacio(TxtDireccion.Text) ||
                    utilidades.CampoVacio(DtpFechaNac.Text) || utilidades.CampoVacio(cmbGenero.Text))
                {
                    utilidades.AlertMessage("Todos los campos son obligatorios","A");
                }
                else
                {
                    if (Cache_Usuario.Cargo == "Medico")
                    {
                        UserModel user = new UserModel();
                        var result = user.EditarDatosMedico(txtNombre.Text, txtApellido.Text, DtpFechaNac.Value,
                            TxtDireccion.Text, txtTelefono.Text, cmbGenero.Text, Cache_Usuario.IdEmpleado);
                        utilidades.AlertMessage(result, "I");
                        var res = user.LoginUser(Cache_Usuario.DniEmpleado, Cache_Usuario.ContraseniaUsuario);
                        if (res)
                        {
                            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Editar_Perfil_Main);
                            if (frm != null)
                            {
                                //si la instancia existe la cierro
                                frm.Close();
                                return;
                            }
                        }
                    }
                    else
                    {
                        UserModel user = new UserModel();
                        var result = user.EditarDatosEmpleado(txtNombre.Text, txtApellido.Text, DtpFechaNac.Value,
                            TxtDireccion.Text, txtTelefono.Text, cmbGenero.Text, Cache_Usuario.IdEmpleado);
                        utilidades.AlertMessage(result, "I");
                        var res = user.LoginUser(Cache_Usuario.DniEmpleado, Cache_Usuario.ContraseniaUsuario);
                        if (res)
                        {
                            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Editar_Perfil_Main);
                            if (frm != null)
                            {
                                //si la instancia existe la cierro
                                frm.Close();
                                return;
                            }
                        }
                    }
                }
                
            }
            else if (this.Mode == "Nuevo")
            {
                Utilidades utilidades = new Utilidades();
                if (utilidades.CampoVacio(txtNombre.Text) || utilidades.CampoVacio(txtApellido.Text) ||
                    utilidades.CampoVacio(txtTelefono.Text) || utilidades.CampoVacio(TxtDireccion.Text) ||
                    utilidades.CampoVacio(DtpFechaNac.Text) || utilidades.CampoVacio(cmbGenero.Text))
                {
                    utilidades.AlertMessage("Todos los campos son obligatorios", "A");
                }
                else
                {
                    EmpleadosModel emp = new EmpleadosModel();
                   var resultado =  emp.NuevoEmpleado(txtNombre.Text, txtApellido.Text, txtDni.Text, cmbGenero.Text,DtpFechaNac.Value,
                        TxtDireccion.Text, txtTelefono.Text);
                    utilidades.AlertMessage(resultado,"I");
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Nuevo_Empleado_Main);
                    if (frm != null)
                    {
                        //si la instancia existe la cierro
                        frm.Close();
                        return;
                    }
                }
            }
            else
            {
                Utilidades utilidades = new Utilidades();
                if (utilidades.CampoVacio(txtNombre.Text) || utilidades.CampoVacio(txtApellido.Text) ||
                    utilidades.CampoVacio(txtTelefono.Text) || utilidades.CampoVacio(TxtDireccion.Text) ||
                    utilidades.CampoVacio(DtpFechaNac.Text) || utilidades.CampoVacio(cmbGenero.Text))
                {
                    utilidades.AlertMessage("Todos los campos son obligatorios", "A");
                }
                else
                {
                    EmpleadosModel emp = new EmpleadosModel();
                    var resultado = emp.EditarEmpleado(txtNombre.Text, txtApellido.Text, txtDni.Text, cmbGenero.Text, DtpFechaNac.Value,
                        TxtDireccion.Text, txtTelefono.Text,Cache_Empleado.EstadoEmpleado,Cache_Empleado.IdEmpleado);
                    utilidades.AlertMessage(resultado, "I");
                    Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is Frm_Nuevo_Empleado_Main);
                    if (frm != null)
                    {
                        //si la instancia existe la cierro
                        frm.Close();
                        return;
                    }
                }
            }
        }
    }
}
