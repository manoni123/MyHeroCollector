using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class ProgressLoader : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private AsyncOperation opertaion;
    public GameObject sliderObj;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        sliderObj.SetActive(true);
        UpdatedProgressUI(0);
        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        opertaion = Application.LoadLevelAsync(sceneName);

        while (!opertaion.isDone)
        {
            UpdatedProgressUI(opertaion.progress);
            yield return null;
        }

        UpdatedProgressUI(opertaion.progress);
        opertaion = null;
        gameObject.SetActive(false);
    }

    void UpdatedProgressUI(float progress)
    {
        slider.value = progress;
    }
}
