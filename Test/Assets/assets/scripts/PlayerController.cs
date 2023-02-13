using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    private void Update()
    {
        if  (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // 
            //if (input.x != 0) input.y = 0;

            if (input  != Vector2.zero )
            {
                var targerPos = transform.position;
                targerPos.x += input.x;
                targerPos.y += input.y;

                StartCoroutine(Move(targerPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

}


