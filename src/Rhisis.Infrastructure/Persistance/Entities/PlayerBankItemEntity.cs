using Rhisis.Game.Common;

namespace Rhisis.Infrastructure.Persistance.Entities;

public class PlayerBankItemEntity
{
    public int ItemId { get; set; }

    public ItemEntity Item { get; set; }

    public int PlayerId { get; set; }

    public int PlayerSlot { get; set; }

    public PlayerEntity Player { get; set; }

    public PlayerItemStorageType StorageType { get; set; }

    public byte Slot { get; set; }

    public int Quantity { get; set; }
}
