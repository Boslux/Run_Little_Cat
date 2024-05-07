using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody2D rb;
    private Animator anim;
    public ScoreObjectController scoreController; // ScoreObjectController bileşenine erişim

    [Header("Value")]
    public float speed;
    public float fixedSpeed=100;
    private float dieTime=0.65f;
    public int scoreIncreaseAmount = 10; 

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
                
        // scoreController bileşenini başlat
        scoreController = GetComponent<ScoreObjectController>();
    }

    void FixedUpdate()
    {
        Movement(speed);
        Licking();
    }
    //Just Move config
    public void Movement(float speed)
    {
        float moveSpeed = Time.fixedDeltaTime * speed * fixedSpeed;
        //Movement Codes
        float hMove=Input.GetAxis("Horizontal")*moveSpeed;
        float vMove=Input.GetAxis("Vertical")*moveSpeed;
        Vector2 Move=new Vector2(hMove,vMove);
        //RigidBody2D
        rb.velocity = Move;

        
        //Run Anim Control
        anim.SetFloat("run",rb.velocity.magnitude);

        //Scale Control
        if (hMove>0)
        {
            transform.localScale=new Vector2(1,1);
            anim.SetBool("runing",true);
        }
        else if (hMove<0)
        {
            transform.localScale=new Vector2(-1,1);
            anim.SetBool("runing",true);
        }
        else
            anim.SetBool("runing",false);      
    }
     void Licking()
    {
        if(Input.GetButton("Fire1"))
            anim.SetBool("lick",true);
        
        StartCoroutine(LickerTurnFalse());
        
    }
    IEnumerator LickerTurnFalse()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("lick", false);
    }
    void OnDestroy()
    {
        anim.SetTrigger("destroy");
        Destroy(gameObject,dieTime);
        StartCoroutine(Load());
    }
    public IEnumerator Load()
    {
        yield return new WaitForSeconds(dieTime-0.1f);
        SceneManager.LoadScene(2);
    }
    public void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("ScoreObject"))
        {
            // Düşman ile çarpışma durumunda score artışı yap
            scoreController.IncreaseScore(scoreIncreaseAmount);
        }
        else if(cls.gameObject.CompareTag("Enemy"))
            OnDestroy();
        
    }  
}

