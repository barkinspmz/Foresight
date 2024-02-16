using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    private Color startColor;
    private bool lockForSpawner;
    void Start()
    {
        lockForSpawner = false;
        startColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.08410466f, 0.775847f, 0.8490566f);

        GameplayManager.Instance.ShootBullets += ChangeLock;
        GameplayManager.Instance.ShootBullets += ChangeColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !lockForSpawner)
        {
            GameplayManager.Instance.ShootBulletInvoke();
            lockForSpawner = true;
        }
    }

    private void ChangeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
    }

    private void ChangeLock()
    {
        lockForSpawner = true;
    }

}
