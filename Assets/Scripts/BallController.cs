using UnityEngine;

public class BallController : MonoBehaviour
{
    public float xSensitivity;
    public float moveSpeed = 6;
    public float T = 6;
    public float A = 4;
    float zPos=0;

    private void LateUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(touchDeltaPosition.x * xSensitivity * Time.deltaTime*0.07f, 0, 0);
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                transform.Translate(Input.GetAxisRaw("Mouse X") * xSensitivity * Time.deltaTime, 0, 0);
            }
        }
    }
    void FixedUpdate()
    {
        zPos += moveSpeed * Time.fixedDeltaTime;
        transform.position = new Vector3(transform.position.x, getBallHeight(T, A), zPos);
    }

    float getBallHeight(float T, float A)
    {
        return A * Mathf.Abs(Mathf.Sin((Mathf.PI / T) * zPos));
    }
}
