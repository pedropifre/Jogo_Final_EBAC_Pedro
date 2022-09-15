using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;

public class Player : Singleton<Player> //IDamagable
{
    public List<Collider> colliders;
    public Animator animator;

    public CharacterController characterController;
    public float speed =1f;
    public float turnSpeed = 1f;

    [Header("Gravity")]
    public float gravity = 9.8f;
    public float vSpeed = 0f;
    public float jumpSpeed = 15f;

    [Header("Gravity")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    [Header("Live")]
    public HealthBase healthBase;
    public GameObject firstCheckpoint;
    //public UIGunUpdater uIGunUpdater;



    private bool _alive = true;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }
    
    protected override void Awake()
    {
        base.Awake();
        OnValidate();

        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }
   

    #region LIFE
    private void OnKill(HealthBase h)
    {
        if (_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), 3f);
        }
    }

    private void Revive()
    {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Respawn();
        Invoke(nameof(TurnOnColliders), .1f);
    }

    private void TurnOnColliders()
    {
        colliders.ForEach(i => i.enabled = true);
    }

    public void Damage(HealthBase h)
    {
        flashColors.ForEach(i => i.Flash()) ;
       ShakeCamera.Instance.Shake();
        EffectsManager.Instance.ChangeVignette();
    }

    public void Damage(float damage, Vector3 dir)
    {
       //Damage(damage);
    }
    #endregion

    void Update()
    {
        
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
                StartCoroutine(VFX_JUMP());
                
            }    

        }

        IEnumerator VFX_JUMP()
        {
            animator.SetBool("Jump", true);
            yield return new WaitForSeconds(.5f);
            animator.SetBool("Jump", false);
        }

        vSpeed -= gravity * Time.deltaTime;
        
        speedVector.y = vSpeed;
        characterController.Move(speedVector * Time.deltaTime);

        


        var isWalking = inputAxisVertical != 0;

        if (isWalking )
        {
            if (Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        animator.SetBool("Run", isWalking);
        

    }

    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if (CheckPointManager.Instance.hasCheckPoint())
        {
            transform.position = CheckPointManager.Instance.GetPosLastCP();
        }
        else
        {
            transform.position = firstCheckpoint.transform.position;
        }
    }

}
