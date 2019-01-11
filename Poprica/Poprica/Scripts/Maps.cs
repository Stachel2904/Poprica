using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Poprica
{
    public static class Maps
    {
        /// <summary>
        /// Maps Buttons to Actions.
        /// </summary>
        public static Dictionary<ButtonType, ActionEvent> ButtonMap { get; } = new Dictionary<ButtonType, ActionEvent>()
        {
            { ButtonType.STARTGAME, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.PLACE, (int) LocationType.LIVINGROOM })},
            { ButtonType.STARTDUNGEONCRAWLER, new ActionEvent( new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.DUNGEONCRAWLER})},
            { ButtonType.EXIT, new ActionEvent(new System.Action<int[]>(Menu.Exit), new int[]{})}
        };

        /// <summary>
        /// Maps DialogueEntityNames to SceneTypes.
        /// </summary>
        public static Dictionary<DialogueEntityName, SceneType> SceneMap { get; } = new Dictionary<DialogueEntityName, SceneType>()
        {
            
        };

        /// <summary>
        /// Maps MenuTypes to ButtonsTypes.
        /// </summary>
        public static Dictionary<MenuType, ButtonType[]> MenuButtonMap { get; } = new Dictionary<MenuType, ButtonType[]>()
        {
            //Main Menu
            {
                MenuType.MAINMENU,
                new ButtonType[]
                {
                    ButtonType.STARTGAME,
                    ButtonType.STARTDUNGEONCRAWLER,
                    ButtonType.EXIT
                }
            }
        };

        /// <summary>
        /// Maps string in 2D-array Minigame as x-Axis and ImageType as y-Axis  
        /// </summary>
        public static string[][] ImageMap { get; } = new string[][]
        {
            //UI
            new string[]
            {
                "Sprites/UI/UIButton",
            },
            //Icons
            new string[]
            {

            },
            //Backgrounds
            new string[]
            {
                "Sprites/Poprica/LIVINGROOM"
            },
            //Waifus
            new string[]
            {
                
            },
            //DungeonCrawler
            new string[]
            {
                "Sprites/DC/WALL",
                "Sprites/DC/STRAIGHT",
                "Sprites/DC/RIGHTTURN",
                "Sprites/DC/LEFTTURN",
                "Sprites/DC/TCROSS",
                "Sprites/DC/INTERSECTION",
                "Sprites/DC/ENTRY",

                "Sprites/DC/STRAIGHTSIGN",
                "Sprites/DC/RIGHTTURN",   //have to be changed to RIGHTTURNSIGN
                "Sprites/DC/LEFTTURN",    //have to be changed to LEFTTURNSIGN
                "Sprites/DC/TCROSSSIGNMAIN",

                "Sprites/DC/CONSTRUCTIONSIGN",
                "Sprites/DC/ROOM",
                "Sprites/DC/ROOMLEFT",
                "Sprites/DC/ROOMRIGHT",
                "Sprites/DC/PRISONERROOM",


                "Sprites/DC/TCROSSMAIN",
                "Sprites/DC/TCROSSRIGHT",
                "Sprites/DC/TCROSSLEFT"
            }
        };

        /// <summary>
        /// Stores the Text on a Button
        /// </summary>
        public static string[] MenuButtonText = new string[]
        {
            "Start Poprica",
            "Start Dungeon Crawler",
            "Exit"
        };

        /// <summary>
        /// Stores the paths to different Size of Fonts
        /// </summary>
        public static string[] Fonts = new string[]
        {
            "FontSmall",
            "FontDefault",
            "FontBig"
        };

        #region Poprica

        /// <summary>
        /// Maps LocationTypes to DialogueEntityNames.
        /// </summary>
        public static Dictionary<LocationType, DialogueEntityName[]> NSCLocationMap { get; } = new Dictionary<LocationType, DialogueEntityName[]>()
        {

        };

        public static Dictionary<Keys, ActionEvent>[] InputMaps { get; } = new Dictionary<Keys, ActionEvent>[]
        {
            //Place Input
            new Dictionary<Keys, ActionEvent>
            {
                { Keys.Escape, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.MAINMENU})}
            },

            //Menu Input
            new Dictionary<Keys, ActionEvent>
            {
                { Keys.Escape, new ActionEvent(new System.Action<int[]>(Menu.Exit), new int[]{})}
            },

            //Shop Input
            new Dictionary<Keys, ActionEvent>
            {
                { Keys.Escape, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.MAINMENU})}
            },

            //DungeonCrawler Input
            new Dictionary<Keys, ActionEvent>
            {
                { Keys.Escape, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.MAINMENU})},
                { Keys.W, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.FORWARD)})},
                { Keys.A, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.TURNLEFT)})},
                { Keys.S, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.BACKWARD)})},
                { Keys.D, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.TURNRIGHT)})},
                { Keys.Q, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.LEFT)})},
                { Keys.E, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.RIGHT)})}
            }
        };

        /// <summary>
        /// Maps InputTypes to Keys.
        /// </summary>
        public static Dictionary<InputType, Keys> PopricaInputMap { get; } = new Dictionary<InputType, Keys>()
        {

        };

        /// <summary>
        /// Maps SoundTypes to strings.
        /// </summary>
        public static Dictionary<SoundType, string> PopricaSoundMap { get; } = new Dictionary<SoundType, string>()
        {

        };

        /// <summary>
        /// Maps MusicTypes to strings.
        /// </summary>
        public static Dictionary<MusicType, string> PopricaMusicMap { get; } = new Dictionary<MusicType, string>()
        {

        };

        /// <summary>
        /// Maps Voices through DialogueEntityNames (x-axis) and VoiceTypes (y-axis) in 2D-array.
        /// </summary>
        public static string[,] PopricaVoiceMap { get; } = new string[,]
        {
            {
                
            },
            {

            }
        };

        

        /// <summary>
        /// Maps AnimationTypes to Animations.
        /// </summary>
        public static Dictionary<AnimationType, Animation> PopricaAnimationMap { get; } = new Dictionary<AnimationType, Animation>()
        {

        };

        public static string[] PopricaSpriteSheetPaths { get; }  //nötig?!?!?!

        #endregion

        #region DungeonCrawler

        //Keine Info über Input der nichts mit Movement zutun hat ...
    
        /// <summary>
        /// Maps Keys to InputType.
        /// </summary>
        public static Dictionary<Keys, DungeonCrawler.DirectionType> DungeonCrawlerInputMap { get; } = new Dictionary<Keys, DungeonCrawler.DirectionType>()
        {
            {Keys.W, DungeonCrawler.DirectionType.FORWARD },
            {Keys.S, DungeonCrawler.DirectionType.BACKWARD },
            {Keys.D, DungeonCrawler.DirectionType.RIGHT },
            {Keys.A, DungeonCrawler.DirectionType.LEFT },
            {Keys.E, DungeonCrawler.DirectionType.TURNRIGHT },
            {Keys.Q, DungeonCrawler.DirectionType.TURNLEFT }
        };

        /// <summary>
        /// Maps SoundTypes to strings.
        /// </summary>
        public static Dictionary<SoundType, string> DungeonCrawlerSoundMap { get; } = new Dictionary<SoundType, string>()
        {

        };

        /// <summary>
        /// Maps AnimationTypes to Animations.
        /// </summary>
        public static Dictionary<AnimationType, Animation> DungeonCrawlerAnimationMap { get; } = new Dictionary<AnimationType, Animation>()
        {

        };

        /// <summary>
        /// Maps MusicTypes to strings.
        /// </summary>
        public static Dictionary<MusicType, string> DungeonCrawlerMusicMap { get; } = new Dictionary<MusicType, string>()
        {

        };

        #endregion


    }
}
