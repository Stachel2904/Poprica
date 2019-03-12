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
        CHEST,
        RESCUE,
        PRISON,
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
        HEALTH,
        ARMOR
    }

    public enum BasicItemType
    {
        KEY,
        KEYEMELIE
    }

    public enum ImageType
    {
        CHEST,
        CONSTRUCTIONSIGN,
        CORNERLEFTPERSPECTIVE,
        CORNERRIGHTPERSPECTIVE,
        INTERSECTION,
        KEY,
        LEFTTURN,
        PRISONERROOM,
        RICA,
        RIGHTTURN,
        ROOM,
        ROOMCOMPLETE,
        ROOMEXIT,
        ROOMLEFT,
        ROOMLEFTCORNER,
        ROOMLEFTPERSPECTIVE,
        ROOMRIGHT,
        ROOMRIGHTCORNER,
        ROOMRIGHTPERSPECTIVE,
        ROOMWALL,
        STRAIGHT,
        TCROSSLEFT,
        TCROSSMAIN,
        TCROSSRIGHT,
        WALL,


        //NONE,

        //NONE,
        //STRAIGHT,
        //RIGHTTURN,
        //LEFTTURN,
        //TCROSS,
        //INTERSECTION,
        //ENTRY,

        //STRAIGHTSIGN,
        //RIGHTTURNSIGN,
        //LEFTTURNSIGN,
        //TCROSSSIGNMAINLEFT,

        ////Bitte diese als Block lassen!!
        //CONSTRUCTIONSIGN,
        //ROOM,
        //ROOMWALL,
        //ROOMRIGHTCORNER,
        //ROOMEXIT,
        //PRISONERROOM,

        //TRCOSSMAIN,
        //TCROSSRIGHT,
        //TCROSSLEFT,

        //ROOMRIGHT,
        //ROOMLEFT,
        //ROOMRIGHTPERSPECTIVE,
        //ROOMLEFTPERSPECTIVE,
        //ROOMLEFTCORNER,
        //CORNERLEFTPERSPECTIVE,
        //CORNERRIGHTPERSPECTIVE,

        //KEY,
        //RICA,
        //CHEST
    }

    public static class EnumManagement
    {
        /// <summary>
        /// Returns a Enum Value depends on given ItemCategory type and dynamic index.
        /// </summary>
        /// <param name="type">Value of Itemcategory.</param>
        /// <param name="index">Index for result enum.</param>
        /// <returns>Value of target enum.</returns>
        public static dynamic GetEnumType(ItemCategory type, dynamic index)
        {
            switch (type)
            {
                case ItemCategory.ARMOR:
                    return (index < Enum.GetNames(typeof(ArmorType)).Length && index >= 0) ? (ArmorType) index : 0;
                case ItemCategory.BASICITEM:
                    return (index < Enum.GetNames(typeof(BasicItemType)).Length && index >= 0) ? (BasicItemType)index : 0;
                case ItemCategory.POTION:
                    return (index < Enum.GetNames(typeof(PotionType)).Length && index >= 0) ? (PotionType)index : 0;
                case ItemCategory.WEAPON:
                    return (index < Enum.GetNames(typeof(WeaponType)).Length && index >= 0) ? (WeaponType)index : 0;
            }

            return typeof(BasicItemType);
        }
    }
}
