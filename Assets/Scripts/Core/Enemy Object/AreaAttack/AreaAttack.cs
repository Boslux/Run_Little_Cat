using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    SpriteRenderer sp;

    public float decreaseSpeed = 5f; // Opaklık azalma hızı
    float currentAlpha = 0.8f; // Başlangıçta opaklık değeri 1 (tamamen opak)
    void Start()
    {
        sp=GetComponent<SpriteRenderer>();
        Attack();
    }
    void Attack()
    {
        StartCoroutine(DecreaseAlphaOverTime());
    }
    void DestroyAreaAttack()
    {
        Destroy(gameObject,1.6f);
        Debug.Log("Hoşçakal");
    }
    IEnumerator DecreaseAlphaOverTime()
{
    while (currentAlpha > 0f)
    {
        currentAlpha -= Time.deltaTime * decreaseSpeed; // Opaklık değerini azalt
        Color color = sp.color;
        color.a = currentAlpha; // Opaklık değerini ayarla
        sp.color = color; // Rengi uygula

        if(color.a<=20)
            DestroyAreaAttack();
        yield return null;
    }
}
}
