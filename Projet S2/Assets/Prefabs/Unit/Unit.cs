using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soldier
{
    public class Unit : MonoBehaviour
    {
        
        #region Attributs

        protected int damage;
        protected int hp;
        protected int speed;
        protected int lvl; 
        private SoldierType type;
        private SoldierTeam team;

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