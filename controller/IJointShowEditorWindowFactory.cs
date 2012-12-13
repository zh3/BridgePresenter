using System;
using BridgePresenter.Model;
using BridgePresenter.View;

namespace BridgePresenter.Controller
{
    public interface IJointShowEditorWindowFactory
    {
        Tuple<IJointShowEditorWindow, JointShowEditorController> CreateEditorWindow(IJointShowModel model);
    }
}
