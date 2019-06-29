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
        public float Pover { get; set; }

        public bool SetDamage(float damage)
        {
            CurrentHp -= damage;
            return CurrentHp <= 0 ? true : false;
        }

        public BaseGameObject(GameObjectView obj)
        {
            Object = obj;
            obj.setDamage = SetDamage;
            obj.damagePover = () => { return Pover; };
        }
        public BaseGameObject(GameObjectView obj, float maxHp) : this(obj)
        {
            CurrentHp = MaxHp = maxHp;
        }
        public BaseGameObject(GameObjectView obj, float maxHp, float speed) : this(obj, maxHp)
        {
            Speed = speed;
        }
        public BaseGameObject(GameObjectView obj, float maxHp, float speed, float pover) 
            : this(obj, maxHp, speed)
        {
            Pover = pover;
        }
    }
}
