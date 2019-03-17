using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class WaifuManager
    {
        #region Singleton
        private static WaifuManager main;

        public static WaifuManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new WaifuManager();
                }
                return main;
            }
        }
        #endregion

        private Dictionary<DialogueEntityName, Waifu> waifus;
        private List<Waifu> party;

        public DialogueEntityName SelectedWaifu { get; set; }

        private WaifuManager()
        {
            waifus = new Dictionary<DialogueEntityName, Waifu>
            {
                { DialogueEntityName.RICA, new Waifu(DialogueEntityName.RICA) }
            };
            
            party = new List<Waifu>();
        }

        /// <summary>
        /// Change the location of a Waifu.
        /// </summary>
        /// <param name="name">The name of the Waifu.</param>
        /// <param name="newLocation">The new location of the Waifu.</param>
        public void ChangeLocation(DialogueEntityName name, LocationType newLocation)
        {
            waifus[name].Location = newLocation;
        }

        /// <summary>
        /// Get the Waifu from a name.
        /// </summary>
        /// <param name="name">The name of the Waifu you want.</param>
        /// <returns>Returns the Waifu you want.</returns>
        public Waifu GetWaifu(DialogueEntityName name)
        {
            return waifus[name];
        }

        /// <summary>
        /// Gets the names of all DialogueEntities at a Location.
        /// </summary>
        /// <param name="location">Location of which you want the Names.</param>
        /// <returns>Returns DialogueEntityNames as int array.</returns>
        public int[] GetEnities(LocationType location = LocationType.NONE)
        {
            List<int> names = new List<int>();

            if (location != LocationType.NONE)
            {
                foreach(KeyValuePair<DialogueEntityName, Waifu> waifu in waifus)
                {
                    if (waifu.Value.Location == location)
                    {
                        names.Add((int)waifu.Key);
                    }
                }
            }
            else if (SceneManager.Main.CurrentScene != null)
            {
                if (SceneManager.Main.CurrentScene.SceneCategory == SceneType.PLACE)
                {
                    location = (SceneManager.Main.CurrentScene as Place).Location;
                    
                    foreach (KeyValuePair<DialogueEntityName, Waifu> waifu in waifus)
                    {
                        if (waifu.Value.Location == location)
                        {

                            names.Add((int)waifu.Key);
                        }
                    }
                }
            }

            int[] ret = names.ToArray();
            
            return ret;
        }

        /// <summary>
        /// Get the location of a Waifu.
        /// </summary>
        /// <param name="name">The name of the Waifu, which location you want.</param>
        /// <returns>Returns the location of the given Waifu.</returns>
        public LocationType GetLocation (DialogueEntityName name)
        {
            return (LocationType) 0;
        }

        /// <summary>
        /// Unlock a new Waifu.
        /// </summary>
        /// <param name="name">The name of the new Waifu.</param>
        public void UnlockWaifu(DialogueEntityName name)
        {
            waifus[name].Locked = false;
        }

        public void RenderWaifus()
        {
            foreach(KeyValuePair<DialogueEntityName, Waifu> waifu in waifus)
            {
                if(waifu.Value.Location == (SceneManager.Main.CurrentScene as Place).Location && !waifu.Value.Locked)
                {
                    //should moved into a field, damit das nicht in jedem frame berechnet wird
                    Rectangle newRect = Maps.DialogueEntityPositions[PositionType.RIGHT];

                    newRect.Location = new Point((int) (newRect.Location.X * PopricaGame.Main.CalcCurrentScale().X), (int) (newRect.Location.Y * PopricaGame.Main.CalcCurrentScale().Y));
                    
                    //Todo add pose
                    SceneManager.Main.CurrentScene.Images.Add(new Image(ImageType.POSES, (int)PoseType.NORMAL, newRect, waifu.Value.Name.ToString()));  //add Waifu to Images list   
                    SceneManager.Main.CurrentScene.Images.Add(new Image(ImageType.MOOD, (int)waifu.Value.Mood, newRect, waifu.Value.Name.ToString()));

                    for (int i = 0; i < waifu.Value.Clothes.Count; i++)
                    {
                        SceneManager.Main.CurrentScene.Images.Add(new Image(ImageType.CLOTHES, (int)waifu.Value.Clothes[i], newRect, waifu.Value.Name.ToString()));
                    }
                }
            }

            //render Stats, should be in Scenemanager; JP: "sure???"
            //WaifuStats renderedStats = waifus[SelectedWaifu].Stats;
            //RessourceManager.Main.DrawText(new TextObject(renderedStats.Affection.ToString(), new Rectangle(50, 50, 50, 50)));
            //RessourceManager.Main.DrawText(new TextObject(renderedStats.Obedience.ToString(), new Rectangle(150, 50, 50, 50)));
            //RessourceManager.Main.DrawText(new TextObject(renderedStats.Hornyness.ToString(), new Rectangle(250, 50, 50, 50)));
            //RessourceManager.Main.DrawText(new TextObject(renderedStats.Stamina.ToString(), new Rectangle(350, 50, 50, 50)));
        }
    }
}
