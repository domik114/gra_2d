using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int HP = 10;
    public int maxHP = 10;
    public float pushRecoverySpeed = 0.2f;

    // immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // push
    protected Vector3 pushDirection;

    // all fighters should be able to receive damage and die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            HP -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText("-" + dmg.damageAmount.ToString(), 30, Color.red, transform.position, Vector3.zero, 0.5f);

            if (HP <= 0)
            {
                HP = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        
    }
}
