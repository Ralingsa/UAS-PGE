using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class charCtrl : MonoBehaviour
{
    private float moveDir = 0;
    private float dashCount;
    private bool isjump;
    private bool toDash = false;
    private bool isDead = false;
    Animator animSet;

    private float timer = 0.8f;

    void move()
    {
        if (moveDir == 1)
        {
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(4f, 4f, 1f);
        }

        if (moveDir == 2)
        {
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            transform.localScale = new Vector3(-4f, 4f, 1f);
        }
    }

    void moveRight()
    {
        moveDir = 1;
    }

    void moveLeft()
    {
        moveDir = 2;
    }

    void jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
        isjump = true;
        animSet.SetTrigger("jump");
        if (!isjump)
        {
            animSet.SetTrigger("idle");
            animSet.ResetTrigger("jump");
        }
    }

    void Dash()
    {
        Debug.Log("worked");
        if (moveDir == 1)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*150);
        }
        if (moveDir == 2)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 150);
        }
        //StartCoroutine(isDash());
        Debug.Log("dashed");
    }

    // Start is called before the first frame update
    void Start()
    {
        animSet = this.GetComponent<Animator>();
        data.Score.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
            if (!isjump) { animSet.SetTrigger("run"); }
            toDash = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
            if (!isjump) { animSet.SetTrigger("run"); }
            toDash = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            moveDir = 0;
            toDash = false;
            if (!isjump)
            {
                animSet.SetTrigger("idle");
                animSet.ResetTrigger("jump");
                animSet.ResetTrigger("run");
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            moveDir = 0;
            if (!isjump)
            {
                animSet.SetTrigger("idle");
                animSet.ResetTrigger("jump");
                animSet.ResetTrigger("run");
            }
            animSet.SetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isjump)
        {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //dashCount = 0;
            timer += Time.deltaTime;
            if (toDash == true && dashCount == 0)
            {
                Dash();
                toDash = false;
                //dashCount++;
                StartCoroutine(isDash());
            }
        }

        move();
        dead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isjump = false;
        if (collision.gameObject.CompareTag("spike"))
        {
            isDead = true;
        }
    }

    void dead()
    {
        if (isDead == true)
        {
            SceneManager.LoadScene("dead");
        }
    }

    IEnumerator isDash()
    {
        animSet.SetTrigger("dash");
        toDash = false;
        yield return new WaitForSeconds(timer);
        animSet.SetTrigger("run");
        animSet.ResetTrigger("dash");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gems"))
        {
            data.Score.score += 1;
            Destroy(collision.gameObject);
        }
    }
}
