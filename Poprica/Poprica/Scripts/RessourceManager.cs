using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public sealed class RessourceManager
    {
        #region Singleton
        private static RessourceManager main;

        public static RessourceManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new RessourceManager();
                }
                return main;
            }
        }
        #endregion

        private SpriteBatch renderer;

        /// <summary>
        /// You can access all ressources from here.
        /// </summary>
        public GraphicsDeviceManager Ressources { get; private set; }

        private RessourceManager()
        {

        }

        public void Init(GraphicsDeviceManager _ressources, SpriteBatch _renderer)
        {
            Ressources = _ressources;
            renderer = _renderer;
        }

        /// <summary>
        /// Start rendering process for this frame.
        /// </summary>
        public void Start()
        {

        }

        /// <summary>
        /// Add ressource to draw in this frame.
        /// </summary>
        /// <param name="path">The path to the ressource.</param>
        /// <param name="rect">The position and dimensions for the ressource.</param>
        public void Draw(string path, Rectangle rect)
        {

        }

        /// <summary>
        /// End rendering process and print the frame.
        /// </summary>
        public void End()
        {

        }
    }
}
