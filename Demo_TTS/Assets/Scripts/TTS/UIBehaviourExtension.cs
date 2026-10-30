using UnityEngine.Events;
using UnityEngine.EventSystems;

public static class UIBehaviourExtension
{
    /// <summary>
    /// Ìí¼ÓEventTriggerÊÂ¼þ¼àÌý
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="self"></param>
    /// <param name="type"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static T OnEventTriggerEvent<T>(this T self, EventTriggerType type, UnityAction<BaseEventData> action) where T : UIBehaviour
    {
        var eventTrigger = self.GetComponent<EventTrigger>() ?? self.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = type };
        entry.callback.AddListener(action);
        eventTrigger.triggers.Add(entry);
        return self;
    }
}