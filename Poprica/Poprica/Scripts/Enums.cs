using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public enum InputType
    {

    }

    public enum GameState
    {
        DEFAULT,
        PAUSED,
        EXIT,
        START
    }

    public enum MusicType
    {

    }

    public enum SceneType
    {
        PLACE,
        MENU,
        SHOP,
        DUNGEONCRAWLER
    }

    public enum ImageType
    {
        UI,
        ICONS,
        BACKGROUND,
        WAIFU,
        DUNGEONCRAWLER
    }

    public enum UIImageType
    {
        BUTTON
    }

    public enum IconImageType
    {

    }

    public enum LocationType
    {
        LIVINGROOM,
        BEDROOM
    }

    public enum DungeonCrawlerImageType
    {

    }

    public enum VoiceType
    {
        MOAN1,
        SPEECH1
    }

    public enum DialogueEntityPositionType
    {
        LEFT,
        MIDDLELEFT,
        MIDDLE,
        MIDDLERIGHT,
        RIGHT
    }

    public enum DialogueEntityType
    {
        NSC,
        WAIFU,
        PLAYER,
        SHOPKEEPER,
        OLDWOMAN
    }

    public enum DialogueEntityName
    {
        NARRATOR = -1,
        SELF,
        RICA
    }

    public enum ActionType
    {
        
    }

    public enum ButtonType
    {
        STARTGAME,
        STARTDUNGEONCRAWLER,
        EXIT
    }

    public enum AnimationState
    {

    }

    public enum AnimationType
    {

    }

    public enum SoundType
    {

    }

    public enum MemoryType
    {

    }

    public enum MenuType
    {
        MAINMENU
    }
}