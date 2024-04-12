using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            bool continueEditing = true;

            while (continueEditing)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Welcome to the Recipe App!");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");
                Console.WriteLine("===================================");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        recipe.EnterDetails();
                        break;
                    case "2":
                        recipe.Display();
                        break;
                    case "3":
                        recipe.Scale();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.ClearAllData();
                        break;
                    case "6":
                        continueEditing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }
    }

    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        public Recipe()
        {
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];
        }

        public void EnterDetails()
        {
            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());

            ingredients = new string[ingredientCount];
            quantities = new double[ingredientCount];
            units = new string[ingredientCount];

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Name: ");
                ingredients[i] = Console.ReadLine();
                Console.Write("Quantity: ");
                quantities[i] = double.Parse(Console.ReadLine());
                Console.Write("Unit of measurement: ");
                units[i] = Console.ReadLine();
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());

            steps = new string[stepCount];
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }

            Console.WriteLine("Recipe details entered successfully!");
        }

        public void Display()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"- {quantities[i]} {units[i]} of {ingredients[i]}");
            }
            Console.WriteLine("Steps:");
            foreach (var step in steps)
            {
                Console.WriteLine($"- {step}");
            }
        }

        public void Scale()
        {
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            double factor = double.Parse(Console.ReadLine());

            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] /= 2;
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearAllData()
        {
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];

            Console.WriteLine("All data cleared.");
        }
    }
}
