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

        public void MoveRight()
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10, Space.Self);
        }
    }
}