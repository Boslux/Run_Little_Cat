using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody2D _rb;
    public Transform playerTransform; // 0=player, 1=spawner position

    [Header("Value")]
    public float speed;
    private float _fixedSpeed=100;
    public float whereObjectGoX;
    public float whereObjectGoY;
    private float _destroyTime=11;
    //
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        PositionControl();
        OnDestroy();
    }
    void Update()
    {
        ObjectMovement();
    }
    void PositionControl()
    {
        float whereX=playerTransform.position.x+transform.position.x; //control player.x position
        float whereY=playerTransform.position.y+transform.position.y; //control player.y position

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
        Vector2 move= new Vector2(whereObjectGoX,whereObjectGoY)*Time.deltaTime*speed*_fixedSpeed;
        _rb.linearVelocity = move;
    }
    void OnDestroy()
    {
        Destroy(gameObject,_destroyTime);
    }
}
