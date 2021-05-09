using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingale.Pecoff
{
    public class FileHeader
    {

    }

    public class OptionalHeader
    {

    }



    public class NtHeader
    {
        public string Signtrue { get; set; }
        public FileHeader FileHeader { get; private set; }
        public OptionalHeader OptionalHeader { get; private set; }
    }
}
