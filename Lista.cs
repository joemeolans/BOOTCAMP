using System;
using System.Collections;
namespace CSharp{
    /*
    public class Lista{
        private readonly object[] _items;
        private readonly Type _type;
        public int Count {get; private set;}
        public Lista(int limit, Type type){
            _items = new object[limit];
            Count = 0;
            _type = type;
        }

        public object GetAt(int idx){
            return _items[idx];
        }
        
        public void Add (object item){
            if(item.GetType().IsAssignableFrom( _type)){
                throw new ArgumentException("Tipo " + item.GetType().Name + " mp es válido");
            }
            if(Count == _items.Length){
                throw new InvalidOperationException("Lista llena!");
            }
            _items[Count] = item;
            Count++;
        }
        */
        /*
        public class Lista<T> : Lista{
            private readonly Lista _lista;
             public int Count {get{
                return _lista.Count;
             }
             }
            public Lista (int limit) : base(limit, typeof(T)){

            }
            public T GetAt(int idx){
                return (T)_lista.GetAt(idx);
            }
            public void Add (T item){
                _lista.Add(item);
            }
        }
        */

        public interface ILista{
            int Count{get;}
            object GetAt(int idx);
            void Add(object item);
        }

        public interface ILista<T> : IEnumerable<T>{
            int Count{get;}
            T GetAt(int idx);
            void Add(T item);

            IEnumerable<T> Find(IPredicate<T> predicate);
        }

        public class Lista<T> : ILista<T>, ILista{
        private readonly T[] _items;
        public int Count {get; private set;}
        public Lista(int limit){
            _items = new T[limit];
            Count = 0;
        }

        public T GetAt(int idx){
            return _items[idx];
        }
        object ILista.GetAt(int idx){
            return _items[idx];
        }
        void ILista.Add(object item){
            Add((T)item);
        }
        public void Add (T item){
            if(Count == _items.Length){
                throw new InvalidOperationException("Lista llena!");
            }
            _items[Count] = item;
            Count++;
        }

        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator(){
            for(var i = 0; i < _items.Length; i++){
                yield return _items[i];
            }
        }

        public IEnumerable<T> Find(IPredicate<T> predicate){
            foreach(var current in _items){
                if(current != null && predicate.Match(current)){
                    yield return current;
                }
            }
        }
    }

}