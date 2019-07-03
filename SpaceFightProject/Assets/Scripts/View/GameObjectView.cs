using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFightProject
{
    public class GameObjectView : View, IMyView
    {
        public delegate bool GetDamageDelegate(float damage);
        public GetDamageDelegate getDamage;

        public delegate void DestroyIt();
        public DestroyIt destroyIt;

        public float damagePover = 0;
        public Fractions fraction = Fractions.Minor;

        public void LoadView()
        {
            destroyIt += DestoryObject;
        }
        public void RemoveView() { }

        private void DestoryObject()
        {
            GameObject.Destroy(gameObject);
        }

        public void GetDamage(float damage)
        {
            if (getDamage(damage))
                destroyIt();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObjectView TriggerGameObjectView = collision.GetComponent<GameObjectView>();

            if (TriggerGameObjectView?.fraction != fraction)
                GetDamage(TriggerGameObjectView.damagePover);
        }
    }
}
