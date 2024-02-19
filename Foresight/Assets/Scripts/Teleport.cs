using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private GameObject destroyTeleport;
    [SerializeField] private int indexIncrease;
    private PlayerMovement _pMovement;

    private bool lockForDoItTwice = false;

    private AudioManager _audioManager;
    private void Start()
    {
        _audioManager= GameObject.Find("AudioManager").GetComponent<AudioManager>();    
        var playerObj = GameObject.Find("PlayerObj");
        _pMovement = playerObj.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !lockForDoItTwice)
        {
            _audioManager.PlayAudioClip(_audioManager.teleportationSound);
            StartCoroutine(TeleportNum(collision));
            lockForDoItTwice = true;
        }
    }

    IEnumerator TeleportNum(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        collision.gameObject.GetComponent<PlayerMovement>().currentPlatformerIndex += indexIncrease;
        _pMovement.currentTargetPos = targetPos.position;
        collision.gameObject.transform.position = targetPos.position;
        Destroy(destroyTeleport);
    }
}
