using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    private BackgroundScroll[] scrollers;

    void Start()
    {
        // make a list of all scrolling scripts in the children of this object
        scrollers = GetComponentsInChildren<BackgroundScroll>();
    }

    public void StopWorld()
    {
        foreach (BackgroundScroll scroller in scrollers)
        {
            scroller.StopScrolling();
        }
    }

    public void StartWorld()
    {
        foreach (BackgroundScroll scroller in scrollers)
        {
            scroller.StartScrolling();
        }
    }
}