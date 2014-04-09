﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARK.Model
{
    public partial class XMLParseHelpers
    {
        public class XMLTure
        {
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
            public partial class dataroot
            {

                private datarootTur[] turField;

                private System.DateTime generatedField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute("Tur")]
                public datarootTur[] Tur
                {
                    get
                    {
                        return this.turField;
                    }
                    set
                    {
                        this.turField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public System.DateTime generated
                {
                    get
                    {
                        return this.generatedField;
                    }
                    set
                    {
                        this.generatedField = value;
                    }
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
            public partial class datarootTur
            {

                private ushort idField;

                private byte kilometerField;

                private System.DateTime datoField;

                private byte langturField;

                private byte bådIDField;

                private ushort nr1Field;

                private ushort nr2Field;

                private bool nr2FieldSpecified;

                private ushort nr3Field;

                private bool nr3FieldSpecified;

                private ushort nr4Field;

                private bool nr4FieldSpecified;

                private ushort nr5Field;

                private bool nr5FieldSpecified;

                /// <remarks/>
                public ushort ID
                {
                    get
                    {
                        return this.idField;
                    }
                    set
                    {
                        this.idField = value;
                    }
                }

                /// <remarks/>
                public byte Kilometer
                {
                    get
                    {
                        return this.kilometerField;
                    }
                    set
                    {
                        this.kilometerField = value;
                    }
                }

                /// <remarks/>
                public System.DateTime Dato
                {
                    get
                    {
                        return this.datoField;
                    }
                    set
                    {
                        this.datoField = value;
                    }
                }

                /// <remarks/>
                public byte Langtur
                {
                    get
                    {
                        return this.langturField;
                    }
                    set
                    {
                        this.langturField = value;
                    }
                }

                /// <remarks/>
                public byte BådID
                {
                    get
                    {
                        return this.bådIDField;
                    }
                    set
                    {
                        this.bådIDField = value;
                    }
                }

                /// <remarks/>
                public ushort Nr1
                {
                    get
                    {
                        return this.nr1Field;
                    }
                    set
                    {
                        this.nr1Field = value;
                    }
                }

                /// <remarks/>
                public ushort Nr2
                {
                    get
                    {
                        return this.nr2Field;
                    }
                    set
                    {
                        this.nr2Field = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlIgnoreAttribute()]
                public bool Nr2Specified
                {
                    get
                    {
                        return this.nr2FieldSpecified;
                    }
                    set
                    {
                        this.nr2FieldSpecified = value;
                    }
                }

                /// <remarks/>
                public ushort Nr3
                {
                    get
                    {
                        return this.nr3Field;
                    }
                    set
                    {
                        this.nr3Field = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlIgnoreAttribute()]
                public bool Nr3Specified
                {
                    get
                    {
                        return this.nr3FieldSpecified;
                    }
                    set
                    {
                        this.nr3FieldSpecified = value;
                    }
                }

                /// <remarks/>
                public ushort Nr4
                {
                    get
                    {
                        return this.nr4Field;
                    }
                    set
                    {
                        this.nr4Field = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlIgnoreAttribute()]
                public bool Nr4Specified
                {
                    get
                    {
                        return this.nr4FieldSpecified;
                    }
                    set
                    {
                        this.nr4FieldSpecified = value;
                    }
                }

                /// <remarks/>
                public ushort Nr5
                {
                    get
                    {
                        return this.nr5Field;
                    }
                    set
                    {
                        this.nr5Field = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlIgnoreAttribute()]
                public bool Nr5Specified
                {
                    get
                    {
                        return this.nr5FieldSpecified;
                    }
                    set
                    {
                        this.nr5FieldSpecified = value;
                    }
                }
            }
        }
    }
}
