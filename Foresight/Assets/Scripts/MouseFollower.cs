using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    Vector2 goMid, goLeft, goRight;
    Vector2 targetPos;

    public float movementSpeed;
    void Start()
    {
        goMid = new Vector2(4, 0);
        goLeft = new Vector2(2, 0);
        goRight = new Vector2(6, 0);
    }

    void Update()
    {
        Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(camPos);
        if(camPos.x > 5.37)
        {
            targetPos = goRight;
        }

        if (camPos.x < 5.37 && camPos.x > 2.39)
        {
            targetPos = goMid;
        }

        if (camPos.x < 2.39)
        {
            targetPos = goLeft;
        }

        if (Vector2.Distance(transform.position,targetPos)>0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * movementSpeed);
        }

    }
}
