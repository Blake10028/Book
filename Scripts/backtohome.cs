using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backtohome : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private AudioClip changepage;
    bool LoadingInitiated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onclick()
    {
        if (!LoadingInitiated)
        {
            StartCoroutine(DelayedLoad());
            LoadingInitiated = true;
        }
    }


    IEnumerator DelayedLoad()
    {
        //Play the clip once
        SoundManager.instance.PlaySoundFxClip(changepage, transform, 1f);

        //Wait until clip finish playing
        yield return new WaitForSeconds(changepage.length);

        //Load scene here
        SceneManager.LoadScene(sceneName);

    }
}
