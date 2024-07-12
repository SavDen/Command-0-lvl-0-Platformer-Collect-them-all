using UnityEngine;
using UnityEngine.UI;
using YG;

public class SceneSave : MonoBehaviour
{
    static private bool[] SaveLevel;
    [SerializeField] private Button[] _levelsBt;
    



    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();

        }

        for (int i = 0; i < _levelsBt.Length; i++)
        {
            if (SaveLevel[i])
            {
                _levelsBt[i].interactable = true;

            }

        }
    }

    public void GetLoad()
    {
        SaveLevel = YandexGame.savesData.openLevel;
    }

    public void MySave()
    {
        YandexGame.savesData.openLevel = SaveLevel;

        YandexGame.SaveProgress();
    }

    static public void Save(int count)
    {
        SaveLevel[count] = true;
        SceneSave s = new SceneSave();
        s.MySave();
    }
}
