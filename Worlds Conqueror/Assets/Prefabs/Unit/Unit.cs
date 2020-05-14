using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

namespace WorldConqueror
{
    public class Unit : MonoBehaviour
    {
        
        #region Attributs

        private int damage;
        private int hp;
        private int speed;
        private int lvl; 
        private SoldierType type;
        private PunTeams.Team team;
        private bool isDead;

        public enum SoldierType
        {
            Pathfinder, Infantry, Archer, Cavalry, SiegeWeapon
        }

        public enum SoldierTeam
        {
            Blue, Red, Yellow, Green
        }

        public SoldierType Type
        {
            get { return type; }
        }
        public PunTeams.Team Team
        {
            get { return team; }
        }

        public int Speed => speed;

        public int UnitDamage => damage;

        #endregion

        #region Prix

        public int[] InfantryPrice = { 25, 30, 40, 50 };
        public int[] ArcheryPrice = { 30, 40, 50, 60 };
        public int[] CavaleryPrice = { 50, 65, 80, 100 };
        public int[] SiegeWeaponPrice = { 50, 75, 100, 125 };

        #endregion

        #region Levels

        int InfantryLevel = 0;
        int ArcheryLevel = 0;
        int CavaleryLevel = 0;
        int SiegeWeaponLevel = 0;

        #endregion

        #region truc a modifier

        public Unit(SoldierType type,PunTeams.Team team, int damage, int hp, int speed, int lvl )
        {
            this.type = type;
            this.team = team;
            this.damage = damage;
            this.hp = hp;
            this.speed = speed;
            this.lvl = lvl;
            isDead = false;
        }

        public void MoveRight()
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10, Space.Self);
        }

        public void Damage(int dam)
        {
            hp -= dam;
            if (hp <= 0)
            {
                hp = 0;
                isDead = true;
            }
            
        }

        public void Attack(Unit unit, Building.Building building)
        {
            if (type == SoldierType.Pathfinder)
            {
                if (building == null)
                {
                    if (unit != null)
                        unit.Damage(damage / 3);
                }
                /*else
                {
                    if (building.Team == Building.Building.BuildingTeam.Neutral
                        || building.Team == Building.Building.BuildingTeam.Neutral_Capturable)
                        fonction qui inflige des dégats aux batiments
                }
                   */ 
            }
            else
            {
                if (type == SoldierType.SiegeWeapon)
                {
                    if (unit == null)
                    {
                        //if (building != null)
                            //foncntion de degats sur batiments
                    }
                    else
                    {
                        unit.Damage(damage/3);
                    }
                }
                else
                {
                    if (building == null)
                    {
                        if (unit != null)
                            unit.Damage(damage);
                    }
                    else
                    {
                        //foncntion de degats sur batiments
                    }
                }
            }
        }

        #endregion

        public int GetPrice(SoldierType type)
        {
            int level = GetLevel(type);

            switch(type)
            {
                case SoldierType.Infantry:
                    if (level >= 4)
                        return InfantryPrice[3];
                    if (level < 0)
                        return InfantryPrice[0];
                    return InfantryPrice[level];
                case SoldierType.Archer:
                    if (level >= 4)
                        return ArcheryPrice[3];
                    if (level < 0)
                        return ArcheryPrice[0];
                    return ArcheryPrice[level];
                case SoldierType.Cavalry:
                    if (level >= 4)
                        return CavaleryPrice[3];
                    if (level < 0)
                        return CavaleryPrice[0];
                    return CavaleryPrice[level];
                case SoldierType.SiegeWeapon:
                    if (level >= 4)
                        return SiegeWeaponPrice[3];
                    if (level < 0)
                        return SiegeWeaponPrice[0];
                    return SiegeWeaponPrice[level];
                default:
                    return 0;
            }
        }

        public int GetLevel(SoldierType type)
        {
            switch(type)
            {
                case SoldierType.Infantry:
                    return InfantryLevel;
                case SoldierType.Archer:
                    return ArcheryLevel;
                case SoldierType.Cavalry:
                    return CavaleryLevel;
                case SoldierType.SiegeWeapon:
                    return SiegeWeaponLevel;
                default:
                    return 0;
            }
        }

        public void Upgrade(SoldierType type)
        {
            switch(type)
            {
                case SoldierType.Infantry:
                    InfantryLevel ++;
                    return;
                case SoldierType.Archer:
                    ArcheryLevel ++;
                    return;
                case SoldierType.Cavalry:
                    CavaleryLevel ++;
                    return;
                case SoldierType.SiegeWeapon:
                    SiegeWeaponLevel ++;
                    return;
                default:
                    return;
            }
        }
    }
}