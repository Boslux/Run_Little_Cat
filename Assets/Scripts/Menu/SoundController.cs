using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Settings settings;
    public Sprite[] sprite;
    private Image image;
    void Start()
    {
        image =GetComponent<Image>();
        image.sprite=sprite[0];
    }
    void Update()
    {
        if (!settings.soundCheck)
            image.sprite=sprite[1];
        else
            image.sprite=sprite[0];
    }
}
