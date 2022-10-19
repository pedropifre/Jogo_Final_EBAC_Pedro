using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour,IDamagable
    {
        public Collider collider;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;
        public float StartLife = 10f;
        public bool lookAtPlayer = false;


        [SerializeField] private float _currentLife;
        private Player _player;

        [Header("Animation")]
        [SerializeField] private AnimationBase _animationBase;
        
        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease StartAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        [Header("Events")]
        public UnityEvent OnKillEvent;


        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
        }

        protected void ResetLife()
        {
            _currentLife = StartLife;
        }

        protected virtual void Init()
        {
            ResetLife();
            if (startWithBornAnimation)
            {
                BornAnimation();
            }
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if (collider != null) collider.enabled = false;
            Destroy(gameObject,3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
            OnKillEvent?.Invoke();
        }

        public void OnDamage(float f)
        {
            if (flashColor != null) flashColor.Flash();
            if (particleSystem != null) particleSystem.Emit(15);

            transform.position -= transform.forward;
            _currentLife -= f;

            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(StartAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimaitonByTrigger(animationType);
        }

        #endregion

        public virtual void Update()
        {
            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }
        }

        public void Damage(float damage)
        {
            Debug.Log("Damage");
            OnDamage(damage);
        }
        public void Damage(float damage, Vector3 dir)
        {
            Debug.Log("Damage");
            OnDamage(damage);

            transform.DOMove(transform.position - dir, .1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Player p = collision.transform.GetComponent<Player>();

            if (p != null)
            {
                p.healthBase.Damage(1);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            Player p = other.transform.GetComponent<Player>();

            if (p != null)
            {
                p.healthBase.Damage(1);
            }
        }
    }

}