using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerAbilityShoot : PlayerAbilityBase
{
    

    public GunBase gunbase;
    public GunBase gunbaseVariant1;
    public GunBase gunbaseVariant2;
    public Transform gunPosition;

    private GunBase _currentGun;
    public FlashColor _flashColor;

    protected override void Init()
    {
        base.Init();

        CreateGun();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
        inputs.Gameplay.ChangeWeaponSlot_1.performed += cts => ChangeGun(gunbaseVariant1);
        inputs.Gameplay.ChangeWeaponSlot_2.performed += cts => ChangeGun(gunbaseVariant2);
    }

    private void Update()
    {
        
    }
    public void CreateGun()
    {
        _currentGun = Instantiate(gunbase, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    public void ChangeGun(GunBase gun)
    {

            Destroy(_currentGun.gameObject);
    
        _currentGun = Instantiate(gun, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        _flashColor?.Flash();
        Debug.Log("Start Shoot");
    }
    
    private void CancelShoot()
    {
        _currentGun.CancelShoot();
        Debug.Log("Cancel Shoot");
    }
}
