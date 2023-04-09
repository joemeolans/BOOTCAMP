namespace CSharp{
    public class Cuadrado : Figura, IFigura{
        public int Lado{get; set;}
        public Cuadrado(string name, int fila, int columna) : base(name, fila,columna){}
        public override void Dibujar(){}

    }

}