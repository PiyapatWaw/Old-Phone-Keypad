using PhoneKeypad.Script;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PhonePad phonePad = new OldPhonePad();
        Console.WriteLine("PhonePad input loop start");

        while (true)
        {
            Console.Write("Enter input: ");
            string input = Console.ReadLine();

            if (input != null)
            {
                string result = phonePad.ParseInput(input+"#");
                Console.WriteLine("Output: " + result);
            }
        }
    }
}