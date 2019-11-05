using Microsoft.AspNetCore.Mvc;
using Scoreboard.DataStore;
using Scoreboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Scoreboard.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ScoresController : Controller
    {
        /// <summary>
        /// The main data store.
        /// </summary>
        private readonly Store _store;

        /// <summary>
        /// Initializes a new instance of the ScoresController class.
        /// </summary>
        /// <param name="store"></param>
        public ScoresController(Store store)
        {
            _store = store;
        }

        /// <summary>
        /// This method saves the updated score, status of a console.
        /// </summary>
        /// <param name="board">Board to save console.</param>
        /// <returns>Returns OK.</returns>
        [HttpPost]
        public HttpResponseMessage Save([FromBody]Consoleboard board)
        {
            try
            {
                if (_store != null && board != null && !string.IsNullOrWhiteSpace(board.Id))
                    _store.RegisterOrSave(board.Id, board);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get the results.
        /// </summary>
        /// <returns>Results.</returns>
        [HttpGet]
        public IEnumerable<Consoleboard> Get()
        {
            return _store != null ? _store.GetCache().Select(x => x.Value) : new List<Consoleboard>();
        }
    }
}