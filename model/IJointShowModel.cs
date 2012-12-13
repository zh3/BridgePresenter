namespace BridgePresenter.Model
{
    public interface IJointShowModel
    {
        object DataSource { get; }

        void Show();
        void CreateJointShow();
        void RemoveJointShow(string showName);
        void EditJointShow(string showName);
        void CopyJointShow(string showName);
    }
}
