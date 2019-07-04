using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceFightProject
{
    public class EnemySpawnController
    {
        private EnemyCustomizer customizer;
        private Transform spawner;
        private float minTimeSpawn; //sec
        private float maxTimeSpawn; //sec
        public delegate void AddEnemyToList(BaseGameObject enemy);
        public static event AddEnemyToList addEnemyToList;


        public EnemySpawnController(Transform spawner) : this(spawner, 0.3f, 2.0f) { }
        public EnemySpawnController(Transform spawner, float minTimeSpawn, float maxTimeSpawn)
        {
            customizer = new EnemyCustomizer();
            this.spawner = spawner;
            this.minTimeSpawn = minTimeSpawn;
            this.maxTimeSpawn = maxTimeSpawn;

        }

        private void Tick()
        {
            addEnemyToList(customizer.EnemySpawn(spawner));
            TimersManager.SetTimer(this, Random.Range(minTimeSpawn, maxTimeSpawn), Tick);
        }

        public void SetNewTimeSpawn(int min, int max)
        {
            minTimeSpawn = min;
            maxTimeSpawn = max;
        }
        public void StartSpawn()
        {
            Debug.Log("Start Spawn");
            Tick();
        }
        public void StopSpawn()
        {
            TimersManager.ClearTimer(Tick);
        }

    }
}
