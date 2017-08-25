using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Shared.Client.Logic
{
    /// <summary>
    /// Specifies a function that should be executed in place of a client lua script.
    /// </summary>
    public class ClientScriptAttribute : Attribute
    {
        /// <summary>
        /// Name of the script function.
        /// </summary>
        public string Name { get; private set; }

        public ClientScriptAttribute(string name)
        {
            this.Name = name;
        }
    }
}
