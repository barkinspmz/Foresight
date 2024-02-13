using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        var sceneChangerAnim = GameObject.Find("SceneChangeAnim");
        animator = sceneChangerAnim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameplayManager.Instance.isLockUnlocked)
        {
            StartCoroutine(SceneChangeNumerator());
        }
    }

    IEnumerator SceneChangeNumerator()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(2f);
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex+1);
    }
}
