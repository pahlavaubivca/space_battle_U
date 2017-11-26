using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace main{
    public class ControllPanel : MonoBehaviour{
        //private GameObject _all;
        private Spawn _spawn;

        public void AddEnemy(){
            Rigidbody2D enemy = gameObject.GetComponent<EnemyInstance>().CreateEnemy(-3, 1);
        }

        void Start(){
            //_all = new GameObject("controllPanelAllGO");
            //_spawn = gameObject.AddComponent<Spawn>();
            gameObject.AddComponent<EnemyInstance>();
        }
    }
}