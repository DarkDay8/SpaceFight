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

        public float WeaponReloadTime { get; set; } //sec

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
            fireController.strike = Fire;
            return this;
        }
        public void Fire()
        {
            Debug.Log("FIRE!!!");
            fireController.RemoveFireContoller();
            fireController = null;
            TimersManager.SetTimer(this, WeaponReloadTime, () => { SetFireController(); });
        }

    }
}
