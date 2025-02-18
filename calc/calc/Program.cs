namespace calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение");
                Console.WriteLine("2. Вычитание");
                Console.WriteLine("3. Умножение");
                Console.WriteLine("4. Деление");
                Console.WriteLine("5. Возведение в степень");
                Console.WriteLine("6. Извлечение корня");
                Console.WriteLine("7. Процент от числа");
                Console.WriteLine("8. Логарифм");
                Console.WriteLine("9. Синус");
                Console.WriteLine("10. Котангенс");
                Console.WriteLine("0. Выход");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }

                List<double> numbers = new List<double>();
                Console.WriteLine("Введите числа через пробел:");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                foreach (string part in parts)
                {
                    double number;
                    if (double.TryParse(part, out number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод числа.");
                        continue;
                    }
                }

                if (numbers.Count == 0)
                {
                    Console.WriteLine("Не введены числа.");
                    continue;
                }

                double result = 0;
                switch (choice)
                {
                    case "1":
                        result = Add(numbers);
                        break;
                    case "2":
                        result = Subtract(numbers);
                        break;
                    case "3":
                        result = Multiply(numbers);
                        break;
                    case "4":
                        result = Divide(numbers);
                        break;
                    case "5":
                        result = Power(numbers);
                        break;
                    case "6":
                        result = Root(numbers);
                        break;
                    case "7":
                        result = Percent(numbers);
                        break;
                    case "8":
                        result = Log(numbers);
                        break;
                    case "9":
                        result = Sin(numbers);
                        break;
                    case "10":
                        result = Ctg(numbers);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        continue;
                }

                Console.WriteLine($"Результат: {result}");
            }
        }

        // Баги: случайное округление результата
        static double Add(List<double> numbers)
        {
            double result = 0;
            foreach (double number in numbers)
            {
                result += number;
            }
            return Math.Round(result, 2);
        }

        // Баги: случайное округление результата
        static double Subtract(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result -= numbers[i];
            }
            return Math.Round(result, 2);
        }

        // Баги: случайное округление результата
        static double Multiply(List<double> numbers)
        {
            double result = 1;
            foreach (double number in numbers)
            {
                result *= number;
            }
            return Math.Round(result, 2);
        }

        // Баги: деление на ноль
        static double Divide(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == 0)
                {
                    return double.NaN;
                }
                result /= numbers[i];
            }
            return Math.Round(result, 2);
        }

        // Баги: случайное округление результата
        static double Power(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = Math.Pow(result, numbers[i]);
            }
            return Math.Round(result, 2);
        }

        // Баги: извлечение корня из отрицательного числа
        static double Root(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    return double.NaN;
                }
                result = Math.Sqrt(result);
            }
            return Math.Round(result, 2);
        }

        // Баги: некорректное вычисление процента
        static double Percent(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = result * numbers[i] / 100;
            }
            return Math.Round(result, 2);
        }

        // Баги: логарифм отрицательного числа
        static double Log(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] <= 0)
                {
                    return double.NaN;
                }
                result = Math.Log(result, numbers[i]);
            }
            return Math.Round(result, 2);
        }

        // Баги: некорректное вычисление синуса
        static double Sin(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = Math.Sin(result);
            }
            return Math.Round(result, 2);
        }

        // Баги: котангенс нуля
        static double Ctg(List<double> numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == 0)
                {
                    return double.NaN;
                }
                result = 1 / Math.Tan(result);
            }
            return Math.Round(result, 2);
        }
    }
}
