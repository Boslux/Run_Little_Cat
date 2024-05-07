using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreObjectController : MonoBehaviour
{
    public Text scoreText; // Score'un gösterileceği Text objesi
    public Settings score;// Başlangıçta score değeri sıfır

    void Update()
    {
        UpdateScoreText();
    }
    // Score'u artırmak için kullanılan fonksiyon
    public void IncreaseScore(float amount)
    {
        score.scoreT+=amount;
        UpdateScoreText(); // Score değerini güncelle
    }

    // Score değerini güncelleyen fonksiyon
    void UpdateScoreText()
    {
        // scoreText objesinin text özelliğini güncelle
        scoreText.text = "Score:" + score.scoreT;
    }
}
