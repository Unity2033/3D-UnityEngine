using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // float x 라는 변수에 InputManager에 있는 수평 정보를 저장합니다.
        float z = Input.GetAxis("Vertical"); // float y 라는 변수에 InputManager에 있는 수직 정보를 저장합니다.

        Vector3 dir = new Vector3(x, 0, z); // Vector3 변수를 설정하고 x 와 z 값에 설정합니다.

        // Time.deltaTime은 전 프레임이 완료되기 까지 걸린 시간입니다.
        // Time.deltaTime은 컴퓨터마다 다른 값을 가집니다.
        // (24~60) FPS * speed * 1/(24~60) FPS(Time.deltaTime)로 계산되며 결국은 speed의 값만 가지게 됩니다.

        // transform.Translate : 프레임마다 일정 속도를 가지고 일정거리만큼 계속 이동하는 함수입니다. 
        transform.Translate(dir.normalized * Time.deltaTime);

        // normalized( ) : 벡터의 크기를 1로 설정하여 오브젝트가 균일한 이동을 할 수 있도록 만들어 줍니다.
        // 대각선 움직임 같은 경우에는 (1,0) + (0,1)이 들어가게 됩니다.

        // 그런데 대각선 방향의 크기는 c = √a^2 + b^2 로 계산되기 때문에 (0.7,0.7)이 나오게 됩니다.
        // 그렇기 때문에 좌,우,위,아래 처럼 속도를 맞출 수 있도록 설정하려면 벡터의 정규화로 크기를 1로 설정시켜야 합니다.
    }
}
