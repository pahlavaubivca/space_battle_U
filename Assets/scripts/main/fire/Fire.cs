using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        public int bulletType = 1;

        public void CalculateStart(){
            BulletCollection _currentBullet = null;
            foreach (var bullet in ImplementedBullet.ImplementedBulletDictionary){
                if (bullet.Key == bulletType){
                    _currentBullet = bullet.Value;
                }
            }
            if (_currentBullet != null){
                _currentBullet.CreateClone(transform);
            }
        }

        public void ClearAll(){
        }
    }
}