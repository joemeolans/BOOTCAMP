using System;
namespace CSharp{

    public class Texto : Figura, IFigura{

        private string _texto;
        public Texto(string name, int fila, int columna, string texto) : base (name, fila, columna){
            _texto = texto;
        }
        public override void Dibujar(){
            Console.SetCursorPosition(Pos.Columna, Pos.Fila);
            Console.Write(_texto);
        }
    }
}