using UnityEngine;
using System.Collections;

public class SlotMachine : MonoBehaviour
{
    public RectTransform[] slots;

    public int length;

    public float speed = 10;

    public int index;

    private void Start()
    {
        length = transform.childCount;
        slots = new RectTransform[length];

        for (int i = 0; i < length; i++)
        {
            slots[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }

        index = length - 1;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        for (int i = 0; i < length; i++)
        {
            slots[i].Translate(0, -speed * Time.deltaTime, 0);

            if (slots[i].anchoredPosition.y <= -150)
            {
                slots[i].anchoredPosition = slots[index].anchoredPosition + new Vector2(0, 100);
                index = i;
            }
        }
    }
}
