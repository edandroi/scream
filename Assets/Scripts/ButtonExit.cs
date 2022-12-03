using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    public void ExitNow()
    {
        GameManager.initialPlay = false;
        ES3.Save("initialPlay", GameManager.initialPlay);
        Application.Quit();
    }
}
