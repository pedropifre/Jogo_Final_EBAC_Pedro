using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GunShootLimit : GunBase
{
    public List<UIFillUpdate> uIGunUpdaters;

    public float maxShoot = 5f;
    public float timeToRecharge = 1f;

    private float _cuurrentShoots;
    private bool _recharging = false;


    private void Awake()
    {
        GetAllUis();
    }
    protected override IEnumerator ShootCorrutine()
    {
        if (_recharging) yield break;

        while (true)
        {
            if (_cuurrentShoots < maxShoot)
            {
                Shoot();
                _cuurrentShoots++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(timeBetweenShot);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_cuurrentShoots >= maxShoot)
        {
            CancelShoot();
            StartRecharging();
        }
    }

    private void StartRecharging()
    {
        _recharging = true;
        StartCoroutine(RechargeCourotine());

    }

    IEnumerator RechargeCourotine()
    {
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            uIGunUpdaters.ForEach(i => i.UpdateValue(time/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }

        _cuurrentShoots = 0;
        _recharging = false;
    }

    private void UpdateUI()
    {
        uIGunUpdaters.ForEach(i => i.UpdateValue(maxShoot, _cuurrentShoots));
    }

    private void GetAllUis()
    {
        uIGunUpdaters = GameObject.FindObjectsOfType<UIFillUpdate>().ToList();
    }
}
