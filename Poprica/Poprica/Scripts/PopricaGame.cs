using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Poprica
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class PopricaGame : Game
    {
        #region Singleton
        private static PopricaGame main;

        public static PopricaGame Main
        {
            get
            {
                if (main == null)
                {
                    main = new PopricaGame();
                }
                return main;
            }
        }
        #endregion

        GraphicsDeviceManager graphics;
        //ResizeStatus resizing;
        
        /// <summary>
        /// The State of the Game.
        /// </summary>
        public static GameState MainState { get; set; }

        public static int maxGameHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public static int maxGameWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        public int gameHeight { get { return Window.ClientBounds.Height; } }
        public int gameWidth { get { return Window.ClientBounds.Width; } }
        
        public PopricaGame()
        {
            main = this;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Window.AllowUserResizing = true;

            this.IsMouseVisible = true;
            

            //set costum cursor
            Texture2D mouseTexture = Content.Load<Texture2D>("Sprites/UI/CURSOR");
            Mouse.SetCursor(MouseCursor.FromTexture2D(mouseTexture, 2, 2));

            MainState = GameState.DEFAULT;

            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.ApplyChanges();

            DebugInit();

            base.Initialize();
        }

        private void DebugInit()
        {
            SceneManager.Main.LoadScene(SceneType.MENU, (int)MenuType.MAINMENU);

            WaifuManager.Main.UnlockWaifu(DialogueEntityName.RICA);
            WaifuManager.Main.SelectedWaifu = DialogueEntityName.RICA;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch spriteBatch = new SpriteBatch(this.GraphicsDevice);

            //Give Spritebatch and ContentManager to RessourceManager
            RessourceManager.Main.Init(this.Content, spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Window.ClientSizeChanged += UpdateAllImageSizes;

            //Debug Purposes Only
            //ToDo: delete
            DialogueManager.Main.LoadNewDialogue(new DialogueEntityName[] { DialogueEntityName.RICA }, ActionType.TALK);

            switch (PopricaGame.MainState)
            {
                case GameState.DEFAULT:
                    //Start the Frame
                    RessourceManager.Main.Start();

                    //Check for input and call methods from there
                    InputManager.Main.CheckInput();

                    //Update Animations
                    AnimationManager.Main.Update(gameTime);

                    //Update Scene
                    SceneManager.Main.CurrentScene.Update();

                    //Render Scene
                    SceneManager.Main.RenderScene();

                    //End Frame
                    RessourceManager.Main.End();
                    break;
                case GameState.EXIT:
                    this.Exit();
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public Vector2 CalcCurrentScale()
        {
            try
            {
                return new Vector2((float)gameWidth / (float)maxGameWidth, (float)gameHeight / (float)maxGameHeight);
            }
            catch
            {
                return Vector2.One;
            }
        }

        private void UpdateAllImageSizes(object sender, EventArgs e)
        {
            //Console.WriteLine("ICH ÄNDERE MEINE GRÖSSSEEEEEEE!!!!");
        }
    }
}
