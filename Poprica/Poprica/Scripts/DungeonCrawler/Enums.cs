﻿using System;
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
        STRAIGHT,
        RIGHTTURN,
        LEFTTURN,
        TCROSS,
        INTERSECTION,
        ENTRY,
        PRISONERROOM,
        CONSTRUCTIONSIGN

    }

    public enum EventType
    {

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
        PRISONERROOM,
        CONSTRUCTIONSIGN
    }
}