using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public enum GameStateType
    {

    }

    public enum DirectionType
    {
        FORWARD,
        RIGHT,
        BACKWARD,
        LEFT,
        TURNRIGHT,
        TURNLEFT
    }

    public enum TileType
    {
        NONE,
        STRAIGHT,
        TURN,
        TCROSS,
        INTERSECTION,
        ENTRY,

        STRAIGHTSIGN,
        RIGHTTURNSIGN,
        LEFTTURNSIGN,
        TCROSSSIGNMAINLEFT,


        //Bitte diese als Block lassen!!
        CONSTRUCTIONSIGN,
        ROOM,
        ROOMWALL,
        ROOMCORNER,
        ROOMEXIT,
        PRISONERROOM,
    }

    public enum EventType
    {
        NONE,
        RICA,
        KEYRICA

    }

    public enum EnemyType
    {

    }

    public enum ItemCategory
    {
        NONE,
        WEAPON,
        ARMOR,
        POTION,
        BASICITEM
    }

    public enum WeaponType
    {

    }

    public enum ArmorType
    {

    }

    public enum PotionType
    {

    }

    public enum BasicItemType
    {
        KEYRICA,
        KEYEMELIE
    }

    public enum ImageType
    {
        NONE,
        STRAIGHT,
        RIGHTTURN,
        LEFTTURN,
        TCROSS,
        INTERSECTION,
        ENTRY,

        STRAIGHTSIGN,
        RIGHTTURNSIGN,
        LEFTTURNSIGN,
        TCROSSSIGNMAINLEFT,

        //Bitte diese als Block lassen!!
        CONSTRUCTIONSIGN,
        ROOM,
        ROOMWALL,
        ROOMRIGHTCORNER,
        ROOMEXIT,
        PRISONERROOM,

        TRCOSSMAIN,
        TCROSSRIGHT,
        TCROSSLEFT,

        ROOMRIGHT,
        ROOMLEFT,
        ROOMRIGHTPERSPECTIVE,
        ROOMLEFTPERSPECTIVE,
        ROOMLEFTCORNER,
        CORNERLEFTPERSPECTIVE,
        CORNERRIGHTPERSPECTIVE,

        KEY,
        RICA
    }
}
