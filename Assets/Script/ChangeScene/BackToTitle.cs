using HellGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load TitleScene
    public void LoadTitleScene()
    {
        GameController.Instance.DestroyOnLoad();
        SceneManager.LoadScene("TitleScene");
    }
}
