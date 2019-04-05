﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public abstract class Scene
    {
        public SceneType SceneCategory;
        /// <summary>
        /// Holds an List of images, which should be displayed in the scene.
        /// </summary>
        public List<Image> Images { get; set; }
        public List<TextObject> Texts { get; set; }

        protected int height;
        protected int width;

        public Scene(SceneType sceneType)
        {
            //ToDo change to old
            height = 2160; // PopricaGame.maxGameHeight;
            width = 3840; // PopricaGame.maxGameWidth;

            Images = new List<Image>();
            Texts = new List<TextObject>();
            SceneCategory = sceneType;
        }

        /// <summary>
        /// Updates this Scene and its components.
        /// </summary>
        public virtual void Update()
        {
            //height = PopricaGame.Main.gameHeight;
            //width = PopricaGame.Main.gameWidth;
        }

        /// <summary>
        /// Renders the displayed images.
        /// </summary>
        public void Render()
        {

        }

        /// <summary>
        /// Loads images which have to been displayed.
        /// </summary>
        public virtual void LoadImages()
        {
            Images.Clear();
            Texts.Clear(); //should been in own LoadTexts Fct.
        }

        /// <summary>
        /// Tries to restart this Scene.
        /// </summary>
        /// <returns>Returns true if restart was succesful.</returns>
        public bool Restart()
        {
            return false;
        }

        public void LoadPlayerInfo()
        {
            Vector2 scale = PopricaGame.Main.CalcCurrentScale();

            Rectangle rect = new Rectangle((int)(3300 * scale.X), (int)(20 * scale.Y), 520, 250);
            Image playerInfo = new Image(ImageType.UI, (int)UIImageType.PLAYERINFO, rect);

            Images.Add(playerInfo);


            //ggf. mehr als nur PlayerInfo
            ButtonType[] menuButtons = Maps.MenuButtonMap[MenuType.PLAYERINFO];

            Button[] createdButtons = ButtonManager.Main.CreateButtons(menuButtons, MenuType.PLAYERINFO);
            
            for (int i = 0; i < createdButtons.Length; i++)
            {
                int imgIndex = (int)((UIImageType)Enum.Parse(typeof(UIImageType), createdButtons[i].Type.ToString()));

                this.Images.Add(new Image(ImageType.UI, imgIndex, createdButtons[i].Rect));
            }

            //writes current time into HUD
            Texts.Add(new TextObject(TimeManager.Main.DateTime.ToShortTimeString(), new Rectangle((int) (3520 * scale.X), (int) (70 * scale.Y), 500, 100), (scale.X >= .6) ? 2 : 1));
            Texts.Add(new TextObject(TimeManager.Main.DateTime.ToShortDateString(), new Rectangle((int)(3490 * scale.X), (int)(100 * scale.Y), 500, 100), (scale.X >= .6) ? 2 : 1));

            //writes current Mone into HUD
            Texts.Add(new TextObject(SceneManager.Main.CurrentScene.GetMoney() + " P", new Rectangle((int) (3420 * scale.X), (int) (212 * scale.Y), 100, 100), (scale.X >= .6) ? 2 : 1));
        }

        protected virtual int GetMoney()
        {
            return Player.Main.Money;
        }
    }
}
