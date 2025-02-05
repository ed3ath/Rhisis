﻿using Rhisis.Core.Extensions;
using Rhisis.Game.Common;
using Rhisis.Game.Resources.Properties;
using Rhisis.Protocol;
using System;
using System.Diagnostics;

namespace Rhisis.Game;

[DebuggerDisplay("{Properties.IdentifierName} +{Refine} ({Element}+{ElementRefine}) x{Quantity}")]
public class Item : IEquatable<Item>
{
    public class ItemConstants
    {
        public static readonly int WeaponArmorRefineMax = 10;
        public static readonly int JewelryRefineMax = 20;
        public static readonly int ElementRefineMax = 10;
    }

    private int _quantity;

    /// <summary>
    /// Gets or sets the item serial number.
    /// </summary>
    public int? SerialNumber { get; set; }

    /// <summary>
    /// Gets the item id.
    /// </summary>
    public int Id => Properties.Id;

    /// <summary>
    /// Gets the item name.
    /// </summary>
    public string Name => Properties.IdentifierName;

    /// <summary>
    /// Gets the item data.
    /// </summary>
    public ItemProperties Properties { get; }

    /// <summary>
    /// Gets the item creator id.
    /// </summary>
    public int? CreatorId { get; init; }

    /// <summary>
    /// Gets or sets the item quantity.
    /// </summary>
    public int Quantity
    {
        get => _quantity;
        set => _quantity = Math.Clamp(value, 0, Properties.PackMax);
    }

    /// <summary>
    /// Gets or sets the item refine.
    /// </summary>
    public byte Refine { get; set; }

    /// <summary>
    /// Gets or sets the item element type.
    /// </summary>
    public ElementType Element { get; set; }

    /// <summary>
    /// Gets or sets the item element refine.
    /// </summary>
    public byte ElementRefine { get; set; }

    /// <summary>
    /// Gets the item refines.
    /// </summary>
    public int Refines => Refine & (byte)Element & ElementRefine;

    public Item(ItemProperties itemProperties)
    {
        Properties = itemProperties ?? throw new ArgumentNullException(nameof(itemProperties), "Cannot create an item with no properties.");
    }

    /// <summary>
    /// Serialize the current item with a custom storage index.
    /// </summary>
    /// <param name="packet">Current packet stream.</param>
    public void Serialize(FFPacket packet)
    {
        packet.WriteInt32(Id);
        packet.WriteInt32(SerialNumber.GetValueOrDefault(0));
        packet.WriteString(Name.TakeCharacters(31));
        packet.WriteInt16((short)Quantity);
        packet.WriteByte(0); // Repair number
        packet.WriteInt32(0); // Hp
        packet.WriteInt32(0); // Repair
        packet.WriteByte(0); // flag ?
        packet.WriteInt32(Refine);
        packet.WriteInt32(0); // guild id (cloaks?)
        packet.WriteByte((byte)Element);
        packet.WriteInt32(ElementRefine);
        packet.WriteInt32(0); // m_nResistSMItemId
        packet.WriteInt32(0); // Piercing size
        packet.WriteInt32(0); // Ultimate piercing size
        packet.WriteInt32(0); // Pet vis
        packet.WriteInt32(0); // charged
        packet.WriteInt64(0); // m_iRandomOptItemId
        packet.WriteInt32(0); // m_dwKeepTime
        packet.WriteByte(0); // pet
        packet.WriteInt32(0); // m_bTranformVisPet
    }

    public Item Clone()
    {
        return new Item(Properties)
        {
            Quantity = Quantity,
            Element = Element,
            ElementRefine = ElementRefine,
            Refine = Refine
        };
    }

    public bool Equals(Item other)
    {
        return Id == other.Id && 
            SerialNumber == other.SerialNumber && 
            Refine == other.Refine && 
            Element == other.Element && 
            ElementRefine == other.ElementRefine;
    }

    public override bool Equals(object obj) => Equals(obj as Item);

    public override int GetHashCode() => HashCode.Combine(Id, SerialNumber, Refine, Element, ElementRefine);
}
