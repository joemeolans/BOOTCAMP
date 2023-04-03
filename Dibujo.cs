
namespace CSharp{
    
    public class Dibujo {

        private Lista<IFigura> _figuras;

        public Dibujo(){
            _figuras = new Lista<IFigura>(10);
            _figuras.Add(new Texto(10, 5, "Hola a todos"));
            var lista2 = new Lista<Texto>(10);

            var listaInt = new Lista<int>(10);
            listaInt.Add(1);
            listaInt.Add(2);
            listaInt.Add(3);
            listaInt.Add(4);
            listaInt.Add(5);
            listaInt.Add(6);
            var odds = listaInt.Find(new PredicateIntOdd());
        }

        public void Dibujar(){

            /*
            foreach(var figura in _figuras){
                figura?.Dibujar();
            }
            */
            for(int idx=0; idx<_figuras.Count; idx++){

                var figura = _figuras.GetAt(idx) as Figura;
                figura.Dibujar();
            }
        }
    }
}