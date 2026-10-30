using SK.Framework.UI;
using SK.Framework;
using UnityEngine;

public class UseUI : MonoBehaviour
{
    void Start()
    {
        SKFramework.Module<UI>().LoadView<ExampleView>("PanelTop");

        SKFramework.Module<UI>().OpenView<ExampleView>();

        SKFramework.Module<UI>().CloseView<ExampleView>();

        SKFramework.Module<UI>().UnloadView<ExampleView>();
    }
}
