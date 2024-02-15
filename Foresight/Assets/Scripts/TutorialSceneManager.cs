using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSceneManager : MonoBehaviour
{
    public GameObject[] arrowKeysImages;
    private bool tutorialArrowKeyLock = false;
    public Animator tutorialAnimator;
    public TextMeshProUGUI tutorialText;

    public GameObject greenBoxWhereTheLevelEndIndicator;
    public GameObject greenBoxWhereTheInputsIndicator;
    void Start()
    {
        StartCoroutine(WaitingForLevelChangeTut());
    }

    IEnumerator WaitingForLevelChangeTut()
    {
        yield return new WaitForSeconds(1);
        tutorialAnimator.SetTrigger("PopUpGo");
        yield return new WaitForSeconds(7f);        
        tutorialAnimator.SetTrigger("PopUpBack");
        tutorialArrowKeyLock = true;
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < arrowKeysImages.Length; i++)
        {
            arrowKeysImages[i].SetActive(false);
        }
        tutorialAnimator.SetTrigger("PopUpGo");
        greenBoxWhereTheInputsIndicator.SetActive(true);
        tutorialText.text = "The inputs that you give appears there before the game start.";
        yield return new WaitForSeconds(6f);
        tutorialAnimator.SetTrigger("PopUpBack");
        greenBoxWhereTheInputsIndicator.SetActive(false);
        yield return new WaitForSeconds(1f);
        tutorialAnimator.SetTrigger("PopUpGo");
        tutorialText.text = "You have to reach this green area after completing all your moves to pass level.";
        greenBoxWhereTheLevelEndIndicator.SetActive(true);
        yield return new WaitForSeconds(7f);
        greenBoxWhereTheLevelEndIndicator.SetActive(false);
        tutorialAnimator.SetTrigger("PopUpBack");

    }

}
