using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject player;
    private float destroyTime = 3;
    void Start()
    {
        OnDestroy();
    }
    void OnDestroy()
    {
        Destroy(gameObject,destroyTime);
    }
    void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
