namespace BridgePresenter.Model
{
    public interface IJointShows
    {
        object DataSource { get; }

        void Show();
        void CreateJointShow();
        void RemoveJointShow(string showName);
        void CopyJointShow(string showName);
    }
}
