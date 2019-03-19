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
        PLAYERINFO,
        MONEY,
        SAVE,
        INVENTORY,
        TALK,
        LEAVE,
        BUTTON,
    }

    public enum IconImageType
    {

    }

    public enum LocationType
    {
        NONE,
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

        //Location Buttons
        TALK,
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