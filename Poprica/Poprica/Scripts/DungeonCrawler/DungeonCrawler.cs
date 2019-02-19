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
            //TODO: Find latest Location in Dungeon and load these, from Progess-Class

            this.Images = new List<Poprica.Image>();

            Vector3 entryPoint = Player.Main.Location;
            Vector3 orientation = Player.Main.Rotation;

            for (int i = 6; i >= 0; i--)
            {
                Tile current = null;
                Tile[] currentRow = null;
                
                if (!Dungeon.Main.Floor.Tiles.TryGetTiles((int)(entryPoint.Y + orientation.Y * (i+1)), out currentRow))
                {
                    continue;
                }

                if (!currentRow.TryGetTile((int)(entryPoint.X + orientation.X * (i+1)), out current))
                {
                    continue;
                }

                Poprica.Image img;
                Rectangle rect = new Rectangle(ImagePos(i), new Point((int)(1920 / (Math.Pow(2, i))), (int)(1080 / (Math.Pow(2, i)))));

                //If wall is in front of the player ... stops seeing Tiles behind the wall
                if (!Player.Main.Allowed(DirectionType.FORWARD) ) //&& GetTileInFront(entryPoint, orientation) != )
                {
                    rect = new Rectangle(ImagePos(0), new Point((int)(1920 / (Math.Pow(2, 0))), (int)(1080 / (Math.Pow(2, 0)))));

                    //Abfrage ob Img nicht vllt ConstructionSign sein sollte
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.NONE, rect);
                    this.Images.Add(img);
                    return;
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
                    AddImageField(new Vector2(entryPoint.X + orientation.X * i, entryPoint.Y + orientation.X * i), i, current);
                }
                else
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)current.Type, rect);
                    this.Images.Add(img);
                    //this.Images.Add(AllImages[(int)current.Type]);
                }

                CheckTileForAdditionalImage(current, 6-i);
            }
        }

        public override void Update()
        {
            this.LoadImages();

            Player.Main.UpdateInventory();
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

            Point pos = ImagePos(step);
            Point size = new Point((int)(1920 / (Math.Pow(2, step))), (int)(1080 / (Math.Pow(2, step))));

            rectLeft = new Rectangle(new Point(pos.X - (int)(1920 / (Math.Pow(2, step))), pos.Y), size);
            rect = new Rectangle(pos, size);
            rectRight = new Rectangle( new Point(pos.X + (int)(1920 / (Math.Pow(2, step))), pos.Y), size);

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

        private void CheckTileForAdditionalImage(Tile tile, int step)
        {
            EventType type = tile.Event;

            Rectangle rect = new Rectangle(ImagePos(step, true), new Point(30+(step*10), 30+(step*10)));
            Poprica.Image img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, 0, rect);

            if (type == EventType.KEYRICA)
            {
                Console.WriteLine("Check");
                img.Index = (int)ImageType.KEY;
                Images.Add(img);
            }
        }


        private Point ImagePos(int step, bool center = false)
        {
            if(!center)
                return new Point(Poprica.MathFunctions.CalcPicturePosWidth(step), Poprica.MathFunctions.CalcPicturePosHeight(step));
            else
            {
                Point point = new Point(960, 540); // Poprica.MathFunctions.CalcPicturePosMiddle(step);
                return point;
            }
                
        }
    }
}
