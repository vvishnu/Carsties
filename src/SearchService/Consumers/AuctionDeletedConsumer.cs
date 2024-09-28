﻿using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("--> COnsuming Auction Deleted " + context.Message.Id);

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if (result.IsAcknowledged)
                throw new MessageException(typeof(AuctionDeleted), "Problem while deleting auction");
        }

    }
}
