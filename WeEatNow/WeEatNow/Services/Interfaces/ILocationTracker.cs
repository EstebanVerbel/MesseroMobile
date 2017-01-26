using System;
using WeEatNow.Models.DataObjects;

namespace WeEatNow.Services.Interfaces
{
    public interface ILocationTracker
    {
        event EventHandler<GeographicLocation> LocationChanged;

        void StartTracking();

        void PauseTracking();
    }
}
