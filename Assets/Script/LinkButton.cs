using UnityEngine;

public class LinkButton : MonoBehaviour
{
    public void Link(string link)
    {
        Application.OpenURL(link);
    }

}
