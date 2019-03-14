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
            { ButtonType.QUIT, new ActionEvent(new System.Action<int[]>(Menu.Exit), new int[]{})},
            { ButtonType.MONEY, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.PLACE, (int) LocationType.LIVINGROOM }) },
            { ButtonType.SAVE, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.PLACE, (int) LocationType.LIVINGROOM }) },
            { ButtonType.INVENTORY, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.PLACE, (int) LocationType.LIVINGROOM }) },

            { ButtonType.TALK, new ActionEvent(new System.Action<int[]>(Actions.Talk), WaifuManager.Main.GetEnities()) },
            { ButtonType.LEAVE, new ActionEvent(new System.Action<int[]>(Actions.Leave), new int[]{}) },

            //Should not be there!!
            { ButtonType.FORWARD, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move), new int[]{ 0 }) },
            { ButtonType.RIGHT, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move), new int[]{ 1 }) },
            { ButtonType.BACK, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move), new int[]{ 2 }) },
            { ButtonType.LEFT, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move), new int[]{ 3 }) },
            { ButtonType.TURNRIGHT, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move), new int[]{ 5 }) },
            { ButtonType.TURNLEFT, new ActionEvent(new System.Action<int[]>(DungeonCrawler.Player.Main.Move), new int[]{ 4 }) },
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
            },
            //PLAYERINFO
            {
                MenuType.PLAYERINFO,
                new ButtonType[]
                {
                    ButtonType.MONEY,
                    ButtonType.SAVE,
                    ButtonType.INVENTORY
                }
            },
            //DC Navigation
            {
                MenuType.DUNGEONCRAWLERNAVIGATION,
                new ButtonType[]
                {
                    ButtonType.FORWARD,
                    ButtonType.RIGHT,
                    ButtonType.BACK,
                    ButtonType.LEFT,
                    ButtonType.TURNRIGHT,
                    ButtonType.TURNLEFT
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
                    new Rectangle(2020, 1120, 200, 160),
                    new Rectangle(2380, 1160, 200, 160),
                    new Rectangle(2740, 1200, 200, 160),
                    new Rectangle(1920, 1380, 200, 160),
                    new Rectangle(2280, 1420, 200, 160),
                    new Rectangle(2640, 1500, 200, 160)
                }
            },
            //Loadgame
            {
                MenuType.LOADSAVEGAME,
                new Rectangle[]
                {

                }
            },
            //PlayerInfo
            {
                MenuType.PLAYERINFO,
                new Rectangle[]
                {
                    new Rectangle(3380, 145, 120, 95),
                    new Rectangle(3520, 145, 80, 95),
                    new Rectangle(3618, 145, 120, 95)
                }
            },
            // DC Navigation
            {
                MenuType.DUNGEONCRAWLERNAVIGATION,
                new Rectangle[]
                {
                    new Rectangle(1880, 1890, 80, 80),
                    new Rectangle(1970, 1980, 80, 80),
                    new Rectangle(1880, 2070, 80, 80),
                    new Rectangle(1790, 1980, 80, 80),
                    new Rectangle(1970, 1890, 80, 80),
                    new Rectangle(1790, 1890, 80, 80)
                }
            }

        };

        /// <summary>
        /// Maps ActionTypes to Actions.
        /// </summary>
        public static Dictionary<ActionType, ActionEvent> ActionButtonMap { get; } = new Dictionary<ActionType, ActionEvent>()
        {

        };

        public static Dictionary<LocationType, ButtonType[]> LocationButtonMap { get; } = new Dictionary<LocationType, ButtonType[]>
        {
            {
                LocationType.LIVINGROOM,
                new ButtonType[]
                {
                    ButtonType.TALK,
                    ButtonType.LEAVE,
                }
            },
        };

        /// <summary>
        /// Maps DialogueEntityNames to SceneTypes.
        /// </summary>
        public static Dictionary<DialogueEntityName, SceneType> SceneMap { get; } = new Dictionary<DialogueEntityName, SceneType>()
        {
            
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

                "Sprites/UI/PLAYERINFO",
                "Sprites/UI/MONEY",
                "Sprites/UI/SAVE",
                "Sprites/UI/INVENTORY",
                "Sprites/UI/TALK",
                "Sprites/UI/LEAVE"


            },
            //DungeonCrawler UI
            new string[]
            {
                "Sprites/DC/UI/FORWARD",
                "Sprites/DC/UI/RIGHT",
                "Sprites/DC/UI/BACK",
                "Sprites/DC/UI/LEFT",
                "Sprites/DC/UI/TURNLEFT",
                "Sprites/DC/UI/TURNRIGHT"
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
                "",
                "Sprites/Poprica/LIVINGROOM"
            },
            //Poses
            new string[]
            {
                "NORMAL"
            },
            //Moods
            new string[]  //every Waifu must have same amount of Moods!! nicht so geil :D
            {
                "NORMAL",
                "HAPPY",
                "ANGRY",
                "BLUSH",
                "SURPRISED",
                "SAD"
            },
            //Clothes
            new string[]   //every Waifu must have same amount of Clothes!! nicht so geil :D
            {
                "BRABLACKT",
                "BRADARKRED",
                "BRARED",
                "PANTSBLACKT",
                "PANTSRED",
                "PANTSDARKRED",
                "TANGABLACKT",
                "TANGADARKRED",
                "TANGARED",
                "DRESSBLUE",
                "DRESSRUINED",
                "DRESSWHITE",
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
            { PositionType.RIGHT, new Rectangle(2800, 300, 520, 2000)},
            { PositionType.MIDDLERIGHT, new Rectangle(2500, 300, 520, 2000)},
            { PositionType.MIDDLE, new Rectangle(2200, 300, 520, 2000)},
            { PositionType.MIDDLELEFT, new Rectangle(1900, 300, 520, 2000)},
            { PositionType.LEFT, new Rectangle(1600, 300, 520, 2000)}
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

        //Just for Debug purposes
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
                { Keys.Escape, new ActionEvent(new System.Action<int[]>(Menu.LoadNewScene), new int[]{(int)SceneType.MENU, (int)MenuType.MAINMENU})},
                { Keys.F, new ActionEvent(new System.Action<int[]>(WaifuManager.Main.GetWaifu(DialogueEntityName.RICA).SetMood), new int[]{(int)MoodType.HAPPY}) },
                { Keys.T, new ActionEvent(new System.Action<int[]>(WaifuManager.Main.GetWaifu(DialogueEntityName.RICA).SetClothes), new int[]{}) }

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
            {DungeonCrawler.EventType.RICA, new Point(580, 2160)},
            {DungeonCrawler.BasicItemType.KEY, new Point(60, 60)},
            {DungeonCrawler.EventType.CHEST, new Point(800, 620) }
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

        public static bool TryGetImage(this string[][] images, ImageType imgType, int type, string waifuName, out string value)
        {
            value = default(string);

            if ((int) imgType < images.Length && imgType >= 0)
            {
                if (type < images[(int) imgType].Length && type >= 0)
                {
                    if (imgType == ImageType.POSES)
                        value = "Sprites/Poprica/" + waifuName + "/Poses/" + images[(int)imgType][type];
                    else if (imgType == ImageType.MOOD)
                        value = "Sprites/Poprica/" + waifuName + "/Moods/" + images[(int)imgType][type];
                    else if (imgType == ImageType.CLOTHES)
                        value = "Sprites/Poprica/" + waifuName + "/Clothes/" + images[(int)imgType][type];
                    else
                        value = images[(int)imgType][type];

                    return true;
                }
            }

            return false;
        }
    }
}
