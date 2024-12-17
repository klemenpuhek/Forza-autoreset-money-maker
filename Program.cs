using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

namespace Forza{
    public class Program
    {
        [DllImport("user32.dll")]
        static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        public static InputSimulator inputSimulator = new InputSimulator();
        static void HoldKeyForDuration(VirtualKeyCode key, int durationMilliseconds)
        {

            inputSimulator.Keyboard.KeyDown(key);

            Thread.Sleep(durationMilliseconds);

            inputSimulator.Keyboard.KeyUp(key);
        }

        static async Task Main(string[] args)
        {
            Process[] proces = Process.GetProcessesByName("ForzaHorizon5");   // najdemo vse procese od forze
            Process forzaProces = proces.FirstOrDefault();  // zabelezimo proces
            Console.WriteLine(forzaProces);

            while (1 != 0)
            {
                    Console.WriteLine("dela");
                    IntPtr point = forzaProces.MainWindowHandle;
                    ShowWindowAsync(point, 3); // ce je forza minimizirana jo fuknemo naprej
                    SetForegroundWindow(point);  // zberemo forzo pa jo damo v ospredje

                    HoldKeyForDuration(VirtualKeyCode.VK_W, 35000);
                    Thread.Sleep(5000);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.VK_X); //x
                    Thread.Sleep(500);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN); //enter
                    Thread.Sleep(5000);
                    inputSimulator.Keyboard.KeyDown(VirtualKeyCode.RETURN); //enter
                    Thread.Sleep(5000);

            }
        }
    }
}