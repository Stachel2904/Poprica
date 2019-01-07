using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class Place : UserInterface
    {

        /// <summary>
        /// Holds the LocationType of this Place.
        /// </summary>
        public LocationType Location { get; set; }

        private List<DialogueEntity> dialogueEntities;

        public Place(LocationType type) : base(SceneType.PLACE)
        {
            Images.Add(new Image(ImageType.BACKGROUND, (int) type, (new Rectangle(0, 0, 1920, 1080))));
        }

        private DialogueEntityName[] GetAllWaifus()
        {

            return null;
        }

        private DialogueEntityName[] GetAllNSCs()
        {

            return null;
        }

        /// <summary>
        /// Adds a Entity to the Place by name.
        /// </summary>
        /// <param name="name">The name of the added Entity.</param>
        public void AddDialogueEntity(DialogueEntityName name)
        {

        }

        /// <summary>
        /// Tries to remove a Entity from this Place.
        /// </summary>
        /// <param name="name">The name of the Entity which should be removed. </param>
        /// <returns>Returns true if Entity is removed succesful.</returns>
        public bool TryRemoveDialogueEntity(DialogueEntityName name)
        {

            return false;
        }
    }
}
