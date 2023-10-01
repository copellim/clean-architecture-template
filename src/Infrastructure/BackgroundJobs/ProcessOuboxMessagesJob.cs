using Domain.Primitives;
using Infrastructure.Persistence.Outbox;
using MediatR;
using Newtonsoft.Json;
using Quartz;

namespace Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ProcessOuboxMessagesJob : IJob
{
    //private readonly ApplicationDbContext _dbContext;
    private readonly IPublisher _publisher;


    public async Task Execute(IJobExecutionContext context)
    {
        List<OutboxMessage> messages = await _dbContext
            .Set<OutboxMessage>()
            .Where(m => m.ProcessedAtUtc == null)
            .Take(20)
            .ToListAsync(context.CancellationToken);

        foreach (OutboxMessage outboxMessage in messages)
        {
            IDomainEvent? domainEvent = JsonConvert
                .DeserializeObject<IDomainEvent>(outboxMessage.Content);

            if (domainEvent is null)
            {
                continue;
            }

            await _publisher.Publish(domainEvent, context.CancellationToken);

            outboxMessage.ProcessedAtUtc = DateTime.UtcNow;
        }

        await _dbContext.SaveChangesAsync();
    }
}
