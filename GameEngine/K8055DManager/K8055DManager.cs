using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVellemanTEST.GameEngine.K8055DManager
{
    public class Fctvm110
    {

        //Include all methods related to the K8055 board

        #region fctvm110 Declares

        [DllImport("Resources\\K8055d.dll")]
        public static extern int OpenDevice(int CardAddress);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void CloseDevice();
        [DllImport("Resources\\K8055d.dll")]
        public static extern int ReadAnalogChannel(int Channel);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void ReadAllAnalog(ref int Data1, ref int Data2);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void OutputAnalogChannel(int Channel, int Data);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void OutputAllAnalog(int Data1, int Data2);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void ClearAnalogChannel(int Channel);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void SetAllAnalog();
        [DllImport("Resources\\K8055d.dll")]
        public static extern void ClearAllAnalog();
        [DllImport("Resources\\K8055d.dll")]
        public static extern void SetAnalogChannel(int Channel);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void WriteAllDigital(int Data);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void ClearDigitalChannel(int Channel);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void ClearAllDigital();
        [DllImport("Resources\\K8055d.dll")]
        public static extern void SetDigitalChannel(int Channel);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void SetAllDigital();
        [DllImport("Resources\\K8055d.dll")]
        public static extern bool ReadDigitalChannel(int Channel);
        [DllImport("Resources\\K8055d.dll")]
        public static extern int ReadAllDigital();
        [DllImport("Resources\\K8055d.dll")]
        public static extern int ReadCounter(int CounterNr);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void ResetCounter(int CounterNr);
        [DllImport("Resources\\K8055d.dll")]
        public static extern void SetCounterDebounceTime(int CounterNr, int DebounceTime);
        [DllImport("Resources\\K8055d.dll")]
        public static extern int Version();
        [DllImport("Resources\\K8055d.dll")]
        public static extern int SearchDevices();
        [DllImport("Resources\\K8055d.dll")]
        public static extern int SetCurrentDevice(int lngCardAddress);

        #endregion

        //Manage all events related to the K8055 board

        public event AnyButtonsDown isAnyButtonsDown;
        public delegate void AnyButtonsDown(int value);


        public void isAnyButtonsPressed()
        {
            if(ReadAllDigital() != 0)
            {
                isAnyButtonsDown?.Invoke(ReadAllDigital());
            }
        }
    }
}
