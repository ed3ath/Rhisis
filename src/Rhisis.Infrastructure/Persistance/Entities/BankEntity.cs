using System.Collections.Generic;

namespace Rhisis.Infrastructure.Persistance.Entities;

public class BankEntity
{
    public int Id { get; set; }
    
    public int PlayerId { get; set; }

    public PlayerEntity Player { get; set; }

    public byte PlayerSlot { get; set; }

    public int Gold { get; set; }

    public ICollection<BankItemEntity> Items { get; set; } = new HashSet<BankItemEntity>();
}
