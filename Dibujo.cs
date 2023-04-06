using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace CSharp{
    
    public class Dibujo {

        private readonly List<IFigura> _figuras;

        public Dibujo(){
            _figuras = new List<IFigura>(10);
            _figuras.Add(new Texto("Pedro", 10, 5, "Hola a todos"));
            var lista2 = new List<Texto>(10);
            var listaInt = new Lista<int>(10);
            listaInt.Add(1);
            listaInt.Add(2);
            listaInt.Add(3);
            listaInt.Add(4);
            listaInt.Add(5);
            listaInt.Add(6);
            //var odds = listaInt.FindPredicate(new PredicateIntOdd());
            var odds = listaInt.FindDelegate(i => i%2==0);
            var biggerThanThree = listaInt.FindDelegate(i => i>3);
            //_figuras.GetFirst().Dibujar();
            IEnumerable<int> i = new [] {1,2,3,4,5,6};
            var s = i.Skip(2).Take(3).Where(x => x>=4).Sum();
        }
        public IFigura this[string name]{
            get{
                return _figuras.FirstOrDefault(x => x.Name == name);
            }
        }
        public IEnumerable<string> Names{
            get{
                return _figuras.Select(f => f.Name).OrderBy(n => n);
            }
        }
        public IEnumerable<IFigura> Figuras{
            get{
                return _figuras;
            }
        }
        public T GetByName<T>(string name)
        where T : class, IFigura
        {
            return this[name] as T;
        }
        public void AddFigura(IFigura figura){
            _figuras.Add(figura);
        }

        public void Dibujar(){

            
            foreach(var figura in _figuras){
                figura?.Dibujar();
            }
            /*
            for(int idx=0; idx<_figuras.Count; idx++){

                var figura = _figuras.GetAt(idx) as Figura;
                figura.Dibujar();
            }
            */
        }

        public void Save(string path){
            var json = JsonConvert.SerializeObject(_figuras);
        }
    }
}