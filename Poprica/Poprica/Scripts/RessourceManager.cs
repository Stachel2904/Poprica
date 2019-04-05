using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
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
        private Dictionary<string, Texture2D> cachedTextures;
        private SpriteFont[] fonts;

        /// <summary>
        /// You can access all ressources from here.
        /// </summary>
        public ContentManager Ressources { get; private set; }

        private RessourceManager()
        {
            cachedTextures = new Dictionary<string, Texture2D>();            
        }

        public void Init(ContentManager _ressources, SpriteBatch _renderer)
        {
            Ressources = _ressources;
            renderer = _renderer;
            fonts = new SpriteFont[]
            {
                Ressources.Load<SpriteFont>("Font/FontSmall"),
                Ressources.Load<SpriteFont>("Font/FontDefault"),
                Ressources.Load<SpriteFont>("Font/FontBig")
            };
        }

        /// <summary>
        /// Start rendering process for this frame.
        /// </summary>
        public void Start()
        {
            if (renderer.IsDisposed)
            {
                renderer.End();
            }

            renderer.GraphicsDevice.Clear(Color.White);
            renderer.Begin();
        }

        /// <summary> 
        /// Add ressource to draw in this frame.
        /// </summary>
        /// <param name="path">The path to the ressource.</param>
        /// <param name="destinationRect">The position and dimensions for the ressource.</param>
        /// <param name="sourceRect">The position and dimensions of the Texture inside the sourceimage. Set null to render the full sourceimage.</param>
        /// <param name="color">Color multiplied with the sprite. Use Color.White to maintain the real Color.</param>
        /// <param name="rotation">Rotation of the sprite. 0 by default.</param>
        /// <param name="scale">Scale of the sprite. 0 by default.</param>
        /// <param name="flipped">Set true to flip the Sprite.</param>
        public void Draw(string path, Rectangle destinationRect, Rectangle? sourceRect, Color color, float rotation = 0, float scale = 0, bool flipped = false)
        {
            Texture2D renderedTexture;

            if (cachedTextures.ContainsKey(path))
            {
                renderedTexture = cachedTextures[path];
            }
            else
            {
                renderedTexture = Ressources.Load<Texture2D>(path);
                cachedTextures.Add(path, renderedTexture);
            }

            //just for debug, Image sizes shouldn't get calculated in every frame
            Rectangle newRect = new Rectangle(destinationRect.Location.X, destinationRect.Location.Y, (int) (destinationRect.Size.X * PopricaGame.Main.CalcCurrentScale().X), (int) (destinationRect.Size.Y * PopricaGame.Main.CalcCurrentScale().Y));

            renderer.Draw(renderedTexture, newRect, sourceRect, color, rotation, Vector2.Zero, (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
        }

        public void DrawText(TextObject text, bool verticalCenter = true, bool horizontalCenter = true)
        {
            Vector2 addedPos = new Vector2();
            Vector2 dimensions = fonts[text.Size].MeasureString(text.Text);

            if (verticalCenter)
            {
                addedPos.Y = (text.Rect.Height / 2) - (dimensions.Y / 2);
            }
            if (horizontalCenter)
            {
                addedPos.X = (text.Rect.Width / 2) - (dimensions.X / 2);
            }

            renderer.DrawString(fonts[text.Size], text.Text, text.Rect.Location.ToVector2() + addedPos, text.color);
        }

        /// <summary>
        /// End rendering process and print the frame.
        /// </summary>
        public void End()
        {
            renderer.End();
        }

        /// <summary>
        /// Removes the Cache of Textures.
        /// </summary>
        public void UnloadCache()
        {
            cachedTextures = new Dictionary<string, Texture2D>();
        }
    }
}