using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // experiance
    [SerializeField] private int xpValue = 1;

    // logic
    [SerializeField] private float triggerLength = 1;
    [SerializeField] private float chaseLength = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    // hitbox
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];
}
