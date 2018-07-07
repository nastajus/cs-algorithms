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
            //HMD hmd = new HMD();  //don't need this yet
            

            //pretend hardware level response received 

        }
    }

    #region mine

    class HMD
    {

        public OurHeadset OurHeadset { get; private set; }

        event Action<bool> VrFocusChanged;

        public HMD()
        {

            //pretend detect which device is connected... by some arbitrary placeholder ...
            if (true)
            {
                OurRift rift = new OurRift();
                OurHeadset = rift;
            }
            else if (false)
            {
                OurVive vive = new OurVive();
                OurHeadset = vive;
            }
        }

        //our system *could* listen to *other* system... by subscribing to *other's* events..
        void SubscribeToRift() { }
        void SubscribeToVive() { }

    }

    interface OurHeadset { }

    class OurRift : OurHeadset { }
    class OurVive : OurHeadset { }

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
        public void HardwareUpdate()
        {
            //while (true)
            {

            }
        }
    }
    class Vive : OpenVR { }

    #endregion theirs

}
