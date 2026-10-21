namespace TypeExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What word should be searched for: ");
            var searchWord = Console.ReadLine();

            Console.Write("What text should be searched in: ");
            string text = Console.ReadLine()!;

            int count = WordCount(searchWord, text);
            bool? countState = checkCount(count);
            if (countState == null)
            {
                Console.WriteLine("The searched word doesn't exist in the given text.");
            }
            else
            {
                Console.WriteLine($"The word ‘{searchWord}’ is found {count} times.");
                if ((bool)countState)
                {
                    Saver userSaver = new UserFolderSaver();

                    userSaver.Save(text);

                    Saver projectSaver = new ProjectFolderSaver();

                    projectSaver.Save(text);
                }
            }

            object stringResult = dynamicResult("Hello");
            object intResult = dynamicResult(66);
            object boolResult = dynamicResult(true);

            Console.WriteLine(stringResult);
            Console.WriteLine(intResult);
            Console.WriteLine(boolResult);
        }

        static int WordCount(string word, string text)
        {
            int count = 0;
            int index = 0;
            
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("ERROR! Word or Text is Empty! Returning 0 by default.");
                return 0;
            }

            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }
            return count;
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
    }
}
