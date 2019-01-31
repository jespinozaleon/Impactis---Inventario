using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Business.Services
{
    public class XmlResponse
    {

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
        public partial class Envelope
        {

            private EnvelopeHeader headerField;

            private EnvelopeBody bodyField;

            /// <remarks/>
            public EnvelopeHeader Header
            {
                get
                {
                    return this.headerField;
                }
                set
                {
                    this.headerField = value;
                }
            }

            /// <remarks/>
            public EnvelopeBody Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public partial class EnvelopeHeader
        {

            private ServiceRequestHeader serviceRequestHeaderField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types")]
            public ServiceRequestHeader ServiceRequestHeader
            {
                get
                {
                    return this.serviceRequestHeaderField;
                }
                set
                {
                    this.serviceRequestHeaderField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types", IsNullable = false)]
        public partial class ServiceRequestHeader
        {

            private ApplicationCredential applicationCredentialField;

            private byte clientTransactionIDField;

            private string iSOLanguageCodeField;

            private byte purposeCodeField;

            private byte targetSystemField;

            private byte transactionIDField;

            private TransactionModel transactionModelField;

            private UserCredential userCredentialField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public ApplicationCredential ApplicationCredential
            {
                get
                {
                    return this.applicationCredentialField;
                }
                set
                {
                    this.applicationCredentialField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public byte ClientTransactionID
            {
                get
                {
                    return this.clientTransactionIDField;
                }
                set
                {
                    this.clientTransactionIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public string ISOLanguageCode
            {
                get
                {
                    return this.iSOLanguageCodeField;
                }
                set
                {
                    this.iSOLanguageCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public byte PurposeCode
            {
                get
                {
                    return this.purposeCodeField;
                }
                set
                {
                    this.purposeCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public byte TargetSystem
            {
                get
                {
                    return this.targetSystemField;
                }
                set
                {
                    this.targetSystemField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public byte TransactionID
            {
                get
                {
                    return this.transactionIDField;
                }
                set
                {
                    this.transactionIDField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public TransactionModel TransactionModel
            {
                get
                {
                    return this.transactionModelField;
                }
                set
                {
                    this.transactionModelField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public UserCredential UserCredential
            {
                get
                {
                    return this.userCredentialField;
                }
                set
                {
                    this.userCredentialField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class ApplicationCredential
        {

            private string idField;

            private string credentialField;

            /// <remarks/>
            public string ID
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
            public string Credential
            {
                get
                {
                    return this.credentialField;
                }
                set
                {
                    this.credentialField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class TransactionModel
        {

            private bool synchronousRequestField;

            private AsynchronousRequest asynchronousRequestField;

            /// <remarks/>
            public bool SynchronousRequest
            {
                get
                {
                    return this.synchronousRequestField;
                }
                set
                {
                    this.synchronousRequestField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types")]
            public AsynchronousRequest AsynchronousRequest
            {
                get
                {
                    return this.asynchronousRequestField;
                }
                set
                {
                    this.asynchronousRequestField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types", IsNullable = false)]
        public partial class AsynchronousRequest
        {

            private object callbackServiceBindingField;

            private bool fireAndForgetField;

            private bool topicSubscriptionField;

            private string messageTTLMinutesField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public object CallbackServiceBinding
            {
                get
                {
                    return this.callbackServiceBindingField;
                }
                set
                {
                    this.callbackServiceBindingField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public bool FireAndForget
            {
                get
                {
                    return this.fireAndForgetField;
                }
                set
                {
                    this.fireAndForgetField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public bool TopicSubscription
            {
                get
                {
                    return this.topicSubscriptionField;
                }
                set
                {
                    this.topicSubscriptionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public string MessageTTLMinutes
            {
                get
                {
                    return this.messageTTLMinutesField;
                }
                set
                {
                    this.messageTTLMinutesField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class UserCredential
        {

            private string idField;

            private string credentialField;

            /// <remarks/>
            public string ID
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
            public string Credential
            {
                get
                {
                    return this.credentialField;
                }
                set
                {
                    this.credentialField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public partial class EnvelopeBody
        {

            private ServiceRequest serviceRequestField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types")]
            public ServiceRequest ServiceRequest
            {
                get
                {
                    return this.serviceRequestField;
                }
                set
                {
                    this.serviceRequestField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types", IsNullable = false)]
        public partial class ServiceRequest
        {

            private RequestPreamble requestPreambleField;

            private PriceAndAvailabilityRequest priceAndAvailabilityRequestField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public RequestPreamble RequestPreamble
            {
                get
                {
                    return this.requestPreambleField;
                }
                set
                {
                    this.requestPreambleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public PriceAndAvailabilityRequest PriceAndAvailabilityRequest
            {
                get
                {
                    return this.priceAndAvailabilityRequestField;
                }
                set
                {
                    this.priceAndAvailabilityRequestField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class RequestPreamble
        {

            private uint customerNumberField;

            private object vendorNumberField;

            private object associateIDField;

            private object companyCodeField;

            private ushort salesOrganizationField;

            private object purchasingOrganizationField;

            /// <remarks/>
            public uint CustomerNumber
            {
                get
                {
                    return this.customerNumberField;
                }
                set
                {
                    this.customerNumberField = value;
                }
            }

            /// <remarks/>
            public object VendorNumber
            {
                get
                {
                    return this.vendorNumberField;
                }
                set
                {
                    this.vendorNumberField = value;
                }
            }

            /// <remarks/>
            public object AssociateID
            {
                get
                {
                    return this.associateIDField;
                }
                set
                {
                    this.associateIDField = value;
                }
            }

            /// <remarks/>
            public object CompanyCode
            {
                get
                {
                    return this.companyCodeField;
                }
                set
                {
                    this.companyCodeField = value;
                }
            }

            /// <remarks/>
            public ushort SalesOrganization
            {
                get
                {
                    return this.salesOrganizationField;
                }
                set
                {
                    this.salesOrganizationField = value;
                }
            }

            /// <remarks/>
            public object PurchasingOrganization
            {
                get
                {
                    return this.purchasingOrganizationField;
                }
                set
                {
                    this.purchasingOrganizationField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class PriceAndAvailabilityRequest
        {

            private byte distributionChannelField;

            private byte divisionField;

            private string customerPOTypeField;

            private bool isPricingRequiredField;

            private bool isAvailabilityRequiredField;

            private string currencyCodeField;

            private uint shipToCustomerNumberField;

            private object shipToRegionCodeField;

            private object sourceModeField;

            private PriceAndAvailabilityRequestItem itemField;

            private PriceAndAvailabilityRequestPlantForAvailability plantForAvailabilityField;

            /// <remarks/>
            public byte DistributionChannel
            {
                get
                {
                    return this.distributionChannelField;
                }
                set
                {
                    this.distributionChannelField = value;
                }
            }

            /// <remarks/>
            public byte Division
            {
                get
                {
                    return this.divisionField;
                }
                set
                {
                    this.divisionField = value;
                }
            }

            /// <remarks/>
            public string CustomerPOType
            {
                get
                {
                    return this.customerPOTypeField;
                }
                set
                {
                    this.customerPOTypeField = value;
                }
            }

            /// <remarks/>
            public bool IsPricingRequired
            {
                get
                {
                    return this.isPricingRequiredField;
                }
                set
                {
                    this.isPricingRequiredField = value;
                }
            }

            /// <remarks/>
            public bool IsAvailabilityRequired
            {
                get
                {
                    return this.isAvailabilityRequiredField;
                }
                set
                {
                    this.isAvailabilityRequiredField = value;
                }
            }

            /// <remarks/>
            public string CurrencyCode
            {
                get
                {
                    return this.currencyCodeField;
                }
                set
                {
                    this.currencyCodeField = value;
                }
            }

            /// <remarks/>
            public uint ShipToCustomerNumber
            {
                get
                {
                    return this.shipToCustomerNumberField;
                }
                set
                {
                    this.shipToCustomerNumberField = value;
                }
            }

            /// <remarks/>
            public object ShipToRegionCode
            {
                get
                {
                    return this.shipToRegionCodeField;
                }
                set
                {
                    this.shipToRegionCodeField = value;
                }
            }

            /// <remarks/>
            public object SourceMode
            {
                get
                {
                    return this.sourceModeField;
                }
                set
                {
                    this.sourceModeField = value;
                }
            }

            /// <remarks/>
            public PriceAndAvailabilityRequestItem Item
            {
                get
                {
                    return this.itemField;
                }
                set
                {
                    this.itemField = value;
                }
            }

            /// <remarks/>
            public PriceAndAvailabilityRequestPlantForAvailability PlantForAvailability
            {
                get
                {
                    return this.plantForAvailabilityField;
                }
                set
                {
                    this.plantForAvailabilityField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PriceAndAvailabilityRequestItem
        {

            private byte itemNumberField;

            private uint ingramPartNumberField;

            private object eANUPCCodeField;

            private byte requestedQuantityField;

            private object unitOfMeasureField;

            private object bidNumberField;

            private object endUserNumberField;

            private object shipToCustomerNumberField;

            private object shipToRegionCodeField;

            private object plantForPricingField;

            private object storageLocationForPricingField;

            private bool isReserveInventoryRequiredField;

            private object variantKeyField;

            private PriceAndAvailabilityRequestItemVariantCondition variantConditionField;

            /// <remarks/>
            public byte ItemNumber
            {
                get
                {
                    return this.itemNumberField;
                }
                set
                {
                    this.itemNumberField = value;
                }
            }

            /// <remarks/>
            public uint IngramPartNumber
            {
                get
                {
                    return this.ingramPartNumberField;
                }
                set
                {
                    this.ingramPartNumberField = value;
                }
            }

            /// <remarks/>
            public object EANUPCCode
            {
                get
                {
                    return this.eANUPCCodeField;
                }
                set
                {
                    this.eANUPCCodeField = value;
                }
            }

            /// <remarks/>
            public byte RequestedQuantity
            {
                get
                {
                    return this.requestedQuantityField;
                }
                set
                {
                    this.requestedQuantityField = value;
                }
            }

            /// <remarks/>
            public object UnitOfMeasure
            {
                get
                {
                    return this.unitOfMeasureField;
                }
                set
                {
                    this.unitOfMeasureField = value;
                }
            }

            /// <remarks/>
            public object BidNumber
            {
                get
                {
                    return this.bidNumberField;
                }
                set
                {
                    this.bidNumberField = value;
                }
            }

            /// <remarks/>
            public object EndUserNumber
            {
                get
                {
                    return this.endUserNumberField;
                }
                set
                {
                    this.endUserNumberField = value;
                }
            }

            /// <remarks/>
            public object ShipToCustomerNumber
            {
                get
                {
                    return this.shipToCustomerNumberField;
                }
                set
                {
                    this.shipToCustomerNumberField = value;
                }
            }

            /// <remarks/>
            public object ShipToRegionCode
            {
                get
                {
                    return this.shipToRegionCodeField;
                }
                set
                {
                    this.shipToRegionCodeField = value;
                }
            }

            /// <remarks/>
            public object PlantForPricing
            {
                get
                {
                    return this.plantForPricingField;
                }
                set
                {
                    this.plantForPricingField = value;
                }
            }

            /// <remarks/>
            public object StorageLocationForPricing
            {
                get
                {
                    return this.storageLocationForPricingField;
                }
                set
                {
                    this.storageLocationForPricingField = value;
                }
            }

            /// <remarks/>
            public bool IsReserveInventoryRequired
            {
                get
                {
                    return this.isReserveInventoryRequiredField;
                }
                set
                {
                    this.isReserveInventoryRequiredField = value;
                }
            }

            /// <remarks/>
            public object VariantKey
            {
                get
                {
                    return this.variantKeyField;
                }
                set
                {
                    this.variantKeyField = value;
                }
            }

            /// <remarks/>
            public PriceAndAvailabilityRequestItemVariantCondition VariantCondition
            {
                get
                {
                    return this.variantConditionField;
                }
                set
                {
                    this.variantConditionField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PriceAndAvailabilityRequestItemVariantCondition
        {

            private object keyField;

            private object factorField;

            /// <remarks/>
            public object Key
            {
                get
                {
                    return this.keyField;
                }
                set
                {
                    this.keyField = value;
                }
            }

            /// <remarks/>
            public object Factor
            {
                get
                {
                    return this.factorField;
                }
                set
                {
                    this.factorField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PriceAndAvailabilityRequestPlantForAvailability
        {

            private object plantField;

            private bool includeAvailabilityForAllStorageLocationsField;

            private ushort storageLocationField;

            /// <remarks/>
            public object Plant
            {
                get
                {
                    return this.plantField;
                }
                set
                {
                    this.plantField = value;
                }
            }

            /// <remarks/>
            public bool IncludeAvailabilityForAllStorageLocations
            {
                get
                {
                    return this.includeAvailabilityForAllStorageLocationsField;
                }
                set
                {
                    this.includeAvailabilityForAllStorageLocationsField = value;
                }
            }

            /// <remarks/>
            public ushort StorageLocation
            {
                get
                {
                    return this.storageLocationField;
                }
                set
                {
                    this.storageLocationField = value;
                }
            }
        }


    }
}
