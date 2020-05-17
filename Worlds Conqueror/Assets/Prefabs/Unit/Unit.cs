using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

namespace WorldConqueror
{
    public class Unit : MonoBehaviour
    {

        #region Attributs

        private int damage = 0;
        private int hp = 0;
        private int Maxhp = 0;
        private float speed = 0f;
        private float attackSpeed = 1f;
        public int lvl;
        private SoldierType type;
        private PunTeams.Team team;
        private bool isDead;

        public Text Level;
        public Text Hp;

        public enum SoldierType
        {
            Pathfinder, Infantry, Archer, Cavalry, SiegeWeapon
        }

        public enum SoldierTeam
        {
            Blue, Red, Yellow, Green
        }



        public PunTeams.Team Team
        {
            get { return team; }
        }

        public float Speed => speed;

        public int UnitDamage => damage;

        #endregion

        #region Stats

        static int[] InfantryDommage = { 10, 15, 20, 30 };
        static int[] ArcheryDommage = { 20, 30, 40, 60 };
        static int[] CavaleryDommage = { 10, 15, 20, 30 };
        static int[] SiegeWeaponDommage = { 50, 100, 150, 200 };

        static float[] InfantryAttackSpeed = { 1.6f, 1.4f, 1.2f, 1f };
        static float[] ArcheryAttackSpeed = { 1.5f, 1.4f, 1.3f, 1.2f };
        static float[] CavaleryAttackSpeed = { 0.7f, 0.6f, 0.5f, 0.4f };
        static float[] SiegeWeaponAttackSpeed = { 10f, 9f, 8f, 7f };

        static float[] InfantrySpeed = { 1.5f, 1.75f, 2f, 2.5f };
        static float[] ArcherySpeed = { 1.5f, 1.75f, 2f, 2.5f };
        static float[] CavalerySpeed = { 3.5f, 4f, 4.5f, 5.5f };
        static float[] SiegeWeaponSpeed = { 1f, 1.2f, 1.3f, 1.5f };

        static int[] InfantryHeal = { 50, 65, 80, 100 };
        static int[] ArcheryHeal = { 25, 30, 35, 40 };
        static int[] CavaleryHeal = { 35, 45, 55, 75 };
        static int[] SiegeWeaponHeal = { 50, 100, 150, 200 };

        #endregion

        public Unit(SoldierType type, PunTeams.Team team)
        {
            this.type = type;
            this.team = team;
            isDead = false;


            switch (type)
            {
                case (SoldierType.Infantry):
                    this.damage = InfantryDommage[lvl];
                    this.hp = InfantryHeal[lvl];
                    this.Maxhp = InfantryHeal[lvl];
                    this.attackSpeed = InfantryAttackSpeed[lvl];
                    this.speed = InfantrySpeed[lvl];
                    break;
                case (SoldierType.Archer):
                    this.damage = ArcheryDommage[lvl];
                    this.hp = ArcheryHeal[lvl];
                    this.Maxhp = ArcheryHeal[lvl];
                    this.attackSpeed = ArcheryAttackSpeed[lvl];
                    this.speed = ArcherySpeed[lvl];
                    break;
                case (SoldierType.Cavalry):
                    this.damage = CavaleryDommage[lvl];
                    this.hp = CavaleryHeal[lvl];
                    this.Maxhp = CavaleryHeal[lvl];
                    this.attackSpeed = CavaleryAttackSpeed[lvl];
                    this.speed = CavalerySpeed[lvl];
                    break;
                case (SoldierType.SiegeWeapon):
                    this.damage = SiegeWeaponDommage[lvl];
                    this.hp = SiegeWeaponHeal[lvl];
                    this.Maxhp = SiegeWeaponHeal[lvl];
                    this.attackSpeed = SiegeWeaponAttackSpeed[lvl];
                    this.speed = SiegeWeaponSpeed[lvl];
                    break;
                default:
                    return;

            }
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
                        unit.Damage(damage / 3);
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

        private void UpdateText()
        {
            switch(team)
            {
                case PunTeams.Team.red:
                    {
                        Level.color = Color.red;
                        Hp.color = Color.red;
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Level.color = Color.yellow;
                        Hp.color = Color.yellow;
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Level.color = Color.green;
                        Hp.color = Color.green;
                        break;
                    }
                case PunTeams.Team.blue:
                    {
                        Level.color = Color.blue;
                        Hp.color = Color.blue;
                        break;
                    }
            }

            Level.text = lvl.ToString();
            Hp.text = hp.ToString() + " / " + Maxhp.ToString();
        }

        void Start()
        {
            UpdateText();
        }

        void Update()
        {
            Level.text = lvl.ToString();
            Hp.text = hp.ToString() + " / " + Maxhp.ToString();
        }
    }
}