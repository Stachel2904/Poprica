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
            Location = type;
            
        }

        public override void LoadImages()
        {
            base.LoadImages();

            Images.Add(new Image(ImageType.BACKGROUND, (int)Location, (new Rectangle(0, 0, width, height))));

            LoadPlayerInfo(); //and other UI stuff
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

        public override void Update()
        {
            base.Update();

            LoadImages();
        }
    }
}
