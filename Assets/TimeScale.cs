using UnityEngine;
using YG;
using System.Collections;

public class TimeScale : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private void OnEnable()
    {
        OnShow();
    }

    public void OnShow()
    {
        StartCoroutine(Timer());
        Time.timeScale = 0;

    }

    public void OnHide()
    {
        Time.timeScale = 1;
        ShowAd();
        gameObject.SetActive(false);
    }

    public void ShowAd()
    {
        YandexGame.FullscreenShow();
    }

    private IEnumerator Timer()
    {
        int count = objects.Length - 1;
        objects[count].SetActive(true);

        while(true)
        {
            yield return new WaitForSecondsRealtime(objects.Length/objects.Length);

            if(count == 0)
            {
                objects[count].SetActive(false);
                OnHide();
                yield return null;

            }

            objects[count].SetActive(false);
            count--;
            objects[count].SetActive(true);

        }

    }

    //[SerializeField] private Move Move;
    //[SerializeField] private Rigidbody Rigidbody;
    //private void OnEnable()
    //{
    //    Move.enabled = false;
    //    Rigidbody.isKinematic = true;
    //}

    //private void OnDisable()
    //{
    //    Move.enabled = true;
    //    Rigidbody.isKinematic = false;

    //}
}
