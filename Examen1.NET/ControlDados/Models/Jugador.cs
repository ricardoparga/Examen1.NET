namespace ControlDados.Models{

    class Jugador{
        private int _dinero;
    
        public Jugador(){
            _dinero = 300;
        }

        public int dinero{
            get {return _dinero;}
            set {_dinero = value;}
        }

    }
}