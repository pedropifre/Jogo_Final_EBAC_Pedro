using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pedro.StateMachine;
using DG.Tweening;


namespace Boss
{
    
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }
    public class BossBase : MonoBehaviour
    {
        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;

        [Header("Attack")]
        public int attackAmmount = 5;
        public float timeBetweenAttacks = .5f;
        public GunBase gunBase;

        public float speed = 5f;
        public List<Transform> wayPoints;
    

        //public HealthBase healthBase;
        public StateMachine<BossAction> stateMachine;

        //Look at player
        public bool lookAtPlayer = false;
        private Player _player;

        private void Awake()
        {
            Init();
            //healthBase.OnKill += OnBossKill;
            _player = GameObject.FindObjectOfType<Player>();
        }

        private void Update()
        {
            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }
        }
        public void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
            stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
            stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        #region DEATH
        private void OnBossKill(HealthBase h)
        {
            SwitchState(BossAction.DEATH);
        }
        #endregion

        #region ATTACK
        public void StartAttack(Action endCallBack = null)
        {
            StartCoroutine(StartAttackCorotine(endCallBack));
            
        }

        IEnumerator StartAttackCorotine(Action endCallBack = null)
        {
            int attacks = 0;
            while (attacks < attackAmmount)
            {
                attacks++;
                transform.DOScale(1.1f, .1f).SetLoops(2, LoopType.Yoyo);
                gunBase.Shoot();
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            if (endCallBack != null) endCallBack.Invoke();
        }
        #endregion

        #region WALKING
        public void GoToRandomPoint(Action onArrive = null)
        {
            StartCoroutine(GoToPointCourotine(wayPoints[UnityEngine.Random.Range(0, wayPoints.Count)], onArrive));
        }
        
        IEnumerator GoToPointCourotine(Transform t, Action onArrive = null)
        {
            while (Vector3.Distance(transform.position, t.position) > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
            if (onArrive != null) onArrive.Invoke();
        }

        #endregion
        
        #region ANIMATION
        public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }
        #endregion

        #region DEBUG

        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            SwitchState(BossAction.INIT);
        }
        [NaughtyAttributes.Button]
        private void SwitchWalk()
        {
            SwitchState(BossAction.WALK);
        }
        [NaughtyAttributes.Button]
        private void SwitchAttack()
        {
            SwitchState(BossAction.ATTACK);
        }
        
        #endregion

        #region STATE MACHINE
        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this);
        }
        #endregion
    }

}