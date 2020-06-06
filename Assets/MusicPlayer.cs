using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Invoke("LoadFistScene", 3f);
    }
    void LoadFistScene()
    {
        SceneManager.LoadScene(1);
    }
}
