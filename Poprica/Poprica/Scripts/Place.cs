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
        private bool IsActionActive;

        public Place(LocationType type) : base(SceneType.PLACE)
        {
            Location = type;
            IsActionActive = false;
            
        }

        public override void LoadImages()
        {
            base.LoadImages();

            Images.Add(new Image(ImageType.BACKGROUND, (int)Location, (new Rectangle(0, 0, width, height))));
            
        }

        public DialogueEntityName[] GetAllWaifus()
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

        private void AddButtons()
        {
            ButtonType[] locationButtons = Maps.LocationButtonMap[Location];
            Button[] createdButtons = ButtonManager.Main.CreateButtons(locationButtons, Location);

            for (int i = 0; i < createdButtons.Length; i++)
            {
                int imgIndex = (int)((UIImageType)Enum.Parse(typeof(UIImageType), createdButtons[i].Type.ToString()));

                this.Images.Add(new Image(ImageType.UI, imgIndex, createdButtons[i].Rect));
                //this.Texts.Add(new TextObject(Maps.MenuButtonText[(int)createdButtons[i].Type], createdButtons[i].Rect));
            }

            if (IsActionActive)
            {
                //add ActionBtns
            }
        }

        ///// <summary>
        ///// Starts a dialogue, with the given DialogueEnities in eventArgs.
        ///// </summary>
        ///// <param name="eventArgs">Holds int values of DialogueEnities.</param>
        //public void StartDialogue(int[] eventArgs)
        //{
        //    DialogueEntityName[] entities = new DialogueEntityName[eventArgs.Length];

        //    for (int i = 0; i < eventArgs.Length; i++)
        //    {
        //        entities[i] = (DialogueEntityName)eventArgs[i];
        //    }

        //    Console.WriteLine("Starte Dialog");
        //    //DialogueManager.Main.LoadNewDialogue(entities, ActionType.TALK);
        //}

        ///// <summary>
        ///// Leaves the Place, goes back to previous Place.
        ///// </summary>
        ///// <param name="eventArgs">Not used currently.</param>
        //public void Leave(int[] eventArgs)
        //{
        //    Console.WriteLine("Verlasse dieses Drecksloch");
        //}

        public override void Update()
        {
            base.Update();

            this.LoadImages();

            this.LoadPlayerInfo();

            this.AddButtons();
        }

        /// <summary>
        /// Returns amount of Money of the Main Player.
        /// </summary>
        /// <returns>Int which represents amount of Money.</returns>
        protected override int GetMoney()
        {
            return Poprica.Player.Main.Money;
        }
    }
}
