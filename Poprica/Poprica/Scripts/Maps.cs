﻿using System;
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
        public static Dictionary<Button, Action> ButtonMap { get; } = new Dictionary<Button, Action>()
        {

        };

        /// <summary>
        /// Maps DialogueEntityNames to SceneTypes.
        /// </summary>
        public static Dictionary<DialogueEntityName, SceneType> sceneMap { get; } = new Dictionary<DialogueEntityName, SceneType>()
        {

        };

        /// <summary>
        /// Maps MenuTypes to ButtonsTypes.
        /// </summary>
        public static Dictionary<MenuType, ButtonType> menuButtonMap { get; } = new Dictionary<MenuType, ButtonType>()
        {

        };

        #region Poprica

        /// <summary>
        /// Maps LocationNames to DialogueEntityNames.
        /// </summary>
        public static Dictionary<LocationName, DialogueEntityName[]> NSCLocationMap { get; } = new Dictionary<LocationName, DialogueEntityName[]>()
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
        public static Dictionary<SoundType, string> DungeonCrawler { get; } = new Dictionary<SoundType, string>()
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