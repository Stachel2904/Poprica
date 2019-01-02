using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class DialogueManager
    {
        #region Singleton
        private static DialogueManager main;

        public static DialogueManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new DialogueManager();
                }
                return main;
            }
        }
        #endregion

        private Statement[] dialogue;
        private int index;

        private DialogueManager()
        {
            index = 0;
        }

        /// <summary>
        /// Loads a new Dialogue from the current SceneType and the DialogueEntities inside the Scene.
        /// </summary>
        public void LoadDialogue()
        {

        }

        private void CheckMemories()
        {

        }
    }
}
