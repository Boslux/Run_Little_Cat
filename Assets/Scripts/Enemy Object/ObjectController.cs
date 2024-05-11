using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody2D rb;
    public Transform[] transforms; // 0=player, 1=spawner position

    [Header("Value")]
    public float speed;
    private float fixedSpeed=100;
    public float whereObjectGoX;
    public float whereObjectGoY;
    private float destroyTime=11;
    //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PositionControl();
        OnDestroy();
    }
    void Update()
    {
        ObjectMovement();
    }
    void PositionControl()
    {
        float whereX=transforms[0].position.x+transform.position.x; //control player.x position
        float whereY=transforms[0].position.y+transform.position.y; //control player.y position

        //Control Right and Left spawner position
        if(whereX<0)
        {
        whereObjectGoX=1;
        }
        else if(whereX>0)
        {
        whereObjectGoX=-1;
        }
        
        //Control Top and Bottom spawner position
        if(whereY<0)
        {
        whereObjectGoY=1;
        }
        else if(whereY>0)
        {
        whereObjectGoY=-1;
        }
    }
    void ObjectMovement()
    {
        Vector2 move= new Vector2(whereObjectGoX,whereObjectGoY)*Time.deltaTime*speed*fixedSpeed;
        rb.velocity = move;
    }
    void OnDestroy()
    {
        Destroy(gameObject,destroyTime);
    }
}
