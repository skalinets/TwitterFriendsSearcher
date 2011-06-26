namespace TwitterFriendsSearcher.UI
{
    public interface ITwitterFriendsSearcherView
    {
        string Keywords { get; }
        void ClearResultsArea();
        void AddUserToResultsArea(int userId);
        void RemoveFromResultsArea(int userId);
    }
}