using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_domain_vr_hmd
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    #region mine

    class Vusr { }
    class HMD { }

    #endregion mine


    #region theirs

    //runtime
    class OVR { }
    class OpenVR { }

    //hardware
    class Rift : OVR { }
    class Vive : OpenVR { }

    #endregion theirs

}
