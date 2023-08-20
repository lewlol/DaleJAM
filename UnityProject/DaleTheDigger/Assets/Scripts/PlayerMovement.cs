using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement shit
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    //pickaxe and sprite rotation
    public Transform playerCenter; // Empty GameObject at the center of the player
    public GameObject pickaxe; // The pickaxe GameObject

    //Upgrades and shit
    public static int coins = 100; //used for upgrades
    public static int breakingpower = 1; // determins what blocks player can break, each level changes pickaxe sprite too
    public static int stamina = 50; //each block broke loses stamina 
    public static int fortune = 1; //chance to get mroe ores from mining


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        jumping();
        pickaxerotation();
        Debug.Log(breakingpower);
    }

    private void FixedUpdate()
    {
        movement();


    }
    void pickaxerotation()
    {
        {
            // Calculate the angle between playerCenter and mouse position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePos - playerCenter.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the playerCenter (and the attached pickaxe)
            playerCenter.rotation = Quaternion.Euler(0f, 0f, angle);

            // Flip player sprite
            if (mousePos.x < playerCenter.position.x)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;


        }
    }

    void jumping()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void movement()
    {
        // Movement
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

}