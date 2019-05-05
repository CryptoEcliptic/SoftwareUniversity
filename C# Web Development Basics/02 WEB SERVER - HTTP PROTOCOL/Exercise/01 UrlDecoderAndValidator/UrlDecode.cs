namespace HttpProtocolExercise
{
    using System.Net;

    public class UrlDecode
    {
        public string Decode(string input)
        {
            string decoded = WebUtility.UrlDecode(input);

            return decoded;
        }
    }
}
