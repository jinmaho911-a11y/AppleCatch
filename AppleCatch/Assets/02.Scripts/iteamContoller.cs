using UnityEditor.SceneManagement;
using UnityEngine;

public class iteamContoller : MonoBehaviour
{
    public float dropSpeed = -0.03f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {

        {

            transform.Translate(0, this.dropSpeed, 0);
            if (transform.position.y < -1.0f)
            {
                Destroy(gameObject);
            }
        }

    }
}

//아이템은 아래로 떨어진다.
//아이템들은 바닥보다 아래로 가서 y값이 -보다 작아질때 삭재