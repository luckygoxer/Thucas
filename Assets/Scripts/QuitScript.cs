using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public void Quit()
    {
        GetComponent<AudioSource>().Play();
        Invoke("QuitNow", 0.1f);
    }

    void QuitNow()
    {
        Application.Quit();
    }
}
