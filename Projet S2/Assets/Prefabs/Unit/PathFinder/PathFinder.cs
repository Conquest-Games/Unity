using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soldier
{
    public class PathFinder : Unit
    {
        #region Attributs
        
        private static int[] da = {10, 15, 20};
        private static int[] inithp = {5, 10, 15};
        private static int sp = 10;
        protected int lvl;
        
        #endregion

        public PathFinder(SoldierTeam team)
        : base(SoldierType.Pathfinder, team, da[0], inithp[0], sp, 0)
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
