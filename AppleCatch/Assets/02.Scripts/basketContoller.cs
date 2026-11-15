using UnityEditor.VersionControl;
using UnityEngine;

public class basketContoller : MonoBehaviour
{
    public AudioClip appleSE; //SE는 Sound Effect의 약자    
    public AudioClip bombSE; //SE는 Sound Effect의 약자
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("apple"))
        {
            Destroy(other.gameObject);
            Debug.Log("골인 성공!");
            audio.PlayOneShot(appleSE);
        }
        if (other.gameObject.CompareTag("bomb"))
        {
            Destroy(other.gameObject);
            Debug.Log("아야 쌰갈!");
            audio.PlayOneShot(bombSE);
        }

    }
    
}

   
//Directional Light 태양광처럼 직선으로 한곳을 향해 나란히 가면서 빛을 비추는 라이트가 라이트에서 떨어져도 빛의 세시가 감쇠하지 않는다
//Point Light 전체 방향으로 빛을 빛추는 라이트다 라이트에서 벗어나면 빛의 세시가 감쇠한다
//Spotlight 특정 방향에서 방사상(중앙에서 사방으로 뻗어나간 모양)으로 빛을 비추는 라이트다 라이트에서 벗어나면 빛의 세기가 감쇠한다
//Area Light 직사각의 평면에서 전체 방위로 투사되는 라이트다 라이트를 베이크 할 때만 사용할수 있다.

//탭된 좌표(Input.mousePosition을 바탕으로 바구니를 이동시키는 좌표 계산
//여기서도 스크린 좌표를 월드 좌표로 변환해 사용할수 있도록 스크린 포인트 투 레이 메서드를 사용해 카메라 좌표에서 게임 화면 안쪽 방향으로 향해 나가도록 (Ray)광선을 구합니다.

//이 광선은 콜라이더와 충돌한 것을 감지 가능
//Physics.Raycast 메서드를 사용해 광선이 ㅅ스테이지 오브젝트에 닿았는ㄴ지 알아본다
//P 의 hit 매개변수 앞에 out 키워드가 붙어있다.

//이 키워드는 out에서 계속 메서드 내 값을 변수로 반환해줘라는 의미
//이떄 Raycast 메서드 안에서 광선이 stage와 충돌한 좌표를 hit.point 변수에 채워 반환 그 좌표를 RoundToInt 메서드를 사용해 반올림하고바구니 좌표에 대입한다

//사과 잡았을때 폭탄 잡았을때 구분 어캐 하냐
//    이때 필요한게 바로 태그
//    유니티에서 태그 구조를 사용한다
//    Tag를 사용하면 오브젝트에 특정 이름(태그)을 달수 있어 스크립트에서도 이 태그를 사용해 오브젝트 판별 가능