using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusControl : MonoBehaviour
{

    //Movement Stuff
    public float moveForce = 7f;
    private float velocity = 1f;
    public float sprintForce;

    //Jump Stuff
    public float jumpForce = 7f;
    public float jumpLimiter = .7f;
    private float rememberGroundedFor = .05f;
    private float lastTimeGrounded;

    //Ground Check
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    //Bools
    private bool isJumping;
    private bool isGrounded;
    private bool isSprinting;
    private bool isShroom;
    private bool isMoving;

    //Sprint Stuff
    public GameObject mainPlayer;
    public GameObject energyBar;

    //Other
    private float deltaT;
    public int dream;
    private int tDream;
    public Text dreams;
    public Text tutorialDream;
    public GameObject targetUI;
    public GameObject cameraBorder1;
    public GameObject cameraBorder2;
    public GameObject cameraBorder3;


    #region Components
    Rigidbody2D rb2;
    Animator anim;
    SpriteRenderer sr;
    AudioSource audioSrc;

    #endregion Components
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
        deltaT = 0;
    }

    // Update is called once per frame
    void Update()
    {
        #region Basic Movement


        if (isGrounded == true)
        {
            if (Input.GetButton("Jump"))
            {
                anim.SetBool("inJump", true);
            }
        }


        if (isGrounded == true || Time.time - lastTimeGrounded <= rememberGroundedFor)
        {
            if (Input.GetButton("Jump"))
            {
                rb2.velocity = new Vector2(rb2.velocity.x, jumpForce);
                anim.SetBool("inJump", true);
            }


        }

        if (isGrounded == true)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * moveForce * velocity;
            rb2.velocity = new Vector2(moveBy, rb2.velocity.y);
        }
        else if (isGrounded == false && isSprinting == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * moveForce * velocity * jumpLimiter;
            rb2.velocity = new Vector2(moveBy, rb2.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftShift) && mainPlayer.GetComponent<PlayerStats>().energy > 0)
        {
            deltaT += Time.deltaTime;
            float x = Input.GetAxisRaw("Horizontal");
            float moveBy = x * moveForce * velocity * sprintForce;
            rb2.velocity = new Vector2(moveBy, rb2.velocity.y);

            isSprinting = true;
            if (deltaT > 2)
            {
                EnergyGet();
                UpdateEnergyBar();
                deltaT = 0;
            }

        }
        else
        {
            isSprinting = false;
        }

        if (rb2.velocity.x != 0 && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();


        anim.SetFloat("walkSpeed", Mathf.Abs(rb2.velocity.x));

        if (isShroom == true)
        {
            rb2.velocity = new Vector2(20, 5);
            Invoke("Mushroom", .75f);
        }

        //Anim Speed
        if (Mathf.Abs(rb2.velocity.x) > 0.01)
        {
            anim.speed = Mathf.Abs(rb2.velocity.x) * .1f;
        }
        else
        {
            anim.speed = 0.4f;
        }
        #endregion Basic Movement

        #region Flip
        //Flipping
        if (rb2.velocity.x >= 0.05)
        {
            sr.flipX = true;

        }
        else if (rb2.velocity.x <= 0.05)
        {
            sr.flipX = false;

        }
        #endregion Flip

        #region Falling Anim
        //Falling
        if (rb2.velocity.y > 0)
        {
            isJumping = true;
        }

        if (rb2.velocity.y <= 0)
        {
            isJumping = false;
        }

        if (isGrounded == false && isJumping == false)
        {
            anim.SetBool("isFalling", true);
        }

        if (isGrounded == true)
        {
            anim.SetBool("isFalling", false);
        }
        #endregion Falling Anim

        #region Ground
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
            anim.SetBool("inJump", false);
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
        #endregion Ground

        #region Dreams
        if (tDream == 1)
        {
            tutorialDream.text = "1/1".ToString();
        }

        if(dream == 0)
        {
            dreams.text = "0/5".ToString();
        }
        if (dream == 1)
        {
            dreams.text = "1/5".ToString();
        }
        if (dream == 2)
        {
            dreams.text = "2/5".ToString();
        }
        if (dream == 3)
        {
            dreams.text = "3/5".ToString();
        }
        if (dream == 4)
        {
            dreams.text = "4/5".ToString();
        }
        if (dream == 5)
        {
            dreams.text = "5/5".ToString();
        }
        



        #endregion Dreams

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "camera border")
        {
            anim.SetBool("isDead", true);
        }
        else if (collision.tag != "camera border")
        {
            anim.SetBool("isDead", false);
        }

        if (collision.tag == "shroom")
        {
            isShroom = true;
        }

        if (collision.tag == "dream")
        {
            Invoke("Dream", .07f);
        }

        if (collision.tag == "tdream")
        {
            Invoke("TDream", .085f);
        }

        if (collision.tag == "drain")
        {
            Drain();
            UpdateEnergyBar();
        }

        if (collision.tag == "death" || collision.tag == "camera border")
        {
            cameraBorder1.GetComponent<AudioSource>().volume = 0;
            cameraBorder2.GetComponent<AudioSource>().volume = 0;
            cameraBorder3.GetComponent<AudioSource>().volume = 0;
            Death();

        }



    }

    private void UpdateEnergyBar()
    {
        float percent = (float)mainPlayer.GetComponent<PlayerStats>().energy /
            (float)mainPlayer.GetComponent<PlayerStats>().maxEnergy;
        energyBar.GetComponent<EnergyBar>().UpdateEnergyBar(percent);

    }

    private void EnergyGet()
    {
        mainPlayer.GetComponent<PlayerStats>().energy -= 1;
    }

    private void Mushroom()
    {
        isShroom = false;
    }

    private void Dream()
    {
        dream += 1;
    }

    private void TDream()
    {
        tDream += 1;
    }

    private void Drain()
    {
        mainPlayer.GetComponent<PlayerStats>().energy -= 3;
        if (mainPlayer.GetComponent<PlayerStats>().energy < 0)
        {
            mainPlayer.GetComponent<PlayerStats>().energy = 0;
        }
    }

    private void Death()
    {
        Destroy(mainPlayer);
        targetUI.SetActive(!targetUI.activeSelf);
        AutoScrollCamera.step = 0.0f;
        BackgroundMoving.step = 0.0f;
        MidgroundMoving.step = 0.0f;

    }



}

