using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public enum GameOptions
    {
        FULLSCREEN,
        WINDOW,

    }

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

        WAIFUCOLLECTION,

        DUNGEONCRAWLER
    }

    public enum ImageType
    {
        UI,
        DCUI,
        MENU,
        ICONS,
        BACKGROUND,
        POSES,
        MOOD,
        CLOTHES,
        DUNGEONCRAWLER
    }

    public enum UIImageType
    {
        PLAY,
        LOAD,
        OPTIONS,
        HELP,
        PATREON,
        QUIT,

        PREVIOUS,
        FULLSCREEN,
        WINDOW,

        PLAYERINFO,
        MONEY,
        SAVE,
        INVENTORY,

        TALK,

        LIVINGROOM,
        BEDROOM,
        BEDROOMRICA,

        LEAVE,

        BAR,
        NEEDLE,

        BUTTON,
    }

    public enum IconImageType
    {

    }

    public enum LocationType
    {
        NONE,
        COLLECTIONSCREEN,
        LIVINGROOM,
        BEDROOM,
        BEDROOMRICA,
    }

    public enum DungeonCrawlerImageType
    {

    }

    public enum VoiceType
    {
        MOAN1,
        SPEECH1
    }

    public enum PositionType
    {
        NONE,
        LEFT,
        MIDDLELEFT,
        MIDDLE,
        MIDDLERIGHT,
        RIGHT,
        TOP,
        BOTTOM,
        RIGHTBOTTOM,
        LEFTBOTTOM
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
        PLAYER,
        RICA
    }

    public enum ActionType
    {
        TALK,
        
        //DC
        RESCUE
    }

    public enum DialogueElementType
    {
        CONDITION,
        STATEMENT,
        DECISION,
        CHOICE,
        CONSEQUENCE,
        END
    }

    public enum TraitType
    {
        LOVE,
        OBEDIENCE,
        MOOD
    }

    public enum MoodType
    {
        NORMAL,
        HAPPY,
        ANGRY,
        BLUSH,
        SURPRISED,
        SAD
    }

    public enum ClothesType
    {
        BRABLACKT,
        BRADARKRED,
        BRARED,
        PANTSBLACKT,
        PANTSRED,
        PANTSDARKRED,
        TANGABLACKT,
        TANGADARKRED,
        TANGARED,
        DRESSBLUE,
        DRESSRUINED,
        DRESSWHITE,
    }

    public enum PoseType
    {
        NORMAL,
    }

    public enum ButtonType
    {
        //Main Menu
        PLAY,
        LOAD,
        OPTIONS,
        HELP,
        PATREON,
        QUIT,

        //PlayerInfo
        MONEY,
        SAVE,
        INVENTORY,

        //Options
        PREVIOUS,
        FULLSCREEN,
        WINDOW,

        //Location Buttons
        TALK,
        
        LIVINGROOM,
        BEDROOM,
        BEDROOMRICA,

        LEAVE,

        //DC Navigation Buttons
        FORWARD,
        RIGHT,
        BACK,
        LEFT,
        TURNRIGHT,
        TURNLEFT,

        //DC Action Buttons
        RESCUE,

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
        MAINMENU,
        PAUSEMENU,
        LOADSAVEGAME,
        OPTIONS,
        HELP,
        PLAYERINFO,
        DUNGEONCRAWLERNAVIGATION,

    }
}