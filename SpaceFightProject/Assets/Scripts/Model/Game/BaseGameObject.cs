using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class BaseGameObject
    {
        public GameObjectView Object;
        public float MaxHp { get; set; }
        public float CurrentHp { get; set; }
        public float Speed { get; set; }

        private float _pover;
        public float Pover {
            get { return _pover;  }
            set { _pover = value; Object.damagePover = value; }}

        private Fractions _fraction;
        public Fractions Fraction {
            get { return _fraction; }
            set { _fraction = value; Object.fraction = value; }}

        public bool GetDamage(float damage)
        {
            CurrentHp -= damage;
            return CurrentHp <= 0 ? true : false;
        }

        public BaseGameObject(GameObjectView obj) : this(obj, 1) { }
        public BaseGameObject(GameObjectView obj, float maxHp) 
            : this(obj, maxHp, 0) { }
        public BaseGameObject(GameObjectView obj, float maxHp, float speed) 
            : this(obj, maxHp, speed, 0) { }
        public BaseGameObject(GameObjectView obj, float maxHp, float speed, float pover)
            : this(obj, maxHp, speed, pover, Fractions.Minor) { }
        public BaseGameObject(GameObjectView obj, float maxHp, float speed, float pover, Fractions fraction)
        {
            Object = obj;
            CurrentHp = MaxHp = maxHp;
            Speed = speed;
            Pover = pover;
            Fraction = fraction;
            obj.getDamage = GetDamage;
        }
    }
}
