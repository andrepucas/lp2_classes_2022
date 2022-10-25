using System;

namespace GunDecorations
{
    class Program
    {
        static void Main(string[] args)
        {
            Gun __machineGun = new MachineGun();
            Console.Write("\n|| Machine Gun");
            __machineGun.Fire();

            Gun __shotGun = new ShotGun();
            Console.Write("\n|| ShotGun");
            __shotGun.Fire();

            Gun __sMachineGun = new GunSilencer(__machineGun);
            Console.Write("\n|| Machine Gun With Silencer");
            __sMachineGun.Fire();

            Gun __scMachineGun = new GunClip(__sMachineGun, 50);
            Console.Write("\n|| Machine Gun With Silencer and Clip");
            __scMachineGun.Fire();
        }
    }
}
