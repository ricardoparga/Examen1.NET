namespace ControlDados.Models{

    class DatosJuego{
        private int _tiradas;
        private List<int> _numeroTirado;
        private int _resultadosExtremos;
        private int _resultadosMedios;
        private int _resultadosPares;
        private int _resultadosImpares;

        public DatosJuego(){
            _tiradas = 0;
            _numeroTirado = new List<int>();
            _resultadosExtremos = 0;
            _resultadosMedios = 0;
            _resultadosPares = 0;
            _resultadosImpares = 0;

        }

        public int tiradas{
            get{return _tiradas;}
            set{_tiradas = value;}
        }

        public List<int> numeroTirado{
            get{return _numeroTirado;}
            set{_numeroTirado = value;}
        }

        public int resultadosExtremos{
            get {return _resultadosExtremos;}
            set {_resultadosExtremos = value;}
        }

         public int resultadosMedios{
            get {return _resultadosMedios;}
            set {_resultadosMedios = value;}
        }
        public int resultadosPares{
            get{return _resultadosPares;}
            set{_resultadosPares = value;}
        }
        public int resultadosImpares{
            get{return _resultadosImpares;}
            set{_resultadosImpares = value;}
        }
    }
}