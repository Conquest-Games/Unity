using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soldier
{
    public class SiegeWeapon : Unit
    {
        #region Attributs
        
        private static int[] da = {30, 60, 90};
        private static int[] hp = {15, 30, 50};
        private static int sp = 5;
        protected int lvl; 
        
        #endregion

        public SiegeWeapon(SoldierTeam team)
            : base(SoldierType.Pathfinder, team, da[0], hp[0], sp, 0)
        {
            
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