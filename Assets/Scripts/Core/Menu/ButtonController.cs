using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public MenuController mc;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            mc.StartGame(); //oyunu başlat

        if (Input.GetButtonDown("Fire2"))
            mc.ExitGame(); //oyundan çık

        if (Input.GetButtonDown("Submit"))
            mc.RestartGame(); //oyunu yeniden başlat

        if (Input.GetButtonDown("Jump"))
            mc.SoundControl(); //ses kontrol
    }
}
