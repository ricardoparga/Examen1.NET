using ControlDados.Models;
namespace ControlDados{

    class ControlDadosAdmin{
        Jugador jugador;
        DatosJuego datos;

        public ControlDadosAdmin(){
            jugador = new Jugador();
            datos = new DatosJuego();
        
        }

        public void menuPrincipal(){
            int opcion;
            bool continuar = true;

            while(continuar){
                Console.WriteLine("1. Jugar");
                Console.WriteLine("2. Ver el balance");
                Console.WriteLine("3. Ver cantidad de tiradas realizadas");
                Console.WriteLine("4. Numero de veces que mas se ha tirado");
                Console.WriteLine("5. Numero de veces que menos se ha tirado");
                Console.WriteLine("6. Cantidad de resultados extremos");
                Console.WriteLine("7. Cantidad de resultados medios");
                Console.WriteLine("8. Cantidad de resultados pares");
                Console.WriteLine("9. Cantidad de resultados impares");
                Console.WriteLine("10. Salir");
                Console.Write("Opción: ");

                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("");


                if (opcion == 1){
                    Console.Clear();
                    jugar();
                }
                if (opcion == 2){
                    if (jugador.dinero > 300){
                        Console.Clear();
                        Console.WriteLine("Haz ganado " + (jugador.dinero - 300));
                        Console.WriteLine("Saldo actual: " + jugador.dinero);

                    }else if (jugador.dinero < 300){
                        Console.Clear();
                        Console.WriteLine("Haz perdido " + (300 - jugador.dinero));
                        Console.WriteLine("Saldo actual: " + jugador.dinero);

                    }else if (jugador.dinero == 300){
                        Console.Clear();
                        Console.WriteLine("No haz ganado ni perdido nada");
                        Console.WriteLine("Saldo actual: " + jugador.dinero);

                    }
                }
                if (opcion == 3){
                    Console.Clear();
                    Console.WriteLine("Numero de tiros realizados: " + datos.tiradas);
                }
                if (opcion == 4){
                    Console.Clear();
                    Console.WriteLine("El numero mas repetido es: " + maxOcurrencia(datos.numeroTirado));
                }
                if (opcion == 5){
                    Console.Clear();
                    Console.WriteLine("El numero menos repetido es: " + menorOcurrencia(datos.numeroTirado));
                }
                if (opcion == 6){
                    Console.Clear();
                    Console.WriteLine("La cantidad es: " + datos.resultadosExtremos + "\n");
                }
                if (opcion == 7){
                    Console.Clear();
                    Console.WriteLine("La cantidad es: " + datos.resultadosMedios + "\n");
                }
                if (opcion == 8){
                    Console.Clear();
                    Console.WriteLine("La cantidad es: " + datos.resultadosPares + "\n");
                }
                if (opcion == 9){
                    Console.Clear();
                    Console.WriteLine("La cantidad es: " + datos.resultadosImpares + "\n");
                }

                if (opcion == 10){
                    Console.WriteLine("Adios");
                    continuar = false;
                }

            }

        }

        /** Este método nos ayudará a inicializar el juego
        ** 
        */
        public void jugar(){
            int opcion;
            bool validar = true;

            while(validar){
                Console.WriteLine("Saldo actual: " + jugador.dinero);
                Console.WriteLine("");
                Console.WriteLine("¿Que desea hacer?");
                Console.WriteLine("1. Apostar a un número específico (ganancia x10)");
                Console.WriteLine("2. Apostar a que el número es un extremo (ganancia x8)");
                Console.WriteLine("3. Apostar a que el número es un medio (ganancia x4)");
                Console.WriteLine("4. Apostar si el número será par o impar (ganancia x2)");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                if (jugador.dinero == 0){
                    Console.Clear();
                    Console.WriteLine("No tienes suficiente dinero :(");
                    validar = false;
                }

                else if (opcion == 1){
                    Console.Clear();
                    int numero = apostarNumero();
                    if (apostarNumeroEnEspecifico()){
                        Console.WriteLine("Ganaste $"+numero*10);
                        jugador.dinero = jugador.dinero + (numero*10);
                    }
                    else{
                        Console.WriteLine("Perdiste $"+numero);
                        jugador.dinero = jugador.dinero - numero;
                    }
                    
                }
                else if (opcion == 2){
                    Console.Clear();
                    int numero = apostarNumero();
                    if (apostarNumeroPorExtremos()){
                        Console.WriteLine("Ganaste $"+numero*8);
                        jugador.dinero = jugador.dinero + (numero*8);

                    }else{
                        Console.WriteLine("Perdiste $"+numero);
                        jugador.dinero = jugador.dinero - numero;
                    }
                }
                else if (opcion == 3){
                    Console.Clear();
                    int numero = apostarNumero();

                    if (apostarNumeroPorMedios()){
                        Console.WriteLine("Ganaste $"+numero*4);
                        jugador.dinero = jugador.dinero + (numero*4);
                    }
                    else{
                        Console.WriteLine("Perdiste $"+numero);
                        jugador.dinero = jugador.dinero - numero;
                    }
                }
                else if (opcion == 4){
                    Console.Clear();
                    int numero = apostarNumero();

                    if (apostarNumeroParImpar()){
                        Console.WriteLine("Ganaste $"+numero*2);
                        jugador.dinero = jugador.dinero + (numero*2);
                    }else{
                        Console.WriteLine("Perdiste $"+numero);
                        jugador.dinero = jugador.dinero - numero;
                    }
                }
                else if (opcion == 5){
                    Console.Clear();
                    Console.WriteLine("Bye bye");
                    validar = false; // Se sale del menú
                }

            }
        }

        /**
        ** Este método nos ayudará a regresar una variable random.
        ** Nos regresará un numero random entre 2 y 12 (simulando una tirada de dados)
        */
        public int lanzarDados(){
            int dado;
            Random r= new Random ();
            return dado = r.Next(2, 13);
        }

        /**
        **  El while validará la variable a adivinar. 
        **  Nos pedirá una variable a introducir para adivinar el numero random.
        **  Si le atinó al numero regresará un true y si no adivinó el numero regresará un false.
        */
        public bool apostarNumeroEnEspecifico(){
            bool validar = true;
            int apuesta;
            int randy = lanzarDados();
            datos.tiradas = datos.tiradas + 1; // Significa que se hace una tirada
            datos.numeroTirado.Add(randy); // Se agregá a la lista el valor del dado
            almacenarResultados(randy); //Almacenamos los resultados

            while(validar){ //Este while nos ayudará a validar la variable apuesta
                Console.Write("Ingresa el valor que se quiere adivinar (2 o 12): ");
                apuesta = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                if (apuesta >= 2 && apuesta <= 12 ){ //Si el numero seleccionado es igual al número a adivinar.
                     Console.WriteLine("El numero del dado es: " + randy);

                    if (apuesta == randy) { //Le atinó al numero.
                        Console.WriteLine("Correcto.");
                        
                        return true;
                    }else{ //No le atinó al numero.
                        Console.WriteLine("Lo siento :(");
                        return false;
                    }
                }
            }
            return false;
        }

        public bool apostarNumeroPorExtremos(){
            bool validar = true;
            int apuesta;
            int randy = lanzarDados();
            datos.tiradas = datos.tiradas + 1; // Significa que se hace una tirada
            datos.numeroTirado.Add(randy); // Se agregá a la lista el valor del dado
            almacenarResultados(randy); //Almacenamos los resultados


            while (validar){
                Console.WriteLine("1.Es un extremo inferior (2, 3 ó 4):");
                Console.WriteLine("2.Es un extremo superior (10, 11 ó 12):");
                Console.Write("Ingresa el valor que se quiere adivinar:");
                apuesta = int.Parse(Console.ReadLine());

                if (apuesta == 1 || apuesta == 2 ){ //Si el numero es valido.
                    Console.WriteLine("El numero del dado es: " + randy);

                    if(apuesta == 1 && randy == 2 | randy == 3 | randy == 4){ // Si es que le atinó
                        Console.WriteLine("Correcto");
                        return true;
                    }

                    if(apuesta == 2 && randy == 10 | randy == 11 | randy == 12){ // Si es que le atinó
                        Console.WriteLine("Correcto");
                        return true;

                    }else{ // No le atinó
                        Console.WriteLine("Lo siento :(");
                        return false;
                    }
                }
            }
            return false;
        }

        public bool apostarNumeroPorMedios(){
            int randy = lanzarDados();
            datos.tiradas = datos.tiradas + 1; // Significa que se hace una tirada
            datos.numeroTirado.Add(randy); // Se agregá a la lista el valor del dado
            almacenarResultados(randy); //Almacenamos los resultados


            Console.WriteLine("El número del dado es: " + randy);
            if (randy >= 5 && randy <= 9 ){
                Console.WriteLine("Correcto");
                return true;
            }
            Console.WriteLine("Lo siento :(");
            return false;
        }

        public bool apostarNumeroParImpar(){
            bool validar = true;
            int apuesta;
            int randy = lanzarDados();
            datos.tiradas = datos.tiradas + 1; // Significa que se hace una tirada
            datos.numeroTirado.Add(randy); // Se agregá a la lista el valor del dado
            almacenarResultados(randy); //Almacenamos los resultados


            while(validar){
                Console.WriteLine("1.El número es par");
                Console.WriteLine("2.Es número es impar");
                Console.Write("Ingresa el valor que se quiere adivinar: ");
                apuesta = int.Parse(Console.ReadLine());

                if (apuesta == 1 || apuesta == 2 ){
                    Console.WriteLine("El número del dado es: "+ randy);
                    if (apuesta == 1 && esPar(randy)){ // El número es par
                        Console.WriteLine("Correcto");
                        return true;

                    }else if (apuesta == 2 && !esPar(randy)){ // El número es impar
                        Console.WriteLine("Correcto");
                        return true;

                    }else{
                        Console.WriteLine("Incorrecto");
                        return false;
                    }
                }
            }
            return false;
        }

        /**
        * Este método nos ayuda a validar el numero que se va a apostar y nos regresará el numero que se apostará
        */
        public int apostarNumero(){
            bool validar = true;
            while(validar){
                Console.Write("Cantidad a apostar: ");
                int numeroApostar = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                if (numeroApostar > jugador.dinero || !multiploDe10(numeroApostar)){
                    // Si el numero a apostar es mayor a la cantidad de saldo acutal o no es multiplo de 10.
                    Console.Write("El numero a apostar es mayor a la cantidad de dinero");
                    Console.Write(" ó no es multiplo de 10\n");
                }
                if(multiploDe10(numeroApostar) && numeroApostar < jugador.dinero){ //Si es multiplo de 10 y menor a la cantidad
                    return numeroApostar;
                }
                if (numeroApostar == jugador.dinero){
                    Console.WriteLine("All in");
                    return numeroApostar;
                }
            }
            return 0;
        }

        /**
        * Este método nos ayuda a validar si un numero es par o impar.
        */
        public static bool esPar(int numero){
            if((numero % 2) == 0){
                return true;
            }
            else{
                return false;
            }
        }

        /**
        * Este método nos ayuda a saber la mayor ocurrencia de una lista.
        */
        public int maxOcurrencia(List<int> lista)
        {
            int ocurrencia;
            var groups = lista.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).First();
            ocurrencia = largest.Key;
            return ocurrencia;
        }

        /**
        * Este método nos ayuda a saber la menor ocurrencia de una lista.
        */
        public int menorOcurrencia(List<int> lista){
            int ocurrencia;
            var groups = lista.GroupBy(x => x);
            var largest = groups.OrderByDescending(x => x.Count()).Last();
            ocurrencia = largest.Key;
            return ocurrencia;
        }
        
        /**
        * Este método nos ayuda a validar si un numero es multiplo de 10.
        */
        public bool multiploDe10(int numero){
            if (numero % 10 == 0){
                return true;
            }else{
                return false;
            }
        }

        /**
        * Este método nos ayudará a almacenar los datos de las tiradas.
        */
        public void almacenarResultados(int resultado){
            if (resultado >= 2 && resultado <= 4) {
                //Almacenamos en resultados extremos
                datos.resultadosExtremos = datos.resultadosExtremos + 1;
            }
            if (resultado >= 10 && resultado <= 12) {
                //Almacenamos en resultados extremos
                datos.resultadosExtremos = datos.resultadosExtremos + 1;

            }
            if (resultado >= 5 && resultado <= 9){
                //Almacenamos en resultados medios
                datos.resultadosMedios = datos.resultadosMedios+1;

            }
            if (esPar(resultado)){
                //Almacenamos en resultados pares
                datos.resultadosPares = datos.resultadosPares+1;

            }else if (!esPar(resultado)){
                //Almacenamos en resultados impares
                datos.resultadosImpares = datos.resultadosImpares+1;
            }
        }
    }
}