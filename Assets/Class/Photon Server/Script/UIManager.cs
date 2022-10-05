using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;

using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPunObservable
{
    public static UIManager instance;

    public int score;
    public Text scoreText;
    public Text leaderBoaderText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 오브젝트라면 쓰기 부분이 실행됩니다.
        if (stream.IsWriting)
        {
            // 네트워크를 통해 score 값을 보냅니다.
            stream.SendNext(score);
        }
        else // 원격 오브젝트라면 읽기 부분이 실행됩니다.
        {
            // 네트워크를 통해서 score 값을 받습니다.
            score = (int)stream.ReceiveNext();
        }
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest 
        { 
            StartPosition = 0,
            StatisticName = "Score",
            MaxResultsCount = 20,
            ProfileConstraints = new PlayerProfileViewConstraints()
            { 
                ShowLocations = true, 
                ShowDisplayName = true
            }
        };
     
        PlayFabClientAPI.GetLeaderboard(request, (result) =>
        {
            for (int i = 0; i < result.Leaderboard.Count; i++)
            {
                var curBoard = result.Leaderboard[i];
                leaderBoaderText.text += curBoard.Profile.Locations[0].CountryCode.Value 
                + " / " +
                curBoard.DisplayName +
                " / " + 
                curBoard.StatValue + "\n";
            }
        },
        (error) => print("리더보드 불러오기 실패"));
    }
}
