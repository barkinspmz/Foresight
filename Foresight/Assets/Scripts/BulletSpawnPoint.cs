using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    private Color startColor;
    private int lockForSpawner;
    void Start()
    {
        startColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.08410466f, 0.775847f, 0.8490566f);

        GameplayManager.Instance.ShootBullets += ChangeColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lockForSpawner++;
        if (collision.gameObject.tag == "Player" && lockForSpawner == 1)
        {
            GameplayManager.Instance.ShootBulletInvoke();
        }
    }

    private void ChangeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1);
    }
}
