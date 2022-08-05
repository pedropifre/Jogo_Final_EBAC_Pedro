using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pedro.StateMachine;

namespace Boss
{

    public class TriggerBoss : MonoBehaviour
    {
        public BossBase boss;
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag=="Player")
                boss.SwitchState(BossAction.WALK);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.tag == "Player")
                boss.SwitchState(BossAction.IDLE);
        }
    }

}