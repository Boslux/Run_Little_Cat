using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public MenuController mc;
    void Update()
    {
        MenuControl();
    }
    void MenuControl()
    {
        if(Input.GetButtonDown("Fire1"))
            mc.StartGame();
        if(Input.GetButtonDown("Fire2"))
            mc.ExitGame();
        if(Input.GetButtonDown("Submit"))
            mc.RestartGame();
        if(Input.GetButtonDown("Jump"))
            mc.SoundControl();
    }
}
