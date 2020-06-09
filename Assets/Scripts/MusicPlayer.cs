using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake()//Stops the music from stopping.
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFistScene", 3f);
    }
    void LoadFistScene()
    {
        SceneManager.LoadScene(1);
    }
}
