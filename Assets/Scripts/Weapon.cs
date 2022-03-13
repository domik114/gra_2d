using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // swing the sword
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            // create a new damage object and send it to the fighter
            Damage dmg = new Damage();
            dmg.damageAmount = damagePoint;
            dmg.pushForce = pushForce;
            dmg.origin = transform.position;

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");
    }
}
