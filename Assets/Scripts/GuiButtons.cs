using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuiButtons : MonoBehaviour
{
    Scene m_Scene;
    string sceneName;
    string sceneDestiny = "Game";
    static int sceneNumber = 0;
    public void CambiarEscena()
    {
        SceneManager.LoadScene(sceneDestiny);
    }

    private void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if(sceneName == "Tienda")
        {
            sceneNumber++;
            sceneDestiny = "Game " + sceneNumber;
        }

    }
    public void AbrirPagina()
    {
        Application.OpenURL("https://www.today.com.co");
    }
}
