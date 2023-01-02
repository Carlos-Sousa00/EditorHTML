using System;
using System.Text;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using EditorHTML;

namespace EditorHtml
{
    public static class Editor
    {
        public static void Show ()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("-----------");
            Start();
        }

        public static void Start ()
        {
            var text = new StringBuilder();

            do
            {
                text.Append(Console.ReadLine());
                text.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("------------");
            Console.WriteLine("_Deseja salvar o arquivo?");
            Console.WriteLine("1 - SIM     2 - NÃO");
            short Escolha = short.Parse(Console.ReadLine());
            short count = 0;
            while (Escolha != 1 || Escolha != 2)
            {
                if (count == 4)
                {
                    Console.WriteLine("Você excedeu o numero de escolhas erradas!");
                    Console.WriteLine("Por segurança vamos finalizar o programa.");
                    System.Environment.Exit(0);
                }
                if (Escolha == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Qual o caminho para salvar o arquivo?");
                    var path = Console.ReadLine();
                    path = path + ".txt";

                    using (var file = new StreamWriter(path))
                    {
                        file.Write(text);
                    }
                    Console.WriteLine($"Arquivo salvo com sucesso no caminho {path}");
                    Console.WriteLine("Aperte qualquer botão para acessar a Viewer");
                    Console.ReadLine();
                    Viewer.Show(text.ToString());
                }
                else if (Escolha == 2)
                {
                    Menu.Show();
                }
                else
                {
                    Console.WriteLine("Por favor, digite uma opção valida.");
                    Escolha = short.Parse(Console.ReadLine());
                    count++;
                }
            }
        }

    }
}