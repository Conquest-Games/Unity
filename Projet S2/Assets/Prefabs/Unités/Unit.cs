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
        public enum SoldierType
        {
            Pathfinder, Infantry, Archer, Cavalry, SiegeWeapon
        }

        private SoldierType type;
        
        #endregion

        public SoldierType Type
        {
            get { return type; }
        }


        public Unit(SoldierType type, int damage, int hp, int speed, int lvl )
        {
            this.type = type;
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