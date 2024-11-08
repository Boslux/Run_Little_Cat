using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    public ScoreObjectController scoreController; // ScoreObjectController bileşenine erişim

    Rigidbody2D _rb;
    Animator _anim;
    Mover _mover;
    Lick _lick;
    GameOverControl _gameOverControl;
    AudioSource _scoreSound;

    [Header("Value")]
    public bool isLive = true;
    public float speed;
    private float dieTime = 0.65f;
    public int scoreIncreaseAmount = 10;

    private void Awake()
    {
        Component();
        _scoreSound.Stop();
    }
    void Component()
    {
        _scoreSound=GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
        _lick = GetComponent<Lick>();
        _gameOverControl = GetComponent<GameOverControl>();
    }

    void Start()
    {
        // scoreController bileşenini başlat
        scoreController = GetComponent<ScoreObjectController>();
    }
    private void Update()
    {
        _lick.Licking(_anim);
    }
    void FixedUpdate()
    {
        if (isLive)
        {
            _mover.Movement(speed, _rb, _anim);
        }else
        {
            _rb.linearVelocity=Vector2.zero;
        }
    }
    public void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("ScoreObject"))
        {
            // Düşman ile çarpışma durumunda score artışı yap
            scoreController.IncreaseScore(scoreIncreaseAmount);
            _scoreSound.Play();
        }
        else if (cls.gameObject.CompareTag("Enemy"))
        {
            _gameOverControl.GameOver(_anim, dieTime);
            isLive = false;
        }

    }
}

