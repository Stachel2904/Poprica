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
            { MenuType.MAINMENU, new ButtonType[]{ ButtonType.EXIT} }
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
        /// Maps PopricaImageTypes to their save path (string)
        /// </summary>
        public static Dictionary<ImageType, string> PopricaImageMap { get; } = new Dictionary<ImageType, string>()
        {
            { ImageType.BUTTON, "Sprites/UI/UIButton" }
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

        /// <summary>
        /// Maps InputTypes to Keys.
        /// </summary>
        public static Dictionary<InputType, Keys> DungeonCrawlerInputMap { get; } = new Dictionary<InputType, Keys>()
        {

        };

        /// <summary>
        /// Maps SoundTypes to strings.
        /// </summary>
        public static Dictionary<SoundType, string> DungeonCrawlerSoundMap { get; } = new Dictionary<SoundType, string>()
        {

        };

        /// <summary>
        /// Maps DungeonCrawlerImageTypes to their save path (string)
        /// </summary>
        public static Dictionary<DungeonCrawler.ImageType, string> DungeonCrawlerImageMap { get; } = new Dictionary<DungeonCrawler.ImageType, string>()
        {
            { DungeonCrawler.ImageType.STRAIGHT, "" },
            { DungeonCrawler.ImageType.RIGHTTURN, "" },
            { DungeonCrawler.ImageType.LEFTTURN, "" },
            { DungeonCrawler.ImageType.TCROSS, "" },
            { DungeonCrawler.ImageType.INTERSECTION, "" },
            { DungeonCrawler.ImageType.ENTRY, "" },
            { DungeonCrawler.ImageType.PRISONERROOM, "" },
            { DungeonCrawler.ImageType.CONSTRUCTIONSIGN, "" }
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
