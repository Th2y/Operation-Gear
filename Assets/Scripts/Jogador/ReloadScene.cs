using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [Header("     Scene Name")]
    private string scenename;       //nome da scene que vai recarregar
    [Header("     Time to Reload Scene")]
    private float time;             //tempo que vai levar para recarregar a fase

    private void Start()
    {
        scenename = SceneManager.GetActiveScene().name;
    }

    public void Reloadscene()
    {
        //verificando se o player está morto para reiniciar a fase        
        StartCoroutine(DelayForScene(time));
    }

    private IEnumerator DelayForScene(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(scenename);        
    }    
}
