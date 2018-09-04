using System;

namespace Tiny.Http
{
    public class TinySettings
    {
        internal TinySettings()
        {
            DefaultTimeout = TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Get or set the default timeout of each request
        /// </summary>
        public TimeSpan DefaultTimeout { get; set; }

        /// <summary>
        /// Add to all request the AcceptLanguage based on CurrentCulture of the Thread
        /// </summary>
        public bool AddAcceptLanguageBasedOnCurrentCulture { get; set; }
    }
}