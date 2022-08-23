using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded; //Saber si esta saltando o en el suelo.
    private Rigidbody2D rb;//RigidBody.
    private float input;//Direccion del input. Talvez se cambie para hacer el mirror.
    public Animator animator;

    public float jumpForce;//Jaja como el juego. (Fuerza acumulada del salto)
    private float jumpspeed = 4.3f; //Velocidad a la que se salta;
    private float movespeed = 3.0f;
    public ChargeBar chargeBar;

    private float timer = 0.0f;
    public bool movelock = true;
    public LayerMask groundMask;//Layer considerada como ground.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        jumpForce = 0f;
        isGrounded = true;
        chargeBar.setMaxCharge(1.5f);//Remanente de Kobeni Cat. Se puede quitar.
        ChargeUI(0f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().isPlaying || DialogueManager.GetInstance().pickObject )//No se puede mover durante Dialogo.
        {
            return;
        }

        if (isGrounded){
          animator.SetBool("Suelo", true);
          if (timer > 0.3f){
            movelock = true;
          } else {
            timer += Time.deltaTime;
          }
        }else{
          animator.SetBool("Suelo", false);
        }

        //Acumula fuerza para saltar
        if ((Input.GetButton("Jump")) && isGrounded && movelock)
        {
            //idle = false;
            animator.SetBool("Salte", true);
            jumpForce += Time.deltaTime;
            ChargeUI(jumpForce, true);
        }

        if(jumpForce > 0f && !isGrounded){
            //
            animator.SetBool("Salte", false);
          Invoke("ResetJump", 0.05f);
        }

        //Salto totalmente cargado.
        if (jumpForce >= 1.5f && isGrounded)
        {
            input = Input.GetAxisRaw("HorizontalKey");
            float tmp_x = input * jumpspeed;
            float tmp_y = jumpForce * 6.66f;
            rb.velocity = new Vector2(tmp_x, tmp_y);
            animator.SetBool("Salte", false);
            SoundController.PlaySound("jump");
            movelock = false;
            timer = 0.0f;
            Invoke("ResetJump", 0.05f);
        }

        //Gana la habilidad de saltar.
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            if (isGrounded)//Salto prematuro. sin carga completa.
            {
                input = Input.GetAxisRaw("HorizontalKey");
                rb.velocity = new Vector2(input * jumpspeed, jumpForce * 6.66f);
                animator.SetBool("Salte", false);
                SoundController.PlaySound("jump");
                movelock = false;
                timer = 0.0f;
                Invoke("ResetJump", 0.05f);
            }
        }

        if ((Input.GetButton("HorizontalKey")) && isGrounded && !Input.GetButton("Jump") && movelock)
        {
            animator.SetBool("Running", true);
            input = Input.GetAxisRaw("HorizontalKey");
            if (input < 0.0f){
              transform.localScale = new Vector3(-1.3f,1.3f,1.0f);
            }else if(input > 0.0f){
              transform.localScale = new Vector3(1.3f,1.3f,1.0f);
            }
            rb.velocity = new Vector2(input*movespeed, 0.0f);
            input = 0.0f;
        }else{
            animator.SetBool("Running", false);
        }
    }

    void LateUpdate(){
      //Checa si el jugador se sobrepone con una capa marcada suelo.
      isGrounded = Physics2D.OverlapArea (new Vector2(transform.position.x - 0.54f, transform.position.y -0.70f),
        new Vector2(transform.position.x + 0.54f, transform.position.y - 0.71f), groundMask);
    }

    void OnCollisionEnter2D(Collision2D collision){
      if (collision.collider.GetType() == typeof(PolygonCollider2D)){
          Debug.Log("ENTRE AL COLISIONADOR");
          SoundController.PlaySound("jump");
      }
    }


    void OnDrawGizmos (){
      Gizmos.color = new Color (0,1,0,0.5f);
      Gizmos.DrawCube (new Vector2 (transform.position.x , transform.position.y - 0.71f),
      new Vector2 (1, 0.01f));
    }
    void ResetJump()
    {
        jumpForce = 0;
        input = 0;
        ChargeUI(jumpForce, false);
    }

    private void ChargeUI(float charge, bool toggle)
    {
        chargeBar.setCharge(charge);
        chargeBar.toggleUI(toggle);
    }

}
