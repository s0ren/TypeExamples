namespace TypeExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What word should be searched for: ");
            var searchWord = Console.ReadLine()!;

            Console.Write("What text should be searched in: ");
            string text = Console.ReadLine()!;

            Result<int> count = WordCount(searchWord, text);
            if (count.Success) {
                
                bool? countState = checkCount(count.value);
                if (countState == null)
                {
                    Console.WriteLine("The searched word doesn't exist in the given text.");
                }
                else
                {
                    Console.WriteLine($"The word ‘{searchWord}’ is found {count.value} times.");
                    if ((bool)countState)
                    {

                        Console.Write("Should the search be logged to the User file or the project file?: ");
                        string saveChoice = Console.ReadLine()!.ToLower();

                        while (string.IsNullOrWhiteSpace(saveChoice) || (saveChoice != "user" && saveChoice != "project"))
                        {
                            Console.WriteLine("Error! Nothing typed! Try again: ");
                            saveChoice = Console.ReadLine()!.ToLower();
                        }

                        if (saveChoice == "user")
                        {
                            Saver userSaver = new UserFolderSaver();

                            userSaver.Save(text);
                        }
                        else
                        {
                            Saver projectSaver = new ProjectFolderSaver();

                            projectSaver.Save(text);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(count.errorMessage);
            }

            object stringResult = dynamicResult("Hello");
            object intResult = dynamicResult(66);
            object boolResult = dynamicResult(true);

            Console.WriteLine(stringResult);
            Console.WriteLine(intResult);
            Console.WriteLine(boolResult);
        }

        static Result<int> WordCount(string word, string text)
        {
            int count = 0;
            int index = 0;
            
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(text))
            {
                return new Result<int>
                {
                    Success = false,
                    errorMessage = "ERROR! word or text is empty!"
                };
            }

            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }
            return new Result<int>
            {
                Success = true,
                value = count
            };
        }
        static bool? checkCount(int count)
        {
            if (count == 0)
            {
                return null;
            }
            else if (count < 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static object dynamicResult(object input)
        {
            if (input is string text)
            {
                return "Text recieved as: " + text;
            }
            else if (input is int number)
            {
                return 100 + number;
            }
            else
            {
                return false;
            }
        }

        public class Result<T>
        {
            public bool Success { get; set; } = false;
            public T ?value { get; set; }
            public string errorMessage { get; set; } = "";
        }
    }
}
