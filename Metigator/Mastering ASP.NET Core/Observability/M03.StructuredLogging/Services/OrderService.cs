namespace M03.StructuredLogging.Services;

public class OrderService(ILogger<OrderService> logger)
{
    public Task ProcessOrder(Guid orderId, Guid userId)
    {
        logger.LogError($"Failed to process order {orderId} for user {userId}"); // Unstructured

        logger.LogError("Failed to process order {OrderId} for user {UserId}", orderId, userId); // Structured

        return Task.CompletedTask;
    }
}
