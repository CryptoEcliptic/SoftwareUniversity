namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Cookies.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> Cookies;

        public HttpCookieCollection()
        {
            this.Cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException();
            }

            if (!Cookies.ContainsKey(cookie.Key)) //TODO Check if that validation is necessary
            {
                this.Cookies.Add(cookie.Key, cookie);
            }
        }

        public bool ContainsCookie(string key)
        {
            return this.Cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            if (!this.ContainsCookie(key))
            {
                return null;
            }

            var returnCookie = this.Cookies[key];
            return returnCookie;
        }

        public bool HasCookies()
        {
            return this.Cookies.Any();
        }

        public override string ToString() //TODO check if Enumerators should be implemented
        {
            return string.Join("; ", this.Cookies.Values);
        }
    }
}
