using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Soldier
{
    public class Infantry : Unit
    {
        #region Attributs
        
        private static int[] da = {10, 15, 20};
        private static int[] hp = {10, 20, 30};
        private static int sp = 5;
        protected int lvl; 
        
        #endregion

        public Infantry(SoldierTeam team)
            : base(SoldierType.Infantry, team, da[0], hp[0], sp, 0)
        {
            
        }
        
        
        
        
        // Start is called before the first frame update
        void Start()
        {

            ne
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
