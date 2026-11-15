using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class itemGenerator : MonoBehaviour
{
    public float randomValue;
    public GameObject bombprefab;
    public GameObject applePrefb;
    public float time;

    float span = 1.0f;
    float delta = 0f;
    public int ratio = 2;
    float speed = -0.03f;
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;

    }

    // Update is called once per frame
    void Update()
    {


        //randomValue = Random.Range(1, 11);

        //if (randomValue == 2 || randomValue == 8)
        //{
        //    time += Time.deltaTime;
        //    if (time >= 1f)
        //    {
        //        time = 0f;
        //        GameObject item = Instantiate(bombprefab);
        //        int x = Random.Range(-1, 2);
        //        int z = Random.Range(-1, 2);
        //        item.transform.position = new Vector3(x, 4, z);
        //        item.GetComponent<basketContoller>();
        //    }
        //}
        //else
        //{
        //    time += Time.deltaTime;
        //    if (time >= 1f)
        //    {
        //        time = 0f;
        //        GameObject item = Instantiate(applePrefb);
        //        int x = Random.Range(-1, 2);
        //        int z = Random.Range(-1, 2);
        //        item.transform.position = new Vector3(x, 4, z);
        //        item.GetComponent<basketContoller>();
        //    }
        //}

        delta += Time.deltaTime;
        if (delta > span)
        {
            delta = 0f;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= ratio)
            {
                item = Instantiate(bombprefab) as GameObject;
            }
            else
            {
                item = Instantiate(applePrefb) as GameObject;
            }
            int x = Random.Range(-1, 2);
            int z = Random.Range(-1, 2);

            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<iteamContoller>().dropSpeed = this.speed;
            //    }

        }
    }
}
//1초에 한번씩 사과 오브젝트가 떨어지게

//Time.time : 게임 시작 이후 시간을 초 단위로 변환
//    - 특정 시간이 지난 후 발생하려는 작업에 유용
//    예) if(Time.time > 5f) {
//    Debug.Log("5초가 지났습니다.");
//    }

//2.Time.deltaTime : 프레임과 프레임 사이의 걸린 시간
//    -예도 계속 더아거나 누적시키면 일정 시간을 잴 수 있음
//3.Time.fixedDeltaTime : 물리 및 고정 프레임 속도 업데이트에서 수행되는 초 단위의 간격
//    -프레임 속도에 관계 없이 일관된 물리 시뮬레이션을 보장할 때 까지 사용한다
//4.Time.timeScale : 게임 전체에 대한 시간 1이념 실시간의 0,5면 절반의 시간(속도)
//    2면 두배의 시간(속도)
//    0이면 모든 시간은 멈춤 게임 Pause 등에 사용 가능
//5.Time.realtimeSinceStartup : 게임 시작 이후의 시간을 초 단위로 변환 Time.time과 달리 Time.timeScale에 영향을 받지 않음
//    일시정지 중에도 시간을 계속 체크하려면 이거 쓰샘

//이제 20% 확률로 폭탄 80%가 사과 
//    10이 맥스 2 하고 8이 나와야 