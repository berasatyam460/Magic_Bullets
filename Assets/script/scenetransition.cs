using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{

    Animator transitionPanel;

    // Start is called before the first frame update
    void Start()
    {
        transitionPanel = GetComponent<Animator>();
    }

   public void LoadScene(int index)
    {
        StartCoroutine(transition(index));
    }

    IEnumerator transition(int index)
    {
        transitionPanel.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);

    }

    public void exit (){
        Application.Quit();
        Debug.Log("quit");

    }
}
