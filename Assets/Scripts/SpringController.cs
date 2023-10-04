using UnityEngine;

public class SpringController : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.4f);
        }
    }
}
