using System;
using WebPush;

public class VapidKeyGenerator
{
    public static void GenerateKeys()
    {
        var vapidDetails = VapidHelper.GenerateVapidKeys();
        Console.WriteLine("Public Key: " + vapidDetails.PublicKey);
        Console.WriteLine("Private Key: " + vapidDetails.PrivateKey);
    }
}
