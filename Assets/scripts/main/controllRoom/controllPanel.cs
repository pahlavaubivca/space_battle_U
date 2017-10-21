using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class controllPanel : MonoBehaviour{
        private GameObject _all;

        public void AddEnemy(){
            Debug.Log("asdfadf");
            _all.GetComponent<EnemyInstance>().CreateEnemy();
        }

        void Start(){
            _all = new GameObject("controllPanelAllGO");
            _all.AddComponent<EnemyInstance>();
        }
    }
}