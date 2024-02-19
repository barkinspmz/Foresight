using UnityEngine;

public class StartSceneBoxAnim : MonoBehaviour
{
    [SerializeField] private Animator _pAnim;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _pAnim.SetTrigger("GoRight");
        }
    }
}
