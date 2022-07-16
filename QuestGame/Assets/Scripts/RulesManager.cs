using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] info = new GameObject[5];

    private int counter;

    private void Start()
    {
        counter = 0;
    }

    public void OnNextButtonClick()
    {
        info[counter].SetActive(false);
        counter++;
        try
        {
            info[counter].SetActive(true);
        } 
        catch
        {
            counter = 0;
        } 
        finally
        {
            info[counter].SetActive(true);
        }
        
    }

    public void OnPrevButtonClick()
    {
        info[counter].SetActive(false);
        counter--;

        try
        {
            info[counter].SetActive(true);
        }
        catch
        {
            counter = info.Length - 1;
        }
        finally
        {
            info[counter].SetActive(true);
        }
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
