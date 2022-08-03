using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    void Damage(float damage);

    void Damage(float damage, Vector3 dir);
}
