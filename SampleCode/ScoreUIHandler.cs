using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    class ScoreUIHandler
    {
        public static ScoreUIHandler s_instance = null;

        public static ScoreUIHandler GetInstance()
        {
            if (ScoreUIHandler.s_instance == null)
            {
                ScoreUIHandler.s_instance = new ScoreUIHandler();
            }

            return ScoreUIHandler.s_instance;
        }

        protected ScoreUIHandler()
        {
        }

        public void Update(int pScore)
        {
            Console.WriteLine("Length: {0:D}" , pScore);
        }

        public void ShowGameOver()
        {
            Console.WriteLine("\nYou lose!");
        }
    }
}
