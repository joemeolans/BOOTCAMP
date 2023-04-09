using System;
namespace CSharp{

    public class Texto : Figura, IFigura{

        public string Text{get;}
        public Texto(string name, int fila, int columna, string texto) : base (name, fila, columna){
            Text = texto;
        }
        public override void Dibujar(){
            Console.SetCursorPosition(Pos.Columna, Pos.Fila);
            Console.Write(Text);
        }
    }
}