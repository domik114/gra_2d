using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxColidder;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxColidder = GetComponent<BoxCollider2D>();
    }

    // ta funkcja jest lepsza dla fizyki
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        // swap sprite direction, wether you're going left or right
        // (rotating player's sprite depending in which direction is going)
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // make sure we can move in this direction by casting a box there first
        // if the box returns null, we can go
        // checking if player hits something
        // FOR THE Y AXIS
        hit = Physics2D.BoxCast(transform.position, boxColidder.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            // moving 
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // FOR THE X AXIS
        hit = Physics2D.BoxCast(transform.position, boxColidder.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            // moving 
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
