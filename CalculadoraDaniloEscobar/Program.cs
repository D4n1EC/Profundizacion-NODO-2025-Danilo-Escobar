using System;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Calculadora Avanzada por consola (.NET 9)");
            Console.WriteLine("=========================================");

            Console.Write("Introduce el primer numero:");
            if (!double.TryParse(Console.ReadLine(), out double numero1))
            {
                Console.WriteLine("Entrada invalida, Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            Console.Write("Introduce el segundo numero:");
            double numero2 = 0;
            string inputNumero2 = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(inputNumero2) && !double.TryParse(inputNumero2, out numero2))
            {
                Console.WriteLine("Entrada invalida, Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
            }


            Console.WriteLine("Selecciona una operacion:");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicacion");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Raiz Cuadrada de ambos numeros");
            Console.WriteLine("6. Elevar los numeros al cuadrado");
            Console.WriteLine("7. Elevar el numero 1 al numero 2");
            Console.WriteLine("8. Calcular Porcentaje del numero 2 en el numero 1");
            Console.WriteLine("9. Salir");
            Console.Write("Tu eleccion: ");

            string operacion = Console.ReadLine() ?? "";
            double resultado;

            switch (operacion)
            {
                case "1": // sumar
                    resultado = numero1 + numero2;
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "2": // resta
                    resultado = numero1 - numero2;
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "3": // multiplicacion
                    resultado = numero1 * numero2;
                    Console.WriteLine($"Resultado: {resultado}");
                    break;
                case "4": // division
                    if (numero2 == 0)
                    {
                        Console.WriteLine("Error: no se puede dividir por cero");
                    }
                    else
                    {
                        resultado = numero1 / numero2;
                        Console.WriteLine($"Resultado: {resultado}");
                    }
                    break;
                case "5": // Raíz cuadrada de ambos números
                    if (numero1 < 0 || numero2 < 0)
                    {
                        Console.WriteLine("Error: No se puede calcular la raíz de un número negativo.");
                    }
                    else
                    {
                        double raizNumero1 = Math.Sqrt(numero1);
                        double raizNumero2 = Math.Sqrt(numero2);

                        Console.WriteLine($"Raíz cuadrada de {numero1}: {raizNumero1}");
                        Console.WriteLine($"Raíz cuadrada de {numero2}: {raizNumero2}");
                    }
                    break;
                case "6": // Elevar ambos números al cuadrado
                    double cuadradoNumero1 = Math.Pow(numero1, 2);
                    double cuadradoNumero2 = Math.Pow(numero2, 2);

                    Console.WriteLine($"Resultado del número 1 ({numero1}): {cuadradoNumero1}");
                    Console.WriteLine($"Resultado del número 2 ({numero2}): {cuadradoNumero2}");
                    break;
                case "7": // Elevar el primer número a la potencia del segundo número
                    resultado = Math.Pow(numero1, numero2);
                    Console.WriteLine($"Resultado de elevar {numero1} a la potencia de {numero2}: {resultado}");
                    break;
                case "8": // Calcular porcentaje
                    resultado = (numero1 * numero2) / 100;
                    Console.WriteLine($"{numero2}% de {numero1} es: {resultado}");
                    break;

                case "9": // Salir
                    continuar = false;
                    Console.WriteLine("Gracias por usar la calculadora.");
                    break;
                default:
                    Console.WriteLine("Operacion no valida");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
    }
}