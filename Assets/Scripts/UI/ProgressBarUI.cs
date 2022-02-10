using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image bar;
    private GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
        UpdateBar();
    }

    private void UpdateBar()
    {
        if (gm.curStage == gm.stagesCount) return;

        StartCoroutine(IUpdateBar());
        gm.stages[gm.curStage].onCompletedStage.AddListener(UpdateBar);
    }

    private IEnumerator IUpdateBar()
    {
        float time = 1;
        float target = (float)gm.curStage / (float)gm.stagesCount;
        while (target - bar.fillAmount > 0.005f)
        {
            bar.fillAmount += ((target - bar.fillAmount) / time * Time.deltaTime);
            yield return null;
        }
        bar.fillAmount = target;
    }

}
