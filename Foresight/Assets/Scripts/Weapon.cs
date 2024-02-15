using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPos;

    private Color startColor;
    private Color targetColor;
    void Start()
    {
        GameplayManager.Instance.ShootBullets += ShootBullet;
        startColor = this.GetComponent<SpriteRenderer>().color;
        targetColor = new Color(0.08410466f, 0.775847f, 0.8490566f);
        this.gameObject.GetComponent<SpriteRenderer>().color = targetColor;
        GameplayManager.Instance.ShootBullets += ChangeColor;
    }

    void ShootBullet()
    {
        Instantiate(_bullet, _spawnPos.position, Quaternion.identity);
    }

    void ChangeColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = startColor;
    }
}
