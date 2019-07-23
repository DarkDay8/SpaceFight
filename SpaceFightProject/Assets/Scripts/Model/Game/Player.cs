using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

namespace SpaceFightProject
{
    public class Player : BaseGameObject
    {
        private PlayerMoveController moveController;
        private PlayerFireController fireController;
        public float MaxEnergy { get; set; } = 10;     //cap
        public float CurrentEnergy { get; set; } = 10; //cap

        public float WeaponReloadTime { get; set; } //sec
        public event System.Action shot;
        public event System.Action<float, float> changeHP;
        public event System.Action<float, float> changeEnergy;

        #region Constructors
        public Player(GameObjectView obj) : base(obj)
        {
            Fraction = Fractions.Player;
        }
        public Player(GameObjectView obj, float maxHp) : base(obj, maxHp)
        {
            Fraction = Fractions.Player;
        }         
        public Player(GameObjectView obj, float maxHp, float speed) : base(obj, maxHp, speed)
        {
            Fraction = Fractions.Player;
        }
        public Player(GameObjectView obj, float maxHp, float speed, float pover) 
            : base(obj, maxHp, speed, pover)
        {
            Fraction = Fractions.Player;
        }
        #endregion
        public Player SetMoveController()
        {
            moveController = Object.gameObject.AddComponent<PlayerMoveController>();
            moveController.speed = Speed;
            return this;
        }
        public Player SetFireController()
        {
            fireController = Object.gameObject.AddComponent<PlayerFireController>();
            fireController.shot = Fire;
            return this;
        }
        public void Fire()
        {
            shot();
            fireController.RemoveFireContoller();
            fireController = null;
            TimersManager.SetTimer(this, WeaponReloadTime, () => { SetFireController(); });
        }
        public override bool GetDamage(float damage)
        {
            CurrentHp -= damage;
            changeHP(CurrentHp, MaxHp);
            return CurrentHp <= 0 ? true : false;
        }
        public void UseEnergy(float value)
        {
            changeEnergy(CurrentEnergy, MaxEnergy);
        }
    }
}
