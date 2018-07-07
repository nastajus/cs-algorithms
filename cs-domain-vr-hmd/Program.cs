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

        public IOurHeadset OurHeadset { get; private set; }

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
            else
            {
                throw new Exception($"can't detect hardware, can't start {nameof(HMD)}");
            }
        }

        //our system *could* listen to *other* system... by subscribing to *other's* events..
        private void SubscriptionsCheckUpdate()
        {
            OurHeadset.SubscribeToHardwareEvents();
        }

    }

    interface IOurHeadset
    {
        void SubscribeToHardwareEvents();
    }

    class OurRift : Rift, IOurHeadset {

        public OurRift()
        {
            SubscribeToHardwareEvents();
        }

        public void SubscribeToHardwareEvents()
        {

            InputFocusLost += OnInputFocusLost();
        }

        public Action<bool> OnInputFocusLost()
        {
            Console.WriteLine("yo, duuuude, the Rift's focus has been ... ");
        }
    }

    class OurVive : Vive, IOurHeadset {
        public void OnInputFocusLost()
        {
            throw new NotImplementedException();
        }

        public void SubscribeToHardwareEvents()
        {
            throw new NotImplementedException();
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
        //these be pushed out to use... this would be a publisher... to anything that cares, like IOurHeadset...
        public event Action<bool> InputFocusLost;

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
