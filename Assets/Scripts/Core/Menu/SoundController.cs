using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Settings settings;
    public Sprite[] sprite;
    private Image _image;
    void Start()
    {
        _image =GetComponent<Image>();
        _image.sprite=sprite[0];
    }
    void Update()
    {
        if (!settings.soundCheck)
            _image.sprite=sprite[1];
        else
            _image.sprite=sprite[0];
    }
}
