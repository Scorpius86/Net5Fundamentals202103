using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Fundamentals.Game.Tetris
{
    class StarWarsSong
    {
        //tresillo re re re
        private void rerere(int d)
        {
            //un boucle FOR repite 3 veces el Beep
            for (int x = 0; x < 3; x++)
            {
                Console.Beep(523, d); //re
            }
        }

        //tresillo do si la
        private void dosila(int d)
        {
            Console.Beep(1046, d); //do
            Console.Beep(987, d); //si
            Console.Beep(880, d);//la
        }

        //tresillo do si do
        private void dosido(int d)
        {
            Console.Beep(1046, d);
            Console.Beep(987, d);
            Console.Beep(1046, d);
        }
        private void partI_starwars()
        {
            rerere(200); // llamamos a la funcion rerere()
            Console.Beep(783, 1200); //sol
            Console.Beep(1174, 1200);//re2
            dosila(200); //funcion dosila()
            Console.Beep(1567, 1200); //sol2
            Console.Beep(1174, 600); //re2
            dosila(200); //nuevamente funcion dosila()
            Console.Beep(1567, 1200); //sol2
            Console.Beep(1174, 600); //re2
            dosido(200); //ahora dosido()
            Console.Beep(880, 1200); //la
        }
        private void reremimi()
        {
            Console.Beep(523, 400); //re
            Console.Beep(523, 200); //re
            Console.Beep(659, 900); //mi
            Console.Beep(659, 300); //mi
        }

        private void frase000()
        {
            Console.Beep(1046, 300);//do
            Console.Beep(987, 300);//si
            Console.Beep(880, 300);//la
            Console.Beep(783, 300);//sol

            Console.Beep(783, 300);//sol
            Console.Beep(880, 150);//la
            Console.Beep(987, 150);//si
            Console.Beep(880, 300);//la
            Console.Beep(659, 300); //mi
            Console.Beep(733, 600); //fa#
        }

        private void frase001()
        {
            Console.Beep(1046, 300);//do
            Console.Beep(987, 300);//si
            Console.Beep(880, 300);//la
            Console.Beep(783, 300);//sol

            Console.Beep(1174, 900);//re2
            Console.Beep(880, 300);//la
            Console.Beep(880, 600);//la
        }

        private void frase002()
        {
            Console.Beep(1174, 400); //re2
            Console.Beep(1174, 200); //re2
            Console.Beep(1567, 400); //sol2
            Console.Beep(1396, 200); //sol2
            Console.Beep(1244, 400); //mib
            Console.Beep(1174, 200); //re
            Console.Beep(1046, 400); //do
            Console.Beep(923, 200);  //sib
            Console.Beep(880, 400);  //la
            Console.Beep(783, 200);  //sol
            Console.Beep(1174, 600);//re2
            for (int x = 0; x < 3; x++)
            {
                Console.Beep(880, 200);  //la
            }
            Console.Beep(880, 600);  //la
        }
        private void partII_starwars()
        {
            reremimi(); frase000();
            reremimi(); frase001();
            reremimi(); frase000();
            frase002();
        }
        private void final()
        {
            for (int x = 0; x < 3; x++)
            {
                Console.Beep(1174, 200); //re2
            }
            Console.Beep(1567, 1800); //sol2

            for (int x = 0; x < 3; x++)
            {
                Console.Beep(783, 200); //re2
            }
            Console.Beep(783, 1800);  //sol
        }
        public void Play()
        {
            //repetimos la primera parte 2 veces
            //asi esta en la partitura :)
            for (int x = 0; x < 2; x++) { partI_starwars(); }
            //ejecutamos la segunda parte 1 sola vez
            partII_starwars();
            //nuevamente la primera parte vuelve a ejecutarse
            //2 veces
            for (int x = 0; x < 2; x++) { partI_starwars(); }
            //ejecutamos el final de la melodia
            final();
        }

    }
}
