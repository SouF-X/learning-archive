
namespace BackgroundAndHosted.PeriodicTimer.BackgroundJobs;

public class BlobStorageCleanupBackgroundService(ILogger<BlobStorageCleanupBackgroundService> logger)
: BackgroundService
{
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("CleanupService started at {time}", DateTimeOffset.UtcNow);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                logger.LogInformation("Scanning for orphaned blobs...");

                await Task.Delay(1000, stoppingToken);

                int OrphanedItemsCount = Random.Shared.Next(1, 10);

                logger.LogInformation("Deleted {OrphanedItemsCount} orphaned blobs at {time}",
                    OrphanedItemsCount, DateTimeOffset.UtcNow);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Error in FakeBlobCleanupService.");
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}