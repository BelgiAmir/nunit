﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit.Framework
{
    /// <summary>
    /// TestParameters class holds any named parameters supplied to the test run
    /// </summary>
    public class TestParameters
    {
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        /// <summary>
        /// Gets the number of test parameters
        /// </summary>
        public int Count
        {
            get { return _parameters.Count; }
        }

        /// <summary>
        /// Gets a collection of the test parameter names
        /// </summary>
        public ICollection<string> Names
        {
            get { return _parameters.Keys; }
        }

        /// <summary>
        /// Indexer is the only public access to the internal dictionary
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <returns>Value of the parameter or null if not present</returns>
        public string this[string name]
        {
            get { return _parameters.ContainsKey(name) ? _parameters[name] : null; }
        }

        /// <summary>
        /// Get method is a simple alternative to the indexer
        /// </summary>
        /// <param name="name">Name of the paramter</param>
        /// <returns>Value of the paramter or null if not present</returns>
        public string Get(string name)
        {
            return this[name];
        }

        public string Get(string name, string defaultValue)
        {
            return this[name] ?? defaultValue;
        }

        public int GetInt(string name)
        {
            return GetInt(name, 0);
        }

        public int GetInt(string name, int defaultValue)
        {
            string val = this[name];
            return val != null ? int.Parse(val) : defaultValue;
        }

        /// <summary>
        /// Adds a parameter to the list
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter</param>
        internal void Add(string name, string value)
        {
            _parameters[name] = value;
        }
    }
}
