// See https://aka.ms/new-console-template for more information
using System;
namespace CSharp
{

    class Program
    {
        static void Main(string[] args){

            Console.WriteLine("1 - Nuevo dibujo");
            Console.WriteLine("2 - Salir");

            var opcion = DrawMenu();
            while(!opcion){
                opcion = DrawMenu();
            }
        }
        static bool DrawMenu(){
            var info = Console.ReadKey();
            if(info.KeyChar == '1'){
                var dibujo = new Dibujo();
                dibujo.AddFigura(FiguraFactory.Instance.GetTexto("Hola", 10, 10));
                dibujo.AddFigura(FiguraFactory.Instance.GetCuadrado(1, 3));
                var s = dibujo.Names;
                var s2 = dibujo.Figuras;
                var f = dibujo.GetByName<Texto>("Texto 0");
                dibujo.Save("drawing.json");
                dibujo.Dibujar();
                Console.Read();
                return true;
            }
            else if(info.KeyChar == '2'){
                return true;
            }
            else{
                Console.WriteLine("Seleccione 1 o 2");
                return false;
            }
        }
    }
}
