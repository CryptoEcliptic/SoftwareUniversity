namespace SIS.HTTP.Sessions
{
    using SIS.HTTP.Sessions.Contracts;
    using System;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private readonly IDictionary<string, object> parameters;

        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        public void AddParameter(string name, object parameter)
        {
            if (string.IsNullOrEmpty(name) || parameter == null)
            {
                throw new ArgumentNullException();
            }

            this.parameters[name] = parameter;
        }

        public void ClearParameters()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            if (!this.ContainsParameter(name))
            {
                return null;
            }
            else
            {
                return this.parameters[name];
            }
        }
    }
}
