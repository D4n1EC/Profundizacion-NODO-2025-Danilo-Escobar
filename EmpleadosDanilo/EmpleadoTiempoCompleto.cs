public class EmpleadoTiempoCompleto : Empleado
{
    public decimal SalarioAnual { get; set; }

    public EmpleadoTiempoCompleto(string nombre, decimal salarioAnual)
        : base(nombre)
    {
        SalarioAnual = salarioAnual;
    }

    public override decimal CalcularSalario()
    {
        return SalarioAnual / 12; // Salario mensual
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Salario Mensual: {CalcularSalario()}";
    }
}

