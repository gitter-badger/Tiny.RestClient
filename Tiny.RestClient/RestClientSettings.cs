﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tiny.RestClient
{
    /// <summary>
    /// All settings of <see cref="TinyRestClient"/>
    /// </summary>
    public class RestClientSettings
    {
        private Encoding _encoding;

        internal RestClientSettings()
        {
            DefaultHeaders = new Dictionary<string, string>();
            Listeners = new Listeners();
            Formatters = new Formatters();
            _encoding = Encoding.UTF8;
        }

        /// <summary>
        /// Gets or set the encoding use by the client
        /// </summary>
        public Encoding Encoding
        {
            get
            {
                return _encoding;
            }
            set
            {
                _encoding = value ?? throw new ArgumentNullException(nameof(Encoding));
            }
        }

        /// <summary>
        /// Gets the default headers.
        /// </summary>
        /// <value>
        /// The default headers.
        /// </value>
        public Dictionary<string, string> DefaultHeaders
        {
            get; private set;
        }

        /// <summary>
        /// Log all requests.
        /// </summary>
        public Listeners Listeners { get; private set; }

        /// <summary>
        /// Add to all request the AcceptLanguage based on CurrentCulture of the Thread
        /// </summary>
        public bool AddAcceptLanguageBasedOnCurrentCulture { get; set; }

        /// <summary>
        /// Gets the list of formatter used to serialize and deserialize data
        /// </summary>
        public Formatters Formatters { get; private set; }
    }
}