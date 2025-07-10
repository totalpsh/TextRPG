using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public abstract class Scene
    {

        protected GameManager gm;
        public Scene(GameManager gameManager) 
        {
            gm = gameManager;
        }

        public abstract void RunScene();
    }
}
