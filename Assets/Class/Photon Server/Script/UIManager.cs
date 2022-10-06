using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text scoreText;
    public Text leaderBoaderText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
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
