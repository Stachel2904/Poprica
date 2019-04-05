using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static DungeonCrawler.Tile;

namespace DungeonCrawler
{
    public sealed class DungeonCrawler : Poprica.MiniGame
    {

        /// <summary>
        /// Holds the state of the DungeonCrawler game.
        /// </summary>
        public GameStateType State { get; set; }

        /// <summary>
        /// Bib for all DC images.
        /// </summary>
        private Poprica.Image[] AllImages { get; set; }
        
        public DungeonCrawler() : base(Poprica.SceneType.DUNGEONCRAWLER)
        {
            AllImages = new Poprica.Image[Poprica.Maps.ImageMap[(int)Poprica.ImageType.DUNGEONCRAWLER].Count()];

            InitImages();
        }

        /// <summary>
        /// Loads all Images of the DungeonCrawler.
        /// </summary>
        private void InitImages()
        {
            Poprica.Image img;
            Rectangle rect = new Rectangle(Point.Zero, Point.Zero);

            for(int i = 0; i < Poprica.Maps.ImageMap[(int)Poprica.ImageType.DUNGEONCRAWLER].Count(); i++)
            {
                img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, i, rect);
                AllImages[i] = img;
            }
        }

        /// <summary>
        /// Loads Images which should be displayed.
        /// </summary>
        public override void LoadImages()
        {
            base.LoadImages();

            Vector3 playerPos = Player.Main.Location;
            Vector3 orientation = Player.Main.Rotation;
            
            for (int i = 6; i >= 0; i--)
            {
                Tile current = null;
                Tile[] currentRow = null;
                
                if (!Dungeon.Main.Floor.Tiles.TryGetTiles((int)(playerPos.Y + orientation.Y * (i+1)), out currentRow))
                {
                    continue;
                }

                if (!currentRow.TryGetTile((int)(playerPos.X + orientation.X * (i+1)), out current))
                {
                    continue;
                }

                Poprica.Image img;
                Rectangle rect = new Rectangle(Poprica.MathFunctions.ImagePos(i), new Point((int)(width / (Math.Pow(2, i))), (int)(height / (Math.Pow(2, i)))));

                //If wall is in front of the player ... stops seeing Tiles behind the wall
                if (!Player.Main.Allowed(DirectionType.FORWARD)) //&& GetTileInFront(entryPoint, orientation) != )
                {
                    rect = new Rectangle(Poprica.MathFunctions.ImagePos(0), new Point((int)(width / (Math.Pow(2, 0))), (int)(height / (Math.Pow(2, 0)))));

                    //Abfrage ob Img nicht vllt ConstructionSign sein sollte
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.NONE, rect);
                    this.Images.Add(img);

                    break;
                }

                if (current.Type == TileType.STRAIGHT && (current.Orientation == orientation || current.Orientation == -orientation))
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.STRAIGHT, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.INTERSECTION)
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.INTERSECTION, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.TURN)
                {
                    int imageNum = 0;

                    if (orientation == current.Orientation)
                    {
                        imageNum = (int)ImageType.RIGHTTURN;
                    }
                    else
                    {
                        imageNum = (int)ImageType.LEFTTURN;
                    }

                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imageNum, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.TCROSS && current.Orientation != orientation)
                {
                    int imageNum = 0;

                    if (orientation + current.Orientation == Vector3.Zero)
                    {
                        imageNum = (int) ImageType.TRCOSSMAIN;
                    }
                    else
                    {
                        imageNum = GetTcrossImageFromOrientation(orientation, current.Orientation);
                    }

                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imageNum, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.CONSTRUCTIONSIGN)
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.CONSTRUCTIONSIGN, rect);
                    this.Images.Add(img);
                }
                else if ((int) current.Type > (int)TileType.CONSTRUCTIONSIGN)
                {
                    AddImageField(new Vector2(playerPos.X + orientation.X * i, playerPos.Y + orientation.X * i), i, current);
                }
                else
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)current.Type, rect);
                    this.Images.Add(img);
                    //this.Images.Add(AllImages[(int)current.Type]);
                }

                CheckTileForAdditionalImage(current, i);//6-i);
            }
        }

        /// <summary>
        /// Adds the DungeonCrawler UI Buttons of navigation, item usage and combatsystem
        /// </summary>
        private void AddMenuButtons()
        {
            Poprica.ButtonType[] menuButtons = Poprica.Maps.MenuButtonMap[Poprica.MenuType.DUNGEONCRAWLERNAVIGATION];
            Poprica.Button[] createdButtons = Poprica.ButtonManager.Main.CreateButtons(menuButtons, Poprica.MenuType.DUNGEONCRAWLERNAVIGATION);

            for (int i = 0; i < createdButtons.Length; i++)
            {
                int imgIndex = (int)((UI)Enum.Parse(typeof(UI), createdButtons[i].Type.ToString()));

                this.Images.Add(new Poprica.Image(Poprica.ImageType.DCUI, imgIndex, createdButtons[i].Rect));
                //this.Texts.Add(new TextObject(Maps.MenuButtonText[(int)createdButtons[i].Type], createdButtons[i].Rect));
            }
        }

        /// <summary>
        /// Adds the DungeonCrawler Buttons for actions, like free Rica, etc.
        /// </summary>
        private void AddActionButtons()
        {
            Tile tile = Dungeon.Main.Floor.GetTile(new Vector2(Player.Main.Location.X, Player.Main.Location.Y));

            //List<Poprica.ButtonType> actionButtons = new List<Poprica.ButtonType>();

            Poprica.Action[] actions = GamePlay.CreateActions(tile.Event);

            Poprica.Button[] createdButtons = Poprica.ButtonManager.Main.CreateButtons(actions);

            for (int i = 0; i < createdButtons.Length; i++)
            {
                int imgIndex = (int)((UI)Enum.Parse(typeof(UI), createdButtons[i].Type.ToString()));

                this.Images.Add(new Poprica.Image(Poprica.ImageType.DCUI, imgIndex, createdButtons[i].Rect));
                //this.Texts.Add(new TextObject(Maps.MenuButtonText[(int)createdButtons[i].Type], createdButtons[i].Rect));
            }
        }

        public override void Update()
        {
            //height = Poprica.PopricaGame.Main.gameHeight;
            //width = Poprica.PopricaGame.Main.gameWidth;

            if (Poprica.TimeManager.Main.DateTime.TimeOfDay >= new TimeSpan(20, 0, 0))
            {
                Player.Main.Location = Dungeon.Main.Floor.DefaultEntryPoint;
                Player.Main.Rotation = new Vector3(0, -1, 0);
            }

            //ToDo
            //if moved or game size changed
            this.LoadImages();

            this.LoadPlayerInfo();

            this.AddMenuButtons();

            this.AddActionButtons();
            
            Player.Main.UpdateInventory();

            Vector3 playerPos = Player.Main.Location;
            Vector3 orientation = Player.Main.Rotation;
            //endif

            Tile current = null;
            Tile[] currentRow = null;

            if (!Dungeon.Main.Floor.Tiles.TryGetTiles((int)(playerPos.Y + orientation.Y), out currentRow))
            {
                if (!currentRow.TryGetTile((int)(playerPos.X + orientation.X), out current))
                {
                    if (current != null)
                        GamePlay.Update(current.Event);
                }
            }
            //GamePlay.Update(Dungeon.Main.Floor.Tiles[(int) (playerPos.Y + Player.Main.Rotation.Y)][(int)(Player.Main.Location.X + Player.Main.Rotation.X)].Event);
        }

        /// <summary>
        /// Adds a field of Images to he Image list. Because morte than one Image is visible.
        /// </summary>
        /// <param name="startPos">Position to start the field calculation.</param>
        /// <param name="step">The iteration step.</param>
        /// <param name="current">Current Tile.</param>
        private void AddImageField(Vector2 startPos, int step, Tile current)
        {
            Vector3 playerRot = Player.Main.Rotation;

            int imgNumLeft = 0, imgNum = 0, imgNumRight = 0;

            Poprica.Image imgLeft, img, imgRight;
            Rectangle rectLeft, rect, rectRight;

            Point pos = Poprica.MathFunctions.ImagePos(step);
            Point size = new Point((int)(width/ (Math.Pow(2, step))), (int)(height / (Math.Pow(2, step))));

            rectLeft = new Rectangle(new Point(pos.X - (int)((width * Poprica.PopricaGame.Main.CalcCurrentScale().X)/ (Math.Pow(2, step))), pos.Y), size);
            rect = new Rectangle(pos, size);
            rectRight = new Rectangle( new Point(pos.X + (int)((width * Poprica.PopricaGame.Main.CalcCurrentScale().X) / (Math.Pow(2, step))), pos.Y), size);

            if (current.Type == TileType.ROOMEXIT)
            {
                //SHIT hier muss noch einiges geändert werden!!
                
                if (current.Orientation == playerRot)
                {
                    imgNumLeft = (int)ImageType.ROOMLEFTCORNER;
                    imgNum = (int)ImageType.ROOMEXIT;
                    imgNumRight = (int)ImageType.ROOMRIGHTCORNER;
                }
                else if ((current.Orientation + playerRot) == Vector3.Zero)
                {
                    imgNumLeft = (int)ImageType.ROOMLEFTPERSPECTIVE;
                    imgNum = (int)ImageType.ROOM;
                    imgNumRight = (int)ImageType.ROOMRIGHTPERSPECTIVE;
                }
                else if (current.Orientation == Vector3.Down)
                {
                    if (playerRot == Vector3.Right)
                    {
                        imgNumLeft = (int)ImageType.ROOMWALL;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)current.Type;
                    }
                    else if (playerRot == Vector3.Left)
                    {
                        imgNumLeft = (int)current.Type;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)ImageType.ROOMWALL;
                    }
                }
                else if (current.Orientation == Vector3.Right)
                {
                    if (playerRot == Vector3.Down)
                    {
                        imgNumLeft = (int)current.Type;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)ImageType.ROOMWALL;
                    }
                    else if (playerRot == Vector3.Up)
                    {
                        imgNumLeft = (int)ImageType.ROOMWALL;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)current.Type;
                    }
                }
                else if (current.Orientation == Vector3.Up)
                {
                    if (playerRot == Vector3.Right)
                    {
                        imgNumLeft = (int)current.Type;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)ImageType.ROOMWALL;
                    }
                    else if (playerRot == Vector3.Left)
                    {
                        imgNumLeft = (int)ImageType.ROOMWALL;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)current.Type;
                    }
                }
                else if (current.Orientation == Vector3.Left)
                {
                    if (playerRot == Vector3.Down)
                    {
                        imgNumLeft = (int)ImageType.ROOMWALL;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)current.Type;
                    }
                    else if (playerRot == Vector3.Up)
                    {
                        imgNumLeft = (int)current.Type;
                        imgNum = (int)ImageType.ROOM;
                        imgNumRight = (int)ImageType.ROOMWALL;
                    }
                }
            }
            else if (current.Type == TileType.ROOM)
            {

            }
            else if (current.Type == TileType.ROOMWALL)
            {
                imgNumLeft = (int)ImageType.CORNERLEFTPERSPECTIVE;
                imgNum = GetImageForRoomWall(playerRot, current.Orientation); // (int)ImageType.CONSTRUCTIONSIGN;
                imgNumRight = (int)ImageType.CORNERRIGHTPERSPECTIVE;
            }
            else if (current.Type == TileType.PRISONERROOM)
            {
                imgNumLeft = (int)ImageType.ROOMLEFTPERSPECTIVE;
                imgNum = (int)ImageType.PRISONERROOM;
                imgNumRight = (int)ImageType.ROOMRIGHTPERSPECTIVE;
            }
            else if (current.Type == TileType.ROOMCORNER)
            {
                imgNum = GetImageForRoomCorner(playerRot, current.Orientation);
            }


            imgLeft = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imgNumLeft, rectLeft);
            img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imgNum, rect);
            imgRight = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imgNumRight, rectRight);

            this.Images.Add(imgLeft);
            this.Images.Add(img);
            this.Images.Add(imgRight);
        }

        /// <summary>
        /// Returns an int, which represents the orientation of the image of the TCross.
        /// </summary>
        /// <param name="player">Vector3 which represents the players rotation.</param>
        /// <param name="tile">Vector3 which represents the tile orientation.</param>
        /// <returns>Index for ImageType enum.</returns>
        private int GetTcrossImageFromOrientation(Vector3 player, Vector3 tile)
        {
            int num = 0;

            if (player == Vector3.Down)
            {
                if (tile == Vector3.Left)
                    num = (int) ImageType.TCROSSLEFT;
                else
                    num = (int) ImageType.TCROSSRIGHT;
            }
            else if (player == Vector3.Right)
            {
                if (tile == Vector3.Up)
                    num = (int)ImageType.TCROSSRIGHT;
                else
                    num = (int)ImageType.TCROSSLEFT;
            }
            else if (player == Vector3.Up)
            {
                if (tile == Vector3.Left)
                    num = (int)ImageType.TCROSSRIGHT;
                else
                    num = (int)ImageType.TCROSSLEFT;
            }
            else if (player == Vector3.Left)
            {
                if (tile == Vector3.Down)
                    num = (int)ImageType.TCROSSRIGHT;
                else
                    num = (int)ImageType.TCROSSLEFT;
            }

            return num;
        }

        /// <summary>
        /// Returns an int, which represents the image of the roomcorner.
        /// </summary>
        /// <param name="player">Vector3 which represents the players rotation.</param>
        /// <param name="tile">Vector3 which represents the tile orientation. </param>
        /// <returns>Index for Image enum.</returns>
        private int GetImageForRoomCorner(Vector3 player, Vector3 tile)
        {
            int imgNum = 0;

            if (tile == Vector3.Down)
            {
                if (player == Vector3.Down)
                    imgNum = (int)ImageType.ROOMLEFTCORNER;
                else if (player == Vector3.Left)
                    imgNum = (int)ImageType.ROOMRIGHTCORNER;
            }
            else if (tile == Vector3.Right)
            {
                if (player == Vector3.Down)
                    imgNum = (int)ImageType.ROOMRIGHTCORNER;
                else if (player == Vector3.Right)
                    imgNum = (int)ImageType.ROOMLEFTCORNER;
            }
            else if (tile == Vector3.Up)
            {
                if (player == Vector3.Right)
                    imgNum = (int)ImageType.ROOMRIGHTCORNER;
                else if (player == Vector3.Up)
                    imgNum = (int)ImageType.ROOMLEFTCORNER;
            }
            else if (tile == Vector3.Left)
            {
                if (player == Vector3.Up)
                    imgNum = (int)ImageType.ROOMRIGHTCORNER;
                else if (player == Vector3.Left)
                    imgNum = (int)ImageType.ROOMLEFTCORNER;
            }

            return imgNum;
        }

        /// <summary>
        /// Returns an int, which represents the image of the roomwall.
        /// </summary>
        /// <param name="player">Vector3 which represents the players rotation.</param>
        /// <param name="tile">Vector3 which represents the tile orientation. </param>
        /// <returns>Index of Image enum.</returns>
        private int GetImageForRoomWall(Vector3 player, Vector3 tile)
        {
            int imgNum = 0;

            if (tile == player)
            {
                imgNum = (int)ImageType.ROOMWALL;
            }
            else if (tile == Vector3.Right)
            {
                if (player == Vector3.Down)
                    imgNum = (int)ImageType.ROOMRIGHT;
                else if (player == Vector3.Up)
                    imgNum = (int)ImageType.ROOMLEFT;
            }
            else if (tile == Vector3.Up)
            {
                if (player == Vector3.Right)
                    imgNum = (int)ImageType.ROOMRIGHT;
                else if (player == Vector3.Left)
                    imgNum = (int)ImageType.ROOMLEFT;
            }
            else if (tile == Vector3.Left)
            {
                if (player == Vector3.Down)
                    imgNum = (int)ImageType.ROOMLEFT;
                else if (player == Vector3.Up)
                    imgNum = (int)ImageType.ROOMRIGHT;
            }
            else if (tile == Vector3.Down)
            {
                if (player == Vector3.Right)
                    imgNum = (int)ImageType.ROOMLEFT;
                else if (player == Vector3.Left)
                    imgNum = (int)ImageType.ROOMRIGHT;
            }

            return imgNum;

        }

        /// <summary>
        /// Puts Images of Events and Items to the images list.
        /// </summary>
        /// <param name="tile">Current Tile of iteration.</param>
        /// <param name="step">Current iteration step.</param>
        private void CheckTileForAdditionalImage(Tile tile, int step)
        {
            EventType type = tile.Event;

            if (type != EventType.NONE)
            {
                Rectangle eventRect = new Rectangle();
                Point size = new Point();

                if (type == EventType.RESCUE || type == EventType.PRISON)
                    return;

                int imgIndex = (int)((ImageType)Enum.Parse(typeof(ImageType), type.ToString()));

                if (Poprica.Maps.DCImageSizes.TryGetValue(type, out size))
                {
                    //Console.WriteLine("Event");
                    Point newSize = Poprica.MathFunctions.CalcImageSize(size, step, (ImageType) imgIndex);
                    eventRect = new Rectangle(Poprica.MathFunctions.ImagePos(step, Poprica.PositionType.BOTTOM, newSize), newSize);
                }
                else
                {
                    Point newSize = Poprica.MathFunctions.CalcImageSize(new Point(30, 30), step);
                    eventRect = new Rectangle(Poprica.MathFunctions.ImagePos(step, Poprica.PositionType.BOTTOM, newSize), newSize);
                }

                Poprica.Image eventImg = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, 0, eventRect);

                //converts EventType Enum to ImageType Enum
                eventImg.Index = imgIndex;
                Images.Add(eventImg);
            }

            Dictionary<ItemCategory, dynamic> items = tile.Items;

            if (items == null)
                return;

            if (items.Count() > 0)
            {
                Rectangle rect = new Rectangle();
                Point size = new Point();
                
                foreach (KeyValuePair<ItemCategory, dynamic> pair in items)
                {
                    dynamic t = EnumManagement.GetEnumType(pair.Key, pair.Value); //Enum.Parse(GetEnumType(pair.Key).GetType(), ((int) pair.Value).ToString()).GetType();
                    
                    int imgIndex  = (int)((ImageType)Enum.Parse(typeof(ImageType), t.ToString()));

                    if (Poprica.Maps.DCImageSizes.TryGetValue(t, out size))
                    {
                        //Console.WriteLine("Item");
                        Point newSize = Poprica.MathFunctions.CalcImageSize(size, step, (ImageType) imgIndex);
                        rect = new Rectangle(Poprica.MathFunctions.ImagePos(step, Poprica.PositionType.BOTTOM, newSize), newSize);
                    }
                    else
                    {
                        Point newSize = Poprica.MathFunctions.CalcImageSize(new Point(30, 30), step);
                        rect = new Rectangle(Poprica.MathFunctions.ImagePos(step, Poprica.PositionType.BOTTOM, newSize), newSize);
                    }

                    Poprica.Image Img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, 0, rect);

                    //converts ItemType Enum to ImageType Enum
                    Img.Index = imgIndex;
                    Images.Add(Img);
                }
            }
        }

        /// <summary>
        /// Returns amount of DungeonMoney of DungeonCrawler Player.
        /// </summary>
        /// <returns>Int which represents amount of DungeonMoney.</returns>
        protected override int GetMoney()
        {
            return Player.Main.DungeonMoney;
        }
    }
}
