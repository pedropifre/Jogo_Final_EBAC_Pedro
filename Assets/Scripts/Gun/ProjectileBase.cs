using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    
    public float timeToDestroy = 2f;
    public float speed = 50f;
    public int damageAmount = 1;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.transform.GetComponent<IDamagable>();

        if (damageable!=null) damageable.Damage(damageAmount);

        Destroy(gameObject);
    }
}
