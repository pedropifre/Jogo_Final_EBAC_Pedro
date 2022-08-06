using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pedro.StateMachine;
using DG.Tweening;

namespace Boss
{

    public class TriggerBoss : MonoBehaviour
    {
        public BossBase boss;
        public GameObject bossPrefab;
        public GameObject bossMesh;
        public GameObject bossFirstLocation;
        public Vector3 bossSize;
        public bool spawned = false;
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Player")
            {
                
                StartCoroutine(SpawnBoss());
                boss.SwitchState(BossAction.WALK);
            }
        }
        IEnumerator SpawnBoss()
        {
            if (!spawned)
            {             
                bossPrefab.transform.DOMove(bossFirstLocation.transform.position, 4f).SetEase(Ease.OutBack);
                spawned = true;
                yield return new WaitForSeconds(4f);
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.tag == "Player")
                boss.SwitchState(BossAction.IDLE);
        }
    }

}