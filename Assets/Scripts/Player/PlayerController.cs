using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float dir = 1;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool Grounded = true;

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpSpeed;


    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();        
        animator = transform.GetComponent<Animator>();
        animator.SetBool("Grounded",true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * dir * speed, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            Grounded = false;
            animator.SetBool("Grounded",false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Grounded==false)
        {
            animator.SetBool("Grounded",true);
            Grounded = true;
        }else if (collision.gameObject.CompareTag("SideWall"))
        {
            dir *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
