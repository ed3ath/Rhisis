using Rhisis.Game.Common;

namespace Rhisis.Infrastructure.Persistance.Entities;

public class BankItemEntity
{
    public int BankId { get; set; }
    public BankEntity Bank { get; set; }

    public int ItemId { get; set; }

    public ItemEntity Item { get; set; }

    public byte Slot { get; set; }

    public int Quantity { get; set; }

}
