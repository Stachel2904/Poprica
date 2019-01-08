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
        BACKWARD,
        RIGHT,
        LEFT,
        TURNRIGHT,
        TURNLEFT
    }

    public enum TileType
    {
        NONE,
        STRAIGHT,
        RIGHTTURN,
        LEFTTURN,
        TCROSS,
        INTERSECTION,
        ENTRY,

        //Bitte diese als Block lassen!!
        CONSTRUCTIONSIGN,
        ROOM,
        ROOMLEFT,
        ROOMRIGHT,
        PRISONERROOM,

    }

    public enum EventType
    {
        NONE
    }

    public enum EnemyType
    {

    }

    public enum ItemCategory
    {

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

    }

    public enum ImageType
    {
        STRAIGHT,
        RIGHTTURN,
        LEFTTURN,
        TCROSS,
        INTERSECTION,
        ENTRY,

        //Bitte diese als Block lassen!!
        CONSTRUCTIONSIGN,
        ROOM,
        ROOMLEFT,
        ROOMRIGHT,
        PRISONERROOM,
    }
}
