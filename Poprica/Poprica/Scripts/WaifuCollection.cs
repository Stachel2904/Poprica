using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class WaifuCollection : Scene
    {

        public WaifuCollection() : base(SceneType.WAIFUCOLLECTION)
        {
            LoadImages();
        }

        public override void Update()
        {
            base.Update();

            LoadImages();
        }

        public override void LoadImages()
        {
            base.LoadImages();

            Rectangle rect = new Rectangle(0, 0, width, height);
            Images.Add(new Image(ImageType.BACKGROUND, (int)LocationType.COLLECTIONSCREEN, rect));

            DialogueEntityName waifu = WaifuManager.Main.LastUnlockedWaifu;

            Vector2 scale = PopricaGame.Main.CalcCurrentScale();

            Rectangle waifuRect = new Rectangle((int) (1920*scale.X - (290*scale.X)), (int) (20 * scale.Y), 580 , 2120);
            Images.Add(new Image(ImageType.POSES, (int)PoseType.NORMAL, waifuRect, waifu.ToString()));
            Images.Add(new Image(ImageType.MOOD, (int)MoodType.NORMAL, waifuRect, waifu.ToString()));
        }

        

    }
}
