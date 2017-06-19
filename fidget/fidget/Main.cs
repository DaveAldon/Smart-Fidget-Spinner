using UIKit;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Plugin.BLE.Abstractions.Contracts;
using System.Diagnostics;

namespace fidget
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

			var ble = Mvx.Resolve<IBluetoothLE>();
			var adapter = Mvx.Resolve<IAdapter>();

            var state = ble.State;

			ble.StateChanged += (s, e) =>
			{
				Debug.WriteLine($"The bluetooth state changed to {e.NewState}");

			};
        }

    }
}
