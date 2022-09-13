using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShot = .3f;
    public float speed = 50f;

    private Coroutine _currentCoroutine;
   

    protected virtual IEnumerator ShootCorrutine()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShot);
            Debug.Log("shoot");
        }
    }

    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;

        
       
    }

    public void StartShoot()
    {
        CancelShoot();
        _currentCoroutine = StartCoroutine(ShootCorrutine());
    }


    public void CancelShoot()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
    }

    
}
