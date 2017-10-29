using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class ControllPanel : MonoBehaviour{
        //private GameObject _all;

        public void AddEnemy(){
            gameObject.GetComponent<EnemyInstance>().CreateEnemy();
        }

        void Start(){
            //_all = new GameObject("controllPanelAllGO");
            gameObject.AddComponent<EnemyInstance>();
        }
    }
}