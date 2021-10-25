using System;

namespace Introduction._3Savarankiskas
{
		class Program
		{
				static void Main(string[] args)
				{
					Console.WriteLine("Pasirinkite operaciją: + - * /");
					char operation = (char)Console.Read();
					Console.WriteLine("{0}", operation);
					if (operation != '+' && operation != '-' && operation != '*' && operation != '/') {
						Console.WriteLine("Klaidinga operacija");
						return;
					}

					// Use up newline symbol
					Console.ReadLine();
					Console.WriteLine("Įveskite kairės skaičių kuris bus kairėje pusėje: ");
					double lhs = double.Parse(Console.ReadLine());
					Console.WriteLine("Įveskite kairės dešinėje kuris bus kairėje pusėje: ");
					double rhs = double.Parse(Console.ReadLine());

					double result = 0;
					switch (operation) {
						case '+':
							result = lhs + rhs;
							break;
						case '-':
							result = lhs - rhs;
							break;
						case '*':
							result = lhs * rhs;
							break;
						case '/':
                            if (rhs == 0)
                            {
                                Console.WriteLine("negalima!");
                                return;
                            }
							result = lhs / rhs;
							break;
					}

					Console.WriteLine("Pilnas veiksmas: {0} {1} {2} = {3}", lhs, operation, rhs, result);
				}
		}
}
