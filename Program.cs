// See https://aka.ms/new-console-template for more information

using CodeMechanic.Diagnostics;
using CodeMechanic.FileSystem;
using PushbulletSharp;
using PushbulletSharp.Models.Requests;
using PushbulletSharp.Models.Responses;

Console.WriteLine("Hello, World!");


DotEnv.Load();  

string pat = DotEnv.Get("PUSHBULLET_PAT") ?? string.Empty;

// Console.WriteLine($"Pat: {pat}");

PushbulletClient client = new PushbulletClient(pat);

//If you don't know your device_iden, you can always query your devices
var devices = client.CurrentUsersDevices();
devices.Dump("my devices");

var device = devices.Devices.FirstOrDefault(o => o.Manufacturer == "samsung");

if (device != null)
{
    PushNoteRequest request = new PushNoteRequest
    {
        DeviceIden = device.Iden,
        Title = "hello world",
        Body = "This is a test from my C# wrapper.  Go to <a href='example.com'></a> to get started."
    };

    PushResponse response = client.PushNote(request);
}


