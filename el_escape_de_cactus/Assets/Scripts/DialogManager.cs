using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public bool isActive=false;
    public static DialogManager instance;
    public Text dialogText;
    public GameObject dialogBox;
    private bool justStarted;
    [TextArea(3,10)]
    public string[] dialogLines;
    public int currentLine;


    // Start is called before the first frame update
    private void Awake()
    {
        instance=this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine>=dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        Time.timeScale=1;
                        isActive=false;
                    }else
                    {
                        isActive=true;
                        CheckName();
                        StopAllCoroutines();
                        StartCoroutine(TypeDialog(dialogLines[currentLine]));
                    }
                }else
                {
                    justStarted=false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines){
        dialogLines=newLines;
        currentLine=0;
        CheckName();
        StopAllCoroutines();
        StartCoroutine(TypeDialog(dialogLines[currentLine]));dialogBox.SetActive(true);
        justStarted=true;
        Time.timeScale=0;
    }
    IEnumerator TypeDialog(string sentence){
        dialogText.text="";
        foreach(char letter in sentence.ToCharArray()){
            dialogText.text+=letter;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    public void CheckName(){
        if (dialogLines[currentLine].StartsWith("c-")){
            currentLine++;
        }
        if (dialogLines[currentLine].StartsWith("k-")){
            currentLine++;
        }
    }



}
