using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soldier
{
    public class Unit : MonoBehaviour
    {
        
        #region Attributs

        private int damage;
        private int hp;
        private int speed;
        private int lvl; 
        private SoldierType type;
        private SoldierTeam team;
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
        public SoldierTeam Team
        {
            get { return team; }
        }
        
        #endregion

        


        public Unit(SoldierType type,SoldierTeam team, int damage, int hp, int speed, int lvl )
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
        
        
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}