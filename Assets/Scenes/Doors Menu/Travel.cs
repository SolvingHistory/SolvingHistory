using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Kolossi":                
                Invoke("LoadKolossi", 1f);
            break;
            case "Palepafos":                
                Invoke("LoadPalepafos", 1f);
            break;
            case "Panagia":                
                Invoke("LoadPanagia", 1f);
            break;
            default: 
                return;
            break;
        }
    }
    private void LoadKolossi()
    {
        SceneManager.LoadScene(1);
    }

    private void LoadPalepafos()
    {
        SceneManager.LoadScene(2);
    }

    private void LoadPanagia()
    {
        SceneManager.LoadScene(3);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
