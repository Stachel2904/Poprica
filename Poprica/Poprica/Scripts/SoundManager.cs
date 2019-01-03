using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class SoundManager
    {
        #region Singleton
        private static SoundManager main;

        public static SoundManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new SoundManager();
                }
                return main;
            }
        }
        #endregion

        /// <summary>
        /// Get the current played background music.
        /// </summary>
        public MusicType Music { get; }

        private SoundManager()
        {

        }

        /// <summary>
        /// Plays a specific sound.
        /// </summary>
        /// <param name="sound">The sound to be played.</param>
        public void PlaySound(SoundType sound)
        {

        }

        /// <summary>
        /// Stops all currently played sounds.
        /// </summary>
        public void StopAllSounds()
        {

        }

        /// <summary>
        /// Play new background music.
        /// </summary>
        /// <param name="newMusic">The new music.</param>
        /// <param name="fade">The seconds of the fade effect.</param>
        public void ChangeMusic(MusicType newMusic, float fade = 0.5f)
        {

        }

        /// <summary>
        /// Stops the current played music.
        /// </summary>
        public void StopAllMusic()
        {

        }

        /// <summary>
        /// Start playing a voice.
        /// </summary>
        /// <param name="voice">The type of the voice the speaker emits.</param>
        /// <param name="speaker">The speaker, that emits the voice.</param>
        public void PlayVoice(VoiceType voice, DialogueEntityName speaker)
        {

        }

        /// <summary>
        /// Stop all voices.
        /// </summary>
        public void StopAllVoice()
        {

        }
    }
}
