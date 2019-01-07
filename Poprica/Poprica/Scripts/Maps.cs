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
        public static Dictionary<ButtonType, System.Action> ButtonMap { get; } = new Dictionary<ButtonType, System.Action>()
        {
            { ButtonType.STARTGAME, new System.Action(Menu.LoadPoprica)},
            { ButtonType.STARTDUNGEONCRAWLER, new System.Action(Menu.LoadDungeonCrawler)},
            { ButtonType.EXIT, new System.Action(Menu.Exit)}
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
            //Poprica
            new string[]
            {
                "Sprites/UI/UIButton",
            },
            //DungeonCrawler
            new string[]
            {

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


        //Wiklich nötig?!?!?!?!?!

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
