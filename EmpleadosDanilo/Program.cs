using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Lista de empleados a tiempo completo
        List<EmpleadoTiempoCompleto> empleadosTiempoCompleto = new List<EmpleadoTiempoCompleto>
        {
            new EmpleadoTiempoCompleto("Carlos", 42000m),
            new EmpleadoTiempoCompleto("Ana", 42000m),
            new EmpleadoTiempoCompleto("Luis", 42000m)
        };

        // Lista de empleados por hora
        List<EmpleadoPorHora> empleadosPorHora = new List<EmpleadoPorHora>
        {
            new EmpleadoPorHora("Ximena", 15m, 160),
            new EmpleadoPorHora("Pedro", 20m, 150),
            new EmpleadoPorHora("Danilo", 18m, 120)
        };

        // Mostrar empleados a tiempo completo
        Console.WriteLine("Empleados a Tiempo Completo:");
        foreach (var empleado in empleadosTiempoCompleto)
        {
            Console.WriteLine(empleado);
        }

        // Mostrar empleados por hora
        Console.WriteLine("\nEmpleados por Hora:");
        foreach (var empleado in empleadosPorHora)
        {
            Console.WriteLine(empleado);
        }
    }
}
