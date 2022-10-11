using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    GetLeaderboardRequest request = new GetLeaderboardRequest();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GetLeaderboard()
    {
        request = new GetLeaderboardRequest 
        { 
            StartPosition = 0,
            StatisticName = "Score",
            MaxResultsCount = 10,
            ProfileConstraints = new PlayerProfileViewConstraints()
            { 
                ShowLocations = true, 
                ShowDisplayName = true
            }
        };     
    }

    public void Ranking()
    {
        GetLeaderboard();

        PlayFabClientAPI.GetLeaderboard(request, (result) =>
        {
            int i = 0;

            for (i = 0; i < result.Leaderboard.Count; i++)
            {
                var curBoard = result.Leaderboard[i];        
            }

            NotificationManager.NotificationWindow
            (
             "Leader Board",
              result.Leaderboard[i].DisplayName + " - " + result.Leaderboard[i].StatValue + "\n"
            );
        },
        (error) => 
                NotificationManager.NotificationWindow
                (
                    "Failed to load data",
                    "Failed to load leaderboard data from server. \n " +
                    "Please check your internet connection."
                ));
    }

    public void GetVirtualCurrency()
    {
        var request = new AddUserVirtualCurrencyRequest() 
        { 
            VirtualCurrency = "RP",
            Amount = 10 
        };

        PlayFabClientAPI.AddUserVirtualCurrency
        (
            request, (result) => print("돈 얻기 성공! 현재 돈 : " + result.Balance),
            (error) => print("돈 얻기 실패")
        );
    }

    public void PurchaseItem()
    {
        var request = new PurchaseItemRequest()
        {
            CatalogVersion = "Game Shop",
            ItemId = "Dragon Skin",
            VirtualCurrency = "RP",
            Price = 100
        };

        PlayFabClientAPI.PurchaseItem
        (
            request,
            (result) => print("아이템 구입 성공"),
            (error) => print("아이템 구입 실패")
        );
    }
}
