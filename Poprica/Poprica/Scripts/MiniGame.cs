using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public abstract class MiniGame : Scene
    {

        public MiniGame(NamespaceType namespaceType) : base(SceneType.MINIGAME, namespaceType)
        {
         
        }

    }
}
