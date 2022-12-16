using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private int _perfectSize;
    [SerializeField]
    private RectTransform _table;

    private void Update()
    {
        float width = Screen.width;
        float height = Screen.height;
        var resolution = height / width;
        if (resolution > 0.75f)
        {
            var a = (_table.sizeDelta.x * resolution) / 2;
            Camera.main.orthographicSize = a;
        }
        else
        {
            Camera.main.orthographicSize = _perfectSize;
        }
    }
}
