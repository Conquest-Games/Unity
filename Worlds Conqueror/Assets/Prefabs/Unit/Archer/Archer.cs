using System.Collections;
using System.Collections.Generic;
using Soldier;
using UnityEngine;

namespace WorldConqueror
{
    public class Archer : Unit
    {
        #region Attributs

        private static int[] da = {15, 20, 25};
        private static int[] hp = {5, 10, 15};
        private static int sp = 5;
        protected int lvl;

        #endregion

        public Archer(SoldierTeam team)
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