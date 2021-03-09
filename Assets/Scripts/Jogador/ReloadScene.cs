using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [Header("     Scene Name")]
    public string Scenename;       //nome da scene que vai recarregar
    [Header("     Time to Reload Scene")]
    public float time;             //tempo que vai levar para recarregar a fase

    private void Update()
    {
        Reloadscene();
    }
    private void Reloadscene()
    {
        //verificando se o player está morto para reiniciar a fase
        if (StatsController.instance.Isalive())
        {
            
            StartCoroutine(DelayForScene(time));
        }
    }
    private IEnumerator DelayForScene(float time)
    {
        Debug.Log("Reload " + Scenename);

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(Scenename);
        
    }
    
}
