namespace CrediDomFinanciera.Model
{
    public class PrestamoDetalle
    {
        public int cantidad_cuotas { get; set; }
        public int cantidad_cuotas_pagadas { get; set; }
        public float monto_atrasado_pago { get; set; }
        public string estatus { get; set; }
        public string nombre_cliente { get; set; }
        public float numprestamo { get; set; }
        public float monto_proxima_cuota_pagar { get; set; }
    }
}
