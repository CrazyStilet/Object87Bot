///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
//public partial class Missions
//{
//    private MissionsLocation[] locationField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlElementAttribute("Location")]
//    public MissionsLocation[] Location
//    {
//        get
//        {
//            return this.locationField;
//        }
//        set
//        {
//            this.locationField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocation
//{

//    private MissionsLocationPosition[] positionField;

//    private byte idField;

//    private string descriptionField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlElementAttribute("Position")]
//    public MissionsLocationPosition[] Position
//    {
//        get
//        {
//            return this.positionField;
//        }
//        set
//        {
//            this.positionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public byte id
//    {
//        get
//        {
//            return this.idField;
//        }
//        set
//        {
//            this.idField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPosition
//{

//    private object[] itemsField;

//    private byte idField;

//    private string descriptionField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlElementAttribute("BlueKey", typeof(MissionsLocationPositionBlueKey))]
//    [System.Xml.Serialization.XmlElementAttribute("Door", typeof(MissionsLocationPositionDoor))]
//    [System.Xml.Serialization.XmlElementAttribute("East", typeof(MissionsLocationPositionEast))]
//    [System.Xml.Serialization.XmlElementAttribute("North", typeof(MissionsLocationPositionNorth))]
//    [System.Xml.Serialization.XmlElementAttribute("South", typeof(MissionsLocationPositionSouth))]
//    [System.Xml.Serialization.XmlElementAttribute("West", typeof(MissionsLocationPositionWest))]
//    public object[] Items
//    {
//        get
//        {
//            return this.itemsField;
//        }
//        set
//        {
//            this.itemsField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public byte id
//    {
//        get
//        {
//            return this.idField;
//        }
//        set
//        {
//            this.idField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPositionBlueKey
//{

//    private string descriptionField;

//    private bool takeField;

//    private string valueField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public bool take
//    {
//        get
//        {
//            return this.takeField;
//        }
//        set
//        {
//            this.takeField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTextAttribute()]
//    public string Value
//    {
//        get
//        {
//            return this.valueField;
//        }
//        set
//        {
//            this.valueField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPositionDoor
//{

//    private string descriptionField;

//    private string needField;

//    private bool closeField;

//    private string valueField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string need
//    {
//        get
//        {
//            return this.needField;
//        }
//        set
//        {
//            this.needField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public bool close
//    {
//        get
//        {
//            return this.closeField;
//        }
//        set
//        {
//            this.closeField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTextAttribute()]
//    public string Value
//    {
//        get
//        {
//            return this.valueField;
//        }
//        set
//        {
//            this.valueField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPositionEast
//{

//    private string descriptionField;

//    private byte valueField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTextAttribute()]
//    public byte Value
//    {
//        get
//        {
//            return this.valueField;
//        }
//        set
//        {
//            this.valueField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPositionNorth
//{

//    private string descriptionField;

//    private byte valueField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTextAttribute()]
//    public byte Value
//    {
//        get
//        {
//            return this.valueField;
//        }
//        set
//        {
//            this.valueField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPositionSouth
//{

//    private string descriptionField;

//    private byte valueField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTextAttribute()]
//    public byte Value
//    {
//        get
//        {
//            return this.valueField;
//        }
//        set
//        {
//            this.valueField = value;
//        }
//    }
//}

///// <remarks/>
//[System.SerializableAttribute()]
//[System.ComponentModel.DesignerCategoryAttribute("code")]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//public partial class MissionsLocationPositionWest
//{

//    private string descriptionField;

//    private byte valueField;

//    /// <remarks/>
//    [System.Xml.Serialization.XmlAttributeAttribute()]
//    public string description
//    {
//        get
//        {
//            return this.descriptionField;
//        }
//        set
//        {
//            this.descriptionField = value;
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTextAttribute()]
//    public byte Value
//    {
//        get
//        {
//            return this.valueField;
//        }
//        set
//        {
//            this.valueField = value;
//        }
//    }
//}

