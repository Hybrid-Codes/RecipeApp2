using System;
using System.Collections.Generic;


namespace POEPart2
{
    // Represents a recipe
    public class Recipe
    {
        // Properties of a recipe
        public string Name { get; set; }
        public int NumIngredients { get; set; }
        public int NumSteps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        // Constructor initializes empty ingredient and step lists
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }
    }

    // Represents an ingredient
    public class Ingredient
    {
        // Properties of an ingredient
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    public class Program
    {
        // List to store recipes
        static List<Recipe> recipes = new List<Recipe>();

        // Delegate for notifying the user
        delegate void NotifyUserDelegate(string message);

        static void Main()
        {
            // Set console color to cyan
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Print welcome message to the console
            Console.WriteLine("Welcome to RecipeApp!");

            // Reset console color
            Console.ResetColor();

            bool exit = false;

            while (!exit)
            {
                // Set console color to white
                Console.ForegroundColor = ConsoleColor.White;

                // Print menu options
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset quantities");
                Console.WriteLine("6. Clear all data");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice:");

                // Reset console color
                Console.ResetColor();

                // Read user's choice
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        DisplayAllRecipes();
                        break;
                    case "3":
                        SelectRecipe();
                        break;
                    case "4":
                        ScaleRecipe();
                        break;
                    case "5":
                        ResetQuantities();
                        break;
                    case "6":
                        ClearAllData();
                        break;
                    case "7":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for using RecipeApp!");
                        Console.ResetColor();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Method to add a recipe
        public static void AddRecipe()
        {
            // Create a new recipe object
            Recipe recipe = new Recipe();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the recipe name:");
            Console.ResetColor();

            // Read the recipe name from the user
            recipe.Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the number of ingredients:");
            Console.ResetColor();

            // Read the number of ingredients from the user
            recipe.NumIngredients = int.Parse(Console.ReadLine());

            // Loop to read ingredient details
            for (int i = 0; i < recipe.NumIngredients; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Enter the details for ingredient #{i + 1}:");
                Console.WriteLine("Name:");
                Console.ResetColor();

                // Read ingredient name from the user
                string ingredientName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Quantity:");
                Console.ResetColor();

                // Read ingredient quantity from the user
                float quantity = float.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Unit of measurement:");
                Console.ResetColor();

                // Read ingredient unit of measurement from the user
                string unit = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Calories:");
                Console.ResetColor();

                // Read ingredient calories from the user
                int calories = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Food Group:");
                Console.ResetColor();

                // Read ingredient food group from the user
                string foodGroup = Console.ReadLine();

                // Create a new ingredient object and add it to the recipe's ingredient list
                recipe.Ingredients.Add(new Ingredient
                {
                    Name = ingredientName,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                });
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the number of steps:");
            Console.ResetColor();

            // Read the number of steps from the user
            recipe.NumSteps = int.Parse(Console.ReadLine());

            // Loop to read recipe steps
            for (int i = 0; i < recipe.NumSteps; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Enter step #{i + 1}:");
                Console.ResetColor();

                // Read step details from the user
                string step = Console.ReadLine();

                // Add the step to the recipe's step list
                recipe.Steps.Add(step);
            }

            // Add the recipe to the list of recipes
            recipes.Add(recipe);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipe added successfully!");
            Console.ResetColor();
        }

        // Method to display all recipes
        public static void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("All Recipes:");
            Console.ResetColor();

            // Loop to display each recipe's name
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to select and display a recipe
        public static void SelectRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the recipe number:");
            Console.ResetColor();

            // Read the recipe number from the user
            int recipeIndex = int.Parse(Console.ReadLine()) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                // Get the selected recipe from the list
                Recipe selectedRecipe = recipes[recipeIndex];

                // Display the selected recipe's details
                DisplayRecipe(selectedRecipe);

                // Calculate and display the total calories of the selected recipe
                CalculateTotalCalories(selectedRecipe);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid recipe number!");
                Console.ResetColor();
            }
        }

        // Method to display a recipe's details
        public static void DisplayRecipe(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipe Details:");
            Console.WriteLine($"Name: {recipe.Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.NumSteps; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }

            Console.ResetColor();
        }

        // Method to calculate and display the total calories of a recipe
        public static void CalculateTotalCalories(Recipe recipe)
        {
            int totalCalories = 0;

            // Calculate the total calories by summing the calories of each ingredient
            foreach (var ingredient in recipe.Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total Calories: {totalCalories}");
            Console.ResetColor();

            // Check if the total calories exceed 300 and display a warning message if necessary
            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                NotifyUser("Warning: This recipe exceeds 300 calories.");
                Console.ResetColor();
            }
        }

        // Method to scale a recipe's ingredient quantities
        public static void ScaleRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the recipe number to scale:");
            Console.ResetColor();

            // Read the recipe number from the user
            int recipeIndex = int.Parse(Console.ReadLine()) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                // Get the selected recipe from the list
                Recipe selectedRecipe = recipes[recipeIndex];

                // Display the selected recipe's details
                DisplayRecipe(selectedRecipe);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Enter the scale factor (0.5, 2, or 3):");
                Console.ResetColor();

                // Read the scale factor from the user
                float scaleFactor = float.Parse(Console.ReadLine());

                // Scale each ingredient's quantity by the scale factor
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    ingredient.Quantity *= scaleFactor;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Recipe scaled successfully!");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Scaled Recipe:");
                DisplayRecipe(selectedRecipe);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid recipe number!");
                Console.ResetColor();
            }
        }

        // Method to reset a recipe's ingredient quantities to 1
        public static void ResetQuantities()
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes found!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the recipe number to reset quantities:");
            Console.ResetColor();

            // Read the recipe number from the user
            int recipeIndex = int.Parse(Console.ReadLine()) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipes.Count)
            {
                // Get the selected recipe from the list
                Recipe selectedRecipe = recipes[recipeIndex];

                // Reset each ingredient's quantity to 1
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    ingredient.Quantity = 1;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quantities reset successfully!");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Reset Recipe:");
                DisplayRecipe(selectedRecipe);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid recipe number!");
                Console.ResetColor();
            }
        }

        // Method to clear all recipe data
        public static void ClearAllData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Are you sure you want to clear all data? (Y/N):");
            Console.ResetColor();

            // Read the user's confirmation
            string confirmation = Console.ReadLine();

            if (confirmation.ToLower() == "y")
            {
                // Clear the list of recipes
                recipes.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All data cleared successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Clearing data cancelled.");
                Console.ResetColor();
            }
        }

        // Method to notify the user
        public static void NotifyUser(string message)
        {
            // Display the notification message to the user
            Console.WriteLine(message);
        }
    }
}