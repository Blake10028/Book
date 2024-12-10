using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
 
    public void OpenLevel(int PageId)
    {
        string PageName = "Page " + PageId;
        SceneManager.LoadScene(PageName);
    }
     
}
