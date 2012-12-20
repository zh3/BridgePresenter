namespace BridgePresenter.Model
{
    public interface IJointShows
    {
        object DataSource { get; }

        void Show();
        IJointShow CreateJointShow();
        void RemoveJointShow(string showName);
        void CopyJointShow(string showName);
    }
}
