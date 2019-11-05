using Scoreboard.Models;
using System.Collections.Generic;

namespace Scoreboard.DataStore
{
    public interface IFile
    {
        /// <summary>
        /// This method will load the content for old consoles.
        /// </summary>
        /// <returns>List of consoles.</returns>
        IEnumerable<Consoleboard> GetFileContent();

        /// <summary>
        /// This method will write to the disk in case of failure.
        /// </summary>
        /// <param name="boards">The list of running and stopped consoles.</param>
        void WriteFileContent(IEnumerable<Consoleboard> boards);
    }
}
