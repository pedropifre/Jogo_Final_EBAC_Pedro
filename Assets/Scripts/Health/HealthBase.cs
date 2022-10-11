using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Cloth;

public class HealthBase : MonoBehaviour, IDamagable
{
    public float StartLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdate> uIGunUpdater;

    public float damageMultiply = 1f;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        ResetLife();
    }

    private void UpdateUi()
    {
        if (uIGunUpdater != null)
        {
            uIGunUpdater.ForEach(i => i.UpdateValue((float)_currentLife / StartLife));
        }
    }
    public void ResetLife()
    {
        _currentLife = StartLife;
        UpdateUi();
    }

    protected virtual void Kill()
    {
        if(destroyOnKill)
            Destroy(gameObject, 3f);
        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

 
    public void Damage(float f)
    {

        _currentLife -= f * damageMultiply;

        if (_currentLife <= 0)
        {
            Kill();
        }
        UpdateUi();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage); 
    }

    public void ChangeDamageMultiply(float damageMultiply, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCourotine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCourotine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;
    }
}
