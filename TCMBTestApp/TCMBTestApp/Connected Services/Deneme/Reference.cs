﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deneme
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", ConfigurationName="Deneme.bankaSubeOku")]
    public interface bankaSubeOku
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://bs.tcmb.gov.tr/services/bankaSubeOku", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<Deneme.bankaSubeOkuCikti> bankaSubeOkuAsync(Deneme.bankaSubeOkuGirdi request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class BLSCvp
    {
        
        private Banka[] bankaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("banka", Order=0)]
        public Banka[] banka
        {
            get
            {
                return this.bankaField;
            }
            set
            {
                this.bankaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class Banka
    {
        
        private string bKdField;
        
        private string bAdField;
        
        private string bIlAdField;
        
        private string adrField;
        
        private string sonIslemTuruField;
        
        private string sonIslemZamaniField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string bKd
        {
            get
            {
                return this.bKdField;
            }
            set
            {
                this.bKdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string bAd
        {
            get
            {
                return this.bAdField;
            }
            set
            {
                this.bAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string bIlAd
        {
            get
            {
                return this.bIlAdField;
            }
            set
            {
                this.bIlAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string adr
        {
            get
            {
                return this.adrField;
            }
            set
            {
                this.adrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sonIslemTuru
        {
            get
            {
                return this.sonIslemTuruField;
            }
            set
            {
                this.sonIslemTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sonIslemZamani
        {
            get
            {
                return this.sonIslemZamaniField;
            }
            set
            {
                this.sonIslemZamaniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class HataSonuc
    {
        
        private string sonucKoduField;
        
        private string aciklamaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string sonucKodu
        {
            get
            {
                return this.sonucKoduField;
            }
            set
            {
                this.sonucKoduField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string aciklama
        {
            get
            {
                return this.aciklamaField;
            }
            set
            {
                this.aciklamaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class SGSCvp
    {
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SGSYok", typeof(object), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("sube", typeof(Sube), Order=0)]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class Sube
    {
        
        private string bKdField;
        
        private string sKdField;
        
        private string sAdField;
        
        private string sIlKdField;
        
        private string sIlAdField;
        
        private string sIlcKdField;
        
        private string sIlcAdField;
        
        private string adrField;
        
        private string tlfField;
        
        private string fksField;
        
        private string epstField;
        
        private string sonIslemTuruField;
        
        private string sonIslemZamaniField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string bKd
        {
            get
            {
                return this.bKdField;
            }
            set
            {
                this.bKdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string sKd
        {
            get
            {
                return this.sKdField;
            }
            set
            {
                this.sKdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string sAd
        {
            get
            {
                return this.sAdField;
            }
            set
            {
                this.sAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string sIlKd
        {
            get
            {
                return this.sIlKdField;
            }
            set
            {
                this.sIlKdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string sIlAd
        {
            get
            {
                return this.sIlAdField;
            }
            set
            {
                this.sIlAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string sIlcKd
        {
            get
            {
                return this.sIlcKdField;
            }
            set
            {
                this.sIlcKdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string sIlcAd
        {
            get
            {
                return this.sIlcAdField;
            }
            set
            {
                this.sIlcAdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string adr
        {
            get
            {
                return this.adrField;
            }
            set
            {
                this.adrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string tlf
        {
            get
            {
                return this.tlfField;
            }
            set
            {
                this.tlfField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string fks
        {
            get
            {
                return this.fksField;
            }
            set
            {
                this.fksField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string epst
        {
            get
            {
                return this.epstField;
            }
            set
            {
                this.epstField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sonIslemTuru
        {
            get
            {
                return this.sonIslemTuruField;
            }
            set
            {
                this.sonIslemTuruField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sonIslemZamani
        {
            get
            {
                return this.sonIslemZamaniField;
            }
            set
            {
                this.sonIslemZamaniField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class SGBCvp
    {
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SGBYok", typeof(object), Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("banka", typeof(Banka), Order=0)]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class TUMCvp
    {
        
        private BankaSubeleri[] bankaSubeleriField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("bankaSubeleri", Order=0)]
        public BankaSubeleri[] bankaSubeleri
        {
            get
            {
                return this.bankaSubeleriField;
            }
            set
            {
                this.bankaSubeleriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class BankaSubeleri
    {
        
        private Banka bankaField;
        
        private Sube[] subeField;
        
        private string bKdField;
        
        private string sAdtField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Banka banka
        {
            get
            {
                return this.bankaField;
            }
            set
            {
                this.bankaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sube", Order=1)]
        public Sube[] sube
        {
            get
            {
                return this.subeField;
            }
            set
            {
                this.subeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string bKd
        {
            get
            {
                return this.bKdField;
            }
            set
            {
                this.bKdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="nonNegativeInteger")]
        public string sAdt
        {
            get
            {
                return this.sAdtField;
            }
            set
            {
                this.sAdtField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class BSBCvp
    {
        
        private Sube[] subeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("sube", Order=0)]
        public Sube[] sube
        {
            get
            {
                return this.subeField;
            }
            set
            {
                this.subeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class SUBCvp
    {
        
        private Sube subeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Sube sube
        {
            get
            {
                return this.subeField;
            }
            set
            {
                this.subeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/")]
    public partial class BNKCvp
    {
        
        private Banka bankaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public Banka banka
        {
            get
            {
                return this.bankaField;
            }
            set
            {
                this.bankaField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="bankaSubeOkuIstem", WrapperNamespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", IsWrapped=true)]
    public partial class bankaSubeOkuGirdi
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", Order=0)]
        public string blgTur;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", Order=1)]
        public string bKd;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", Order=2)]
        public string sKd;
        
        public bankaSubeOkuGirdi()
        {
        }
        
        public bankaSubeOkuGirdi(string blgTur, string bKd, string sKd)
        {
            this.blgTur = blgTur;
            this.bKd = bKd;
            this.sKd = sKd;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="bankaSubeOkuCevap", WrapperNamespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", IsWrapped=true)]
    public partial class bankaSubeOkuCikti
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://bs.tcmb.gov.tr/services/bankaSubeOku/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("blsCvp", typeof(BLSCvp))]
        [System.Xml.Serialization.XmlElementAttribute("bnkCvp", typeof(BNKCvp))]
        [System.Xml.Serialization.XmlElementAttribute("bsbCvp", typeof(BSBCvp))]
        [System.Xml.Serialization.XmlElementAttribute("hata", typeof(HataSonuc))]
        [System.Xml.Serialization.XmlElementAttribute("sgbCvp", typeof(SGBCvp))]
        [System.Xml.Serialization.XmlElementAttribute("sgsCvp", typeof(SGSCvp))]
        [System.Xml.Serialization.XmlElementAttribute("subCvp", typeof(SUBCvp))]
        [System.Xml.Serialization.XmlElementAttribute("tumCvp", typeof(TUMCvp))]
        public object Item;
        
        public bankaSubeOkuCikti()
        {
        }
        
        public bankaSubeOkuCikti(object Item)
        {
            this.Item = Item;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface bankaSubeOkuChannel : Deneme.bankaSubeOku, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class bankaSubeOkuClient : System.ServiceModel.ClientBase<Deneme.bankaSubeOku>, Deneme.bankaSubeOku
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public bankaSubeOkuClient() : 
                base(bankaSubeOkuClient.GetDefaultBinding(), bankaSubeOkuClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.bankaSubeOku.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public bankaSubeOkuClient(EndpointConfiguration endpointConfiguration) : 
                base(bankaSubeOkuClient.GetBindingForEndpoint(endpointConfiguration), bankaSubeOkuClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public bankaSubeOkuClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(bankaSubeOkuClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public bankaSubeOkuClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(bankaSubeOkuClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public bankaSubeOkuClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Deneme.bankaSubeOkuCikti> Deneme.bankaSubeOku.bankaSubeOkuAsync(Deneme.bankaSubeOkuGirdi request)
        {
            return base.Channel.bankaSubeOkuAsync(request);
        }
        
        public System.Threading.Tasks.Task<Deneme.bankaSubeOkuCikti> bankaSubeOkuAsync(string blgTur, string bKd, string sKd)
        {
            Deneme.bankaSubeOkuGirdi inValue = new Deneme.bankaSubeOkuGirdi();
            inValue.blgTur = blgTur;
            inValue.bKd = bKd;
            inValue.sKd = sKd;
            return ((Deneme.bankaSubeOku)(this)).bankaSubeOkuAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.bankaSubeOku))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.bankaSubeOku))
            {
                return new System.ServiceModel.EndpointAddress("https://appg.tcmb.gov.tr/mbnbasuse/services/bankaSubeOku");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return bankaSubeOkuClient.GetBindingForEndpoint(EndpointConfiguration.bankaSubeOku);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return bankaSubeOkuClient.GetEndpointAddress(EndpointConfiguration.bankaSubeOku);
        }
        
        public enum EndpointConfiguration
        {
            
            bankaSubeOku,
        }
    }
}