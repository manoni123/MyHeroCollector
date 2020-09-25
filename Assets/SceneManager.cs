using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    ProgressLoader _loader;
    [SerializeField]
    private string levelName;

    private void Awake()
    {
        _loader = FindObjectOfType<ProgressLoader>();
    }
    public void LoadGame()
    {
        _loader.LoadScene(levelName);
    }
}
