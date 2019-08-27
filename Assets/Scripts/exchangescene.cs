using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class exchangescene : MonoBehaviour {
  //  AsyncOperation async;
    //public GameObject loadingScreenObj;
    //public Slider slider;
	public void changeToScene(int changeTheScene)
	{
        SceneManager.LoadScene(changeTheScene);
        //StartCoroutine(LoadingScreen(changeTheScene));
    }
    public void openUrl()
    {
        Application.OpenURL("http://csewelco.me/");
    }
    /* IEnumerator LoadingScreen(int changeTheScene)
    {
        //loadingScreenObj.SetActive(true);

        async = SceneManager.LoadSceneAsync(changeTheScene);
        async.allowSceneActivation = false;
     /*   while (async.isDone == false)
        {
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation=true;
            }

       
    yield return null;
    }
     }*/
}
