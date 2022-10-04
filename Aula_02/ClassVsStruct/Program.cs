using System;

namespace ClassVsStruct
{
    class Program
    {
        private static void Main(string[] args)
        {
            PlayerClass pc1 = new PlayerClass{Health = 100, Armor = 50}, pc2;
            PlayerStruct ps1 = new PlayerStruct{Health = 100, Armor = 50}, ps2;

            pc2 = pc1;
            ps2 = ps1;

            ShowStats(pc1, pc2, ps1, ps2);

            // pc1.Health = 75;
            // pc1.Armor = 25;
            // ps1.Health = 75;
            // ps1.Armor = 25;

            DoubleHealth(ref pc1, ref ps1);

            Console.WriteLine("\n\t --- VALUES CHANGED ---");
            ShowStats(pc1, pc2, ps1, ps2);
        }

        private static void DoubleHealth(ref PlayerClass pc, ref PlayerStruct ps)
        {
            pc.Health *= 2;
            ps.Health *= 2;
        }

        private static void ShowStats(
            PlayerClass pc1, PlayerClass pc2, PlayerStruct ps1, PlayerStruct ps2)
        {
            Console.WriteLine(
                "\n\tCLASS VALUES:\n\t"+
                "PC1 (Health: {0}, Armor: {1}) \n\tPC2 (Health: {2}, Armor: {3})",
                pc1.Health, pc1.Armor, pc2.Health, pc2.Armor);

            Console.WriteLine(
                "\n\tSTRUCT VALUES:\n\t"+
                "PS1 (Health: {0}, Armor: {1}) \n\tPS2 (Health: {2}, Armor: {3})",
                ps1.Health, ps1.Armor, ps2.Health, ps2.Armor);
        }
    }
}
