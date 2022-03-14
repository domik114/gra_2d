using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    // damage
    [SerializeField] private int damage = 1;
    [SerializeField] private float pushForce = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            Damage dmg = new Damage
            {
                damageAmount = damage,
                pushForce = pushForce,
                origin = transform.position,
            };


            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
