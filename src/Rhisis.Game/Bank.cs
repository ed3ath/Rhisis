using Rhisis.Game.Common;
using Rhisis.Game.Entities;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots;
using Rhisis.Game.Protocol.Packets.World.Server.Snapshots.Bank;
using Rhisis.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhisis.Game;

/// <summary>
/// Provides a mechanism to manage a player's bank.
/// </summary>
public sealed class Bank : ItemContainer
{
    public static readonly int BankSize = 42;
    public static readonly int SlotSize = 3;

    private readonly Player _owner;
    private bool BankInitialized { get; set; } = false;

    public byte Slot { get; set; }


    /// <summary>
    /// Creates a new <see cref="Bank"/> instance.
    /// </summary>
    /// <param name="owner">Player owner.</param>
    public Bank(Player owner) : base(BankSize)
    {
        _owner = owner;
        Slot = (byte)owner.Slot;
    }

    /// <summary>
    /// Add the given item into the bank.
    /// </summary>
    /// <param name="item">Item to create.</param>
    /// <param name="quantity">Quantity.</param>
    public void PutItem(Item item, int quantity)
    {
        item.Quantity = quantity;
        IEnumerable<ItemCreationResult> creationResult = CreateItem(item);
        if (creationResult.Any())
        {
            using var snapshot = new FFSnapshot();

            foreach (ItemCreationResult itemResult in creationResult)
            {
                Item resultItem = itemResult.Item;
                if (itemResult.ActionType == ItemCreationActionType.Add)
                {
                    snapshot.Merge(new PutBankItemSnapshot(_owner, Slot, resultItem));
                }
                else if (itemResult.ActionType == ItemCreationActionType.Update)
                {
                    resultItem.Quantity = quantity;
                    snapshot.Merge(new PutBankItemSnapshot(_owner, Slot, resultItem));
                }
            }
            _owner.Send(snapshot);
        }
        else
        {
            _owner.SendDefinedText(DefineText.TID_GAME_LACKSPACE);
        }
    }

    // <summary>
    // Deletes an given quantity from an item container slot.
    // </summary>
    // <param name="itemSlot">Item slot.</param>
    // <param name="quantity">Quantity to delete.</param>
    // <param name="updateType">Item update type.</param>
    // <param name="sendToPlayer">Boolean value that indicates if the player should be notified.</param>
    // <returns>Deleted item quantity.</returns>
    public void GetItem(ItemContainerSlot itemSlot, int quantity, byte itemIndex)
    {

        if (quantity > itemSlot.Item.Quantity)
            quantity = itemSlot.Item.Quantity;
        if (quantity < 1)
            quantity = 1;

        using var snapshot = new FFSnapshot();
        Item item = itemSlot.Item;
        item.Quantity = quantity;
        snapshot.Merge(new GetBankItemSnapshot(_owner, Slot, item));
        //snapshot.Merge(new UpdateBankItemSnapshot(_owner, Slot, itemIndex, UpdateItemType.UI_NUM, (short)(itemSlot.Item.Quantity-quantity)));

        _owner.Send(snapshot);

        if (itemSlot.Item.Quantity <= 0)
        {
            Remove(itemSlot);
        }
    }

    public void SendBank()
    {

        if (!BankInitialized)
        {
            for (int i = 0; i < MaxCapacity; i++)
            {
                ItemContainerSlot itemSlot = GetAtSlot(i);

                if (itemSlot.HasItem)
                {
                    Console.WriteLine($"Sending snapshot {_owner.Name} {itemSlot.Index} {itemSlot.Item.Id}");
                    _owner.Send(new PutBankItemSnapshot(_owner, Slot, itemSlot.Item));
                    BankInitialized = true;
                }
            }
        }
    }

    public void UpdateBank(){

    }
}
