namespace M04.LoggingProviders.Services;

public class OrderService(ILogger<OrderService> logger)
{
    public Task ProcessOrder(Guid orderId, Guid userId)
    {
        logger.LogError("Failed to process order {OrderId} for user {UserId}", orderId, userId);

        return Task.CompletedTask;
    }
}
