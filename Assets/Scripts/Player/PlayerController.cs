using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float dir = 1;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool Grounded = true;

    [SerializeField]
    private Transform startDoor;
    [SerializeField]
    private GameObject BlackBox;

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpSpeed;

    private bool canRun;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();        
        animator = transform.GetComponent<Animator>();
        animator.SetBool("Grounded",true);
        canRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * dir * speed, transform.position.y, transform.position.z);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                putBox();
            }
        }
    }
            
    public void putBox()
    {
        Instantiate(BlackBox, transform.position, Quaternion.identity);
        transform.position = startDoor.position;
    }

    public void Jump()
    {
        if (Grounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            Grounded = false;
            animator.SetBool("Grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Grounded == false)
        {
            animator.SetBool("Grounded", true);
            Grounded = true;
        }
        else if (collision.gameObject.CompareTag("SideWall"))
        {
            dir *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void SinkPlayer()
    {
        canRun = false;
        StartCoroutine(CloseLevel());
    }

    IEnumerator CloseLevel()
    {
        if (transform.localScale.x > 0)
        {
            while (transform.localScale.x >= 0.05f)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
                yield return new WaitForSeconds(0.07f);
            }
            
        }
        else
        {
            while (transform.localScale.x <= -0.05f)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
                yield return new WaitForSeconds(0.07f);
            }
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
