using CrediDomFinanciera.Abstraction;
using CrediDomFinanciera.Model;
using CrediDomFinanciera.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrediDomFinanciera
{
    public partial class MainPage : ContentPage
    {
        private float percentage;

        public float Percentage { get => percentage; set => percentage = value; }

        private string name;

        public string Name { get => name; set => name = value; }

        private string atraso;
        public string Atraso { get => atraso; set => atraso = value; }

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();            
        }

        protected async override void OnAppearing()
        {
            string MyPhoneNumber = DependencyService.Get<IDeviceInfo>().GetMyPhoneNumber().Replace("+1", "");
            PrestamoDetalle prestamoDetalle = await GetDetalle(MyPhoneNumber);

            Percentage = prestamoDetalle.cantidad_cuotas_pagadas > 0 ?
                prestamoDetalle.cantidad_cuotas_pagadas / prestamoDetalle.cantidad_cuotas : 0;

            txtName.Text = prestamoDetalle.nombre_cliente;
            txtCuotas
                .Text = $"! Ya has pagado {prestamoDetalle.cantidad_cuotas_pagadas} de {prestamoDetalle.cantidad_cuotas} cuotas";
            txtUsuario.Text = MyPhoneNumber;
            txtAtraso.Text = "RD$ " + prestamoDetalle.monto_atrasado_pago.ToString();
            base.OnAppearing();
        }

        public async Task<PrestamoDetalle> GetDetalle(string MyPhoneNumber)
        {
            return await ApiManager.GetPrestamoDetalle(MyPhoneNumber);
        }
    }
}
