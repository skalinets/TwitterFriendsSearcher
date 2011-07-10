using System.ServiceModel;
using Test.TwitterFriendsSearcher.Shared;

namespace TwitterFriendsSearcher.Runner
{
    [ServiceContract]
    public interface ITwitterFriendsSearcherUiInfoProvider
    {

        [OperationContract]
        ControlCenter GetButtonCenterByName(string buttonName);

        [OperationContract]
        ControlCenter GetTextBoxCenterByName(string textBoxName);

        [OperationContract]
        ListBoxInfo GetListBoxInfo(string listBoxInfoName);
    }
}