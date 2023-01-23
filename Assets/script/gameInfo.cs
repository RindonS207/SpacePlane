using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameInfo : MonoBehaviour
{
    public void resetGame()
    {
        Start();
        playerControl.heart = 100;
        playerControl.isAlive = true;
        points = 0;
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        score_text = score.GetComponent<Text>();
        hightPoints_text = hightPoints_object.GetComponent<Text>();
        heart_text = heart.GetComponent<Text>();
        hightPoints_text.text = "最高分：" + hightPoints;
        dead_info.SetActive(false);
        dead_button.SetActive(false);
    }
    public static float bulletDamage = 10;
    public static float direnDamage = 10;
    public static long points = 0;
    public static long hightPoints = 5000;
    public GameObject score;
    Text score_text;
    public GameObject hightPoints_object;
    Text hightPoints_text;
    public GameObject heart;
    Text heart_text;
    public GameObject dead_info;
    public GameObject dead_button;
    // Update is called once per frame
    void Update()
    {
        if(playerControl.heart >= 0 && playerControl.isAlive)
        {
            heart_text.text = string.Format("生命值：{0}", playerControl.heart);
        }
        else if(playerControl.isAlive)
        {
            heart_text.text = "生命值：0";
        }
        if(points > hightPoints && playerControl.isAlive)
        {
            hightPoints_text.text = string.Format("最高分：{0}",points);
        }
        if(playerControl.isAlive)
        {
            score_text.text = string.Format("分数：{0}", points);
        }
        if(playerControl.isAlive == false)
        {
            heart.SetActive(false);
            hightPoints_object.SetActive(false);
            score.SetActive(false);
            dead_button.SetActive(true);
            dead_info.SetActive(true);
        }
    }
}
