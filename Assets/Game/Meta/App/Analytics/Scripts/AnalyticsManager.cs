using Game.App.Loggers;
using UnityEngine;

namespace Game.App
{
    public class AnalyticsManager : MonoBehaviour
    {
        private static AnalyticsManager instance; // singleton

        private IAnalyticsLogger logger;
    }
}