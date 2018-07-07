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

    class HMD
    {
        event Action<bool> VrFocusChanged;

        HMD()
        {

            //detect which device is connected... by some arbitrary placeholder ...
            if (true)
            {
                Rift rift = new Rift();
            }
            else if (false)
            {
                Vive vive = new Vive();
            }



        }
    }

    #endregion mine

    #region theirs

    //runtime
    class OVR { }
    class OpenVR { }

    //hardware representation
    class Rift : OVR
    {
        event Action<bool> InputFocusLost;

        //something listening low-level to hardware... maybe in a loop...
        void HardwareUpdate()
        {
            //while (true)
            {

            }
        }
    }
    class Vive : OpenVR { }

    #endregion theirs

}
