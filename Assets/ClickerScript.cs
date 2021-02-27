using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerScript : MonoBehaviour
{
    public Button button;
    public Text scoreText;
    public Text timerText;

    int level = 0;          // 레벨
    int count = 0;          // 현재 카운트
    int requireCount = 10;  // 필요한 카운트 (몇 번 눌러야 하는지)

    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClick);
        timer = 30;

        StartCoroutine(TimerCoroutine());
    }

    private void OnButtonClick()
    {
        count++;
        if (count > requireCount)
        {
            count = 0;
            requireCount += 10;
            level++;
        }

        scoreText.text = "레벨 " + level + " (" + count + " / " + requireCount + ")";
    }

    string ConvertToTwoDigit(int x)
    {
        if (x < 10) return "0" + x;
        else return x.ToString();
    }

    string FormatTime(int totalSeconds)
    {
        int minute = totalSeconds / 60;
        int second = totalSeconds % 60;

        return ConvertToTwoDigit(minute) + ":" + ConvertToTwoDigit(second);
    }

    IEnumerator TimerCoroutine()
    {
        while (timer > 0)
        {
            timerText.text = "남은 시간 : " + FormatTime(timer);
            timer--;

            yield return new WaitForSeconds(1);
        }

        timerText.text = "끝!";
        button.interactable = false;
    }
}
