using UnityEngine;
using UnityEngine.UIElements;

public class itemGenerator : MonoBehaviour
{
    public GameObject applePrefb;
    public float time;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            time = 0f;
            GameObject apple = Instantiate(applePrefb);

            apple.GetComponent<basketContoller>();
        }
     
       

    }
}
//1초에 한번씩 사과 오브젝트가 떨어지게