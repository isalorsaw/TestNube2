using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNube2.Classes;
using Xamarin.Forms;

namespace TestNube2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if(verifBD())
            {
                llenarUsers();
            }
            else
            {
                cerrar();
            }
        }
        public async void cerrar()
        {
            await DisplayAlert("Mensaje", "Problemas de Conectividad. La aplicacion se va a cerrar", "OK");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        private bool verifBD()
        {
            try
            { 
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                byte[] response = cliente.UploadValues(App.url + "conexion2.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);
                //DisplayAlert("Mensaje", c, "OK");
                if (c.Equals("1")) return true;
                else return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        private async void llenarUsers()
        {
            try
            {
                UserManager manager = new UserManager();
                var res = await manager.getUsuarios();
                if (res != null)
                {
                    lstUser.ItemsSource = res;
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Mensaje de Error", e.Message.ToString(), "OK");
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuser.Text))
            {

            }
            else if (string.IsNullOrEmpty(txtpass.Text))
            {

            }
            else
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("nombre", txtuser.Text);
                parametros.Add("clave", txtpass.Text);

                byte[] response = cliente.UploadValues(App.url+"insertUser.php", "POST", parametros);
                string c = Encoding.ASCII.GetString(response);
                if (c.Equals("1"))
                {
                    DisplayAlert("Informacion", "Usuario Guardado Satisfactoriamente", "OK");
                    txtuser.Text = "";
                    txtpass.Text = "";
                    llenarUsers();
                }
                else
                {
                    DisplayAlert("Informacion", "Error al Guardar Usuario", "OK");
                }
            }

        }
    }
}
