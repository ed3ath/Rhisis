using Rhisis.Game.Common;
using Rhisis.Game.Entities;
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
    private bool BankInitialized { get; set; }

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
    public void PutItem(ItemContainerSlot itemSlot, int quantity)
    {
        Item item = itemSlot.Item.Clone();
        Console.WriteLine($"Inventory Item QTY Before: {item.Quantity}");
        quantity = _owner.Inventory.DeleteItem(itemSlot, quantity);
        Console.WriteLine($"Inventory Item QTY After: {item.Quantity - quantity}");
        item.Quantity = quantity;
        IEnumerable<ItemCreationResult> creationResult = InsertItem(item);
        if (creationResult.Any())
        {
            using var snapshot = new FFSnapshot();
            snapshot.Merge(new PutBankItemSnapshot(_owner, Slot, item));
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
        // TODO - check if inventory is full, check if user has common bank for different bank slot
        quantity = Math.Max(1, Math.Min(quantity, itemSlot.Item.Quantity));
        Item item = itemSlot.Item.Clone();
        Console.WriteLine($"Bank Item QTY Before: {itemSlot.Item.Quantity}");
        int currentQuantity = RemoveItem(itemSlot, quantity);
        Console.WriteLine($"Bank Item QTY After: {currentQuantity}");
        using var snapshot = new FFSnapshot();
        item.Quantity = quantity;
        snapshot.Merge(new GetBankItemSnapshot(_owner, item));
        snapshot.Merge(new UpdateBankItemSnapshot(_owner, Slot, itemIndex, currentQuantity));
        _owner.Send(snapshot);
        _owner.Inventory.CreateItem(item);
    }

    /// <summary>
    /// Deletes an given quantity from an item container slot.
    /// </summary>
    /// <param name="itemSlot">Item slot.</param>
    /// <param name="quantity">Quantity to delete.</param>
    /// <param name="updateType">Item update type.</param>
    /// <param name="sendToPlayer">Boolean value that indicates if the player should be notified.</param>
    /// <returns>Deleted item quantity.</returns>
    public int DeleteItem(ItemContainerSlot itemSlot, int quantity)
    {
        itemSlot.Item.Quantity -= quantity;

        if (itemSlot.Item.Quantity <= 0)
        {
            Remove(itemSlot);
        }

        return itemSlot.HasItem ? itemSlot.Item.Quantity : 0;
    }

    public void SendBank()
    {

        if (!BankInitialized)
        {
            BankInitialized = true;
            for (int i = 0; i < MaxCapacity; i++)
            {
                ItemContainerSlot itemSlot = GetAtSlot(i);

                if (itemSlot.HasItem)
                {
                    Console.WriteLine($"Sending snapshot {_owner.Name} {itemSlot.Index} {itemSlot.Item.Id}");
                    _owner.Send(new PutBankItemSnapshot(_owner, Slot, itemSlot.Item));
                }
            }
        }
    }
}
