using UnityEngine;
using UnityEngine.UI;
public class GameManeger : MonoBehaviour
{
    public Text TimeText;
    public Text scoreText;
    float time = 30.0f;
    int score = 0;

    public GameObject generater;
    public void GetAplle()
    {
        this.score += 100;
    }
    public void GetBomb()
    {
        this.score /= 2;
    }

    void Update() { 
        time -= Time.deltaTime;
    
        if(time < 0)
        {
            time = 0;
            generater.GetComponent<itemGenerator>().SetParameter(10000.0f, 0, 0);
        }
        else if (0<=time && time < 5)
        {
            generater.GetComponent<itemGenerator>().SetParameter(0.7f, -0.04f, 3);
        }
        else if (5 <= time && time < 12)
        {
            generater.GetComponent<itemGenerator>().SetParameter(0.5f, -0.05f, 6);
        }
        else if (12 <= time && time < 23)
        {
            generater.GetComponent<itemGenerator>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (23 <= time && time < 30)
        {
            generater.GetComponent<itemGenerator>().SetParameter(1.0f, -0.03f, 2);
        }
        TimeText.text = "남은 시간: " + time.ToString("F2");
        scoreText.text = score.ToString() + " Point";
    }
}
