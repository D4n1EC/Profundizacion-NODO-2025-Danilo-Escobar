public class EmpleadoPorHora : Empleado
{
    public decimal TarifaPorHora { get; set; }
    public int HorasTrabajadas { get; set; }

    public EmpleadoPorHora(string nombre, decimal tarifaPorHora, int horasTrabajadas)
        : base(nombre)
    {
        TarifaPorHora = tarifaPorHora;
        HorasTrabajadas = horasTrabajadas;
    }

    public override decimal CalcularSalario()
    {
        return TarifaPorHora * HorasTrabajadas;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Salario Calculado: {CalcularSalario()}";
    }
}

