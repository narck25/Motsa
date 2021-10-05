using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Motsa1
{
    public partial class Login : Form
    {
        public static string rol;
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=192.168.9.133;Initial Catalog=motsa;Persist Security Info=True;User ID=motsa;Password=motsa1");

        #region messageboxauto
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption);
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
        #endregion

        #region login
        public void loguear(string usuario, string contrasena)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select admin  from Users  WHERE usuario='" + txtuser.Text + "' AND password='" + txtpass.Text + "'", con);
                DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    switch (dt.Rows[0]["admin"] as string)
                    {
                        case "1":
                            {
                                AutoClosingMessageBox.Show("Acceso Correcto", "Exito", 1000);
                                rol = "admon";
                                this.Hide();
                                Menu1 mf = new Menu1();
                                mf.Show();
                                break;
                            }

                        case "0":
                            {
                                AutoClosingMessageBox.Show("Acceso Correcto", "Exito", 1000);
                                rol = "normal";
                                this.Hide();
                                //PostLogin ss = new PostLogin();
                                //ss.Show();
                                break;
                            }
                        case "2":
                            {
                                AutoClosingMessageBox.Show("Acceso Correcto", "Exito", 1000);
                                rol = "user";
                                this.Hide();
                                //User us = new User();
                                //us.Show();
                                break;
                            }
                        default:
                            {
                                break;
                            }

                    }

                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrectos");
                    con.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Por favor verifica tu Conexión a INTERNET");
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            loguear(this.txtuser.Text, this.txtpass.Text);
        }

        private void Txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                loguear(this.txtuser.Text, this.txtpass.Text);

            }
        }
    }
}
