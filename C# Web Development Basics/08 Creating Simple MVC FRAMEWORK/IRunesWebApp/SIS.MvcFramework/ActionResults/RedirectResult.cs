namespace SIS.MvcFramework.ActionResults
{
    using SIS.MvcFramework.ActionResults.Contracts;

    public class RedirectResult : IRedirectable
    {
        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }

        public string Invoke()
        {
            return this.RedirectUrl;
        }

        public string RedirectUrl { get; }
    }
}
