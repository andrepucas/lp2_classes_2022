using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileStreams
{
    public class Program
    {
        // Nomes dos ficheiros
        private const string filenameText = "dados.txt";
        private const string filenameBinary = "dados.bin";

        // Dados a escrever e ler nos ficheiros
        private const string dataString = "Hello world!";
        private const int dataInt = 18;
        private const float dataFloat = 3.1415f;

        private static void Main()
        {
            // String para onde ler opção inserida pelo utilizador
            string option;

            // Ciclo do menu principal
            do
            {
                // Apresentar menu principal
                Console.WriteLine("==== Que programa devo executar? ==== \n");
                Console.WriteLine("\t1. Escreve ficheiro em modo de texto");
                Console.WriteLine("\t2. Lê ficheiro em modo de texto");
                Console.WriteLine("\t3. Escreve ficheiro em modo binário");
                Console.WriteLine("\t4. Lê ficheiro em modo binário");
                Console.WriteLine("\t5. Sair");
                Console.Write("\n>");

                // Solicitar opção ao utilizador
                option = Console.ReadLine();

                // Tratar opção do utilizador
                switch (option)
                {
                    case "1":
                        EscreverTexto(); break;
                    case "2":
                        LerTexto(); break;
                    case "3":
                        EscreverBin(); break;
                    case "4":
                        LerBin(); break;
                    case "5":
                        Console.WriteLine("Obrigado e até à próxima!");
                        break;
                    default:
                        Console.WriteLine("**** Opção inválida! ****");
                        break;
                }

                Console.WriteLine(
                    "Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (option != "5");
        }

        // 1. Escreve ficheiro em modo de texto
        private static void EscreverTexto()
        {
            StreamWriter sw = File.CreateText(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                filenameText));

            sw.WriteLine(dataString);
            sw.WriteLine(dataInt);
            sw.WriteLine(dataFloat);

            sw.Close();
        }

        // 2. Lê ficheiro em modo de texto
        private static void LerTexto()
        {
            StreamReader sr = File.OpenText(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                filenameText));

            string impStringData = sr.ReadLine();
            int impIntData = Convert.ToInt32(sr.ReadLine());
            float impFloatData = Convert.ToSingle(sr.ReadLine());

            sr.Close();

            Console.WriteLine("Imported string: " + impStringData);
            Console.WriteLine("Imported int: " + impIntData);
            Console.WriteLine("Imported float: " + impFloatData);
        }

        // 3. Escreve ficheiro em modo binário
        private static void EscreverBin()
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                filenameBinary);

            BinaryWriter bw = new BinaryWriter(File.Create(path));

            bw.Write(dataString);
            bw.Write(dataInt);
            bw.Write(dataFloat);

            bw.Close();
        }

        // 4. Lê ficheiro em modo binário
        private static void LerBin()
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                filenameBinary);

            BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open));

            string impStringData = br.ReadString();
            int impIntData = br.ReadInt32();
            float impFloatData = br.ReadSingle();

            Console.WriteLine("Imported bin string: " + impStringData);
            Console.WriteLine("Imported bin int: " + impIntData);
            Console.WriteLine("Imported bin float: " + impFloatData);
        }
    }
}
