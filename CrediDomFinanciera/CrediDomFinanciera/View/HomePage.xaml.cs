using CrediDomFinanciera.Abstraction;
using CrediDomFinanciera.Model;
using CrediDomFinanciera.Services;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrediDomFinanciera.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private float percentage;

        public float Percentage { get => percentage; set => percentage = value; }

        private string name;

        public string Name { get => name; set => name = value; }

        private string atraso;
        public string Atraso { get => atraso; set => atraso = value; }
        public HomePage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            //string MyPhoneNumber = DependencyService.Get<IDeviceInfo>().GetMyPhoneNumber().Replace("+1", "");

            PrestamoDetalle prestamoDetalle = await GetDetalle();

            Percentage = prestamoDetalle.cantidad_cuotas_pagadas > 0 ?
                prestamoDetalle.cantidad_cuotas_pagadas / prestamoDetalle.cantidad_cuotas : 0;

            txtName.Text = prestamoDetalle.nombre_cliente.Length > 14 ? prestamoDetalle.nombre_cliente.Substring(0, 14) : prestamoDetalle.nombre_cliente;
            txtCuotas
                .Text = $"! Ya has pagado {prestamoDetalle.cantidad_cuotas_pagadas} de {prestamoDetalle.cantidad_cuotas} cuotas";
            txtUsuario.Text = Argument._MyPhoneNumber;
            txtAtraso.Text = "RD$ " + prestamoDetalle.monto_atrasado_pago.ToString();
            txtproxima.Text = $"SU PROXIMA CUOTA A PAGAR ${prestamoDetalle.monto_proxima_cuota_pagar.ToString("N2")}";
            base.OnAppearing();
        }

        public async Task<PrestamoDetalle> GetDetalle()
        {
            return await ApiManager.GetPrestamoDetalle(Argument._MyPhoneNumber);
        }
    }
}