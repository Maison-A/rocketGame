using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
    void Update()
    {
        QuitGame();    
    }

    public void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quiting app");
            Application.Quit();
        }
    }
}
    
