using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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
            { ButtonType.PLAY, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.PLACE, (int) LocationType.LIVINGROOM })},
            //{ ButtonType.STARTDUNGEONCRAWLER, new ActionEvent( new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.DUNGEONCRAWLER})},
            { ButtonType.LOAD, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.LOADSAVEGAME})},
            { ButtonType.OPTIONS, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.OPTIONS})},
            { ButtonType.PATREON, new ActionEvent( new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.DUNGEONCRAWLER}) },//new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.OPTIONS})}, //insert Funkt for Website
            { ButtonType.HELP, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.HELP})},
            { ButtonType.QUIT, new ActionEvent(new System.Action<int[]>(Menu.Exit), new int[]{})}
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
                    ButtonType.PLAY,
                    ButtonType.LOAD,
                    ButtonType.OPTIONS,
                    ButtonType.HELP,
                    ButtonType.PATREON,
                    ButtonType.QUIT
                }
            },
            //LOADGAME
            {
                MenuType.LOADSAVEGAME,
                new ButtonType[]
                {

                }
            }
        };

        public static Dictionary<MenuType, Rectangle[]> MenuButtonRects { get; } = new Dictionary<MenuType, Rectangle[]>()
        {
            //MainMenu
            {
                MenuType.MAINMENU,
                new Rectangle[]
                {
                    new Rectangle(1010, 560, 100, 80),
                    new Rectangle(1190, 580, 100, 80),
                    new Rectangle(1370, 600, 100, 80),
                    new Rectangle(960, 690, 100, 80),
                    new Rectangle(1140, 720, 100, 80),
                    new Rectangle(1320, 750, 100, 80)
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
                "Sprites/UI/PLAY",
                "Sprites/UI/LOAD",
                "Sprites/UI/OPTIONS",
                "Sprites/UI/HELP",
                "Sprites/UI/PATREON",
                "Sprites/UI/QUIT",
            },
            //Menu
            new String[]
            {
                "Sprites/UI/MAINMENU",
                //PAUSEMENU
                //LOADSAVEGAME
                //OPTIONS
                //HELP
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
                "",
                "Sprites/Poprica/RICA"
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
                "Sprites/DC/STRAIGHT",

                "Sprites/DC/STRAIGHTSIGN",
                "Sprites/DC/RIGHTTURN",   //have to be changed to RIGHTTURNSIGN
                "Sprites/DC/LEFTTURN",    //have to be changed to LEFTTURNSIGN
                "Sprites/DC/TCROSSSIGNMAINLEFT",

                "Sprites/DC/CONSTRUCTIONSIGN",
                "Sprites/DC/ROOM",
                "Sprites/DC/ROOMWALL",
                "Sprites/DC/ROOMRIGHTCORNER",
                "Sprites/DC/ROOMEXIT",
                "Sprites/DC/PRISONERROOM",


                "Sprites/DC/TCROSSMAIN",
                "Sprites/DC/TCROSSRIGHT",
                "Sprites/DC/TCROSSLEFT",

                
                "Sprites/DC/ROOMRIGHT",
                "Sprites/DC/ROOMLEFT",
                "Sprites/DC/ROOMRIGHTPERSPECTIVE",
                "Sprites/DC/ROOMLEFTPERSPECTIVE",
                "Sprites/DC/ROOMLEFTCORNER",
                "Sprites/DC/CORNERLEFTPERSPECTIVE",
                "Sprites/DC/CORNERRIGHTPERSPECTIVE",

                "Sprites/DC/KEY",
                "Sprites/DC/RICA",
                "Sprites/DC/CHEST"
            }
        };

        

        public static Dictionary<PositionType, Rectangle> DialogueEntityPositions { get; } = new Dictionary<PositionType, Rectangle>
        {
            { PositionType.RIGHT, new Rectangle(1500, 0, 500, 1000)}
        };

        /// <summary>
        /// Stores the Text on a Button
        /// </summary>
        public static string[] MenuButtonText { get; } = new string[]
        {
            "Start",
            "Load",
            "Options",
            "Help",
            "Patreon",
            "Quit"
        };

        /// <summary>
        /// Stores the paths to different Size of Fonts
        /// </summary>
        public static string[] Fonts { get; } = new string[]
        {
            "FontSmall",
            "FontDefault",
            "FontBig"
        };

        public static Dictionary<dynamic, double> ImageScale { get; } = new Dictionary<dynamic, double>
        {
            {DungeonCrawler.ImageType.RICA, 0.6},
            {DungeonCrawler.ImageType.CHEST, 1.2},
            {DungeonCrawler.ImageType.KEY, 3}
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
                { Keys.E, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move),new int[]{((int)DungeonCrawler.DirectionType.RIGHT)})},
                { Keys.F, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Inventory.Main.UseItem), null)}
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
        
        public static Dictionary<dynamic, Point> DCImageSizes { get; } = new Dictionary<dynamic, Point>
        {
            {DungeonCrawler.EventType.RICA, new Point(290, 1080)},
            {DungeonCrawler.BasicItemType.KEY, new Point(30, 30)},
            {DungeonCrawler.EventType.CHEST, new Point(400,310) }
        };

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

    public static class Extension
    {
        /// <summary>
        /// Tries to find the value with given index in abstract datastructure.
        /// Possible total nonsense ... :D
        /// </summary>
        /// <typeparam name="T">Generic type parameter for datastructure.</typeparam>
        /// <param name="dataStructure">Input datasurcture.</param>
        /// <param name="index">Index to search for.</param>
        /// <param name="value">Out variable, which hold value of dstastructure.</param>
        /// <returns>Returns true if element was found.</returns>
        public static bool TryGetValue<T>(this T dataStructure, dynamic index, out dynamic value)
        {

            Console.WriteLine("ddd");

            value = default(dynamic);
            
            if (dataStructure.GetType() == typeof(string[]))
            {
                string[] array = dataStructure as string[];

                if (index < array.Length && index >= 0)
                {
                    value = array[index];
                    return true;
                }
            }
            else if (dataStructure.GetType() == typeof(Dictionary<object, object>))
            {
                Dictionary<dynamic, dynamic> dict = dataStructure as Dictionary<dynamic, dynamic>;

                if (dict.ContainsKey(index))
                {
                    value = dict[index];
                    return true;
                } 
            }
            else if (dataStructure.GetType() == typeof(Dictionary<Type , double>))
            {
                Dictionary<dynamic, dynamic> dict = dataStructure as Dictionary<dynamic, dynamic>;
                
                if (dict.ContainsKey(index))
                {
                    value = dict[index];
                    return true;
                }
            }

            return false;
        }
    }
}
