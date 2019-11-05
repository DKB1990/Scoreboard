using Scoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Scoreboard.DataStore
{
    public sealed class Store
    {
        /// <summary>
        /// Cache Store.
        /// </summary>
        private readonly Dictionary<string, Consoleboard> _cache;
        private readonly IFile _file;

        /// <summary>
        /// Initializes the instance of the class.
        /// </summary>
        public Store(IFile file)
        {
            this._file = file;
            _cache = new Dictionary<string, Consoleboard>();
            loadOldConsoles();
        }

        /// <summary>
        /// This logic will automatically load Old consoles from JSON file.
        /// </summary>
        private void loadOldConsoles()
        {
            try
            {
                IEnumerable<Consoleboard> oldConsoles = _file.GetFileContent();
                foreach (var console in oldConsoles)
                {
                    console.LastUpdated = DateTime.UtcNow;
                    RegisterOrSave(console.Id, console, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method registers new console and update console values.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="board">The console board</param>
        /// <param name="isRegister">Check if is registered.</param>
        public HttpResponseMessage RegisterOrSave(string key, Consoleboard board, bool isRegister = false)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(key))
                    if (isRegister || !_cache.ContainsKey(key))
                        _cache.Add(key, board);
                    else
                        _cache[key] = board;

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                _file.WriteFileContent(_cache.Select(x => x.Value));
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed); ;
            }
        }

        /// <summary>
        /// Get the results from cache.
        /// </summary>
        /// <returns>Console.</returns>
        public Dictionary<string, Consoleboard> GetCache()
        {
            return _cache;
        }
    }
}
