using UnityEngine;

public class Bullet : MonoBehaviour
{
    private enum Direction { goLeft, goRight, goDown, goTop };
    [SerializeField] Direction direction;

    [SerializeField] private float movementSpeed;

    void Update()
    {
        transform.Rotate(0, 0, 1);

        switch (direction)
        {
            case Direction.goLeft:
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * movementSpeed;
                break;
            case Direction.goRight:
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
                break;
            case Direction.goDown:
                transform.position += new Vector3(0, -1, 0) * Time.deltaTime * movementSpeed;
                break;
            case Direction.goTop:
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime * movementSpeed;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameplayManager.Instance.DeadConditionInvoke();
            Destroy(this.gameObject);
        }
    }
}
