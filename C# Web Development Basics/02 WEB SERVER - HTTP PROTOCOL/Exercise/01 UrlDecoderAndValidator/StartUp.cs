namespace HttpProtocolExercise
{
    using System;
    using System.Net;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            UrlValidator validator = new UrlValidator();
            string input = Console.ReadLine();

            //string result = decode.Decode(input);
            string result = validator.ValidateUrl(input);

            Console.WriteLine(result);
        }
    }
}
