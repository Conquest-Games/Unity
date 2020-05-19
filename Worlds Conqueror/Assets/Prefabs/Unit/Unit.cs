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
        
        
        public bool fight = false;



        public enum SoldierType
        {
            Ninja, Infantry, Archer, Cavalry, SiegeWeapon
        }

        public enum SoldierTeam
        {
            Blue, Red, Yellow, Green
        }

        public GameObject Level;

        public PunTeams.Team Team
        {
            get { return team; }
        }

        public float Speed => speed;

        public int UnitDamage => damage;

        #endregion

        #region Stats

        static int[] InfantryDommage = { 10, 15, 20, 30 };
        static int[] ArcheryDommage = { 15, 25, 35, 50 };
        static int[] CavaleryDommage = { 10, 15, 20, 30 };
        static int[] SiegeWeaponDommage = { 50, 100, 150, 200 };
        static int[] NinjaDommage = { 5, 10, 15, 20 };

        static int InfantryRange = 10;
        static int ArcheryRange = 30;
        static int CavaleryRange = 15;
        static int SiegeWeaponRange = 45;
        static int NinjaRange = 10;

        static float[] InfantryAttackSpeed = { 1.6f, 1.4f, 1.2f, 1f };
        static float[] ArcheryAttackSpeed = { 1.5f, 1.4f, 1.3f, 1.2f };
        static float[] CavaleryAttackSpeed = { 0.7f, 0.6f, 0.5f, 0.4f };
        static float[] SiegeWeaponAttackSpeed = { 10f, 9f, 8f, 7f };
        static float[] NinjaAttackSpeed = { 0.7f, 0.6f, 0.5f, 0.4f };

        static float[] InfantrySpeed = { 5f, 6f, 7f, 8f };
        static float[] ArcherySpeed = { 5f, 6f, 7f, 8f };
        static float[] CavalerySpeed = { 8f, 9f, 10f, 11f };
        static float[] SiegeWeaponSpeed = { 2.5f, 3f, 3.5f, 4f };
        static float[] NinjaSpeed = { 6.5f, 7.5f, 8.5f, 10f };

        static int[] InfantryHeal = { 50, 65, 80, 100 };
        static int[] ArcheryHeal = { 25, 30, 35, 40 };
        static int[] CavaleryHeal = { 35, 45, 55, 75 };
        static int[] SiegeWeaponHeal = { 50, 100, 150, 200 };
        static int[] NinjaHeal = { 30, 35, 40, 50 };

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
                case (SoldierType.Ninja):
                    this.damage = NinjaDommage[lvl];
                    this.hp = NinjaHeal[lvl];
                    this.Maxhp = NinjaHeal[lvl];
                    this.attackSpeed = NinjaAttackSpeed[lvl];
                    this.speed = NinjaSpeed[lvl];
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
            if (type == SoldierType.Ninja)
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
                        Level.GetComponent<TextMesh>().color = Color.red;
                        break;
                    }
                case PunTeams.Team.yellow:
                    {
                        Level.GetComponent<TextMesh>().color = Color.yellow;
                        break;
                    }
                case PunTeams.Team.green:
                    {
                        Level.GetComponent<TextMesh>().color = Color.green;
                        break;
                    }
                default:
                    {
                        Level.GetComponent<TextMesh>().color = Color.cyan;
                        break;
                    }
            }

            Level.GetComponent<TextMesh>().text = lvl.ToString() + ": " + hp.ToString() + " / " + Maxhp.ToString();
        }

        void Start()
        {
            UpdateText();
        }

        void Update()
        {
            Level.GetComponent<TextMesh>().text = lvl.ToString() + ": " + hp.ToString() + " / " + Maxhp.ToString();
        }
    }
}