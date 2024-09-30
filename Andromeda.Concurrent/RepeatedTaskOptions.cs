using System;

namespace Andromeda.Concurrent
{
    public record struct RepeatedTaskOptions(
        TimeSpan? TimeBetweenRepeats = null,
        TimeSpan? TimeBetweenRetries = null,
        uint? MaxRepeats = null,
        uint? MaxRetries = null,
        uint? MaxAttempts = null,
        bool ResetRepeatsAfterFail = false,
        bool ResetRetriesAfterSuccess = true
    );
}
