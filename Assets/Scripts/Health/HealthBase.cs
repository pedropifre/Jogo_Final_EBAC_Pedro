using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamagable
{
    public float StartLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdate> uIGunUpdater;

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

        _currentLife -= f;

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
}
