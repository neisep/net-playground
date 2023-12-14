using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupStar.Domain
{
    public class Request
    {
        /// <summary>
        /// Title name of the procedure to be executed.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Contains Json Object of Steps!
        /// </summary>
        public List<Steps> Steps { get; set; }
    }
}
