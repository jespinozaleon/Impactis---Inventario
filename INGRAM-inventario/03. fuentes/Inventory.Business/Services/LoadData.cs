using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Inventory.Business.Services
{
    public class LoadData
    {
        public static string CallWebService(string sku)
        {
            var _url = Utilities.Parameter.GetValue("URL");
            var _action = "/product/PriceAndAvailability";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(sku);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }

            return soapResult;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(string sku)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            //var request1 = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types\" xmlns:typ1=\"http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types\"> <soapenv:Header> <typ:ServiceRequestHeader> <!--You may enter the following 8 items in any order--> <ApplicationCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </ApplicationCredential> <!--Optional:--> <ClientTransactionID>1</ClientTransactionID> <!--Optional:--> <ISOLanguageCode>ES</ISOLanguageCode> <!--Optional:--> <PurposeCode>1</PurposeCode> <!--Optional:--> <TargetSystem>2</TargetSystem> <!--Optional:--> <TransactionID>3</TransactionID> <TransactionModel> <!--You have a CHOICE of the next 2 items at this level--> <!--Optional:--> <SynchronousRequest>true</SynchronousRequest> <typ:AsynchronousRequest> <!--You have a CHOICE of the next 3 items at this level--> <CallbackServiceBinding/> <FireAndForget>true</FireAndForget> <TopicSubscription>true</TopicSubscription> <!--Optional:--> <MessageTTLMinutes>?</MessageTTLMinutes> </typ:AsynchronousRequest> </TransactionModel> <UserCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </UserCredential> </typ:ServiceRequestHeader> </soapenv:Header> <soapenv:Body> <typ1:ServiceRequest> <RequestPreamble> <!--Optional:  147121   147543  244873--> <CustomerNumber>244873</CustomerNumber>   <!-- Número de cliente--> <!--Optional:--> <VendorNumber/> <!--Optional:--> <AssociateID/> <!--Optional:--> <CompanyCode/> <!--Optional:--> <SalesOrganization>6310</SalesOrganization>  <!--Número de organización de ventas --> <!--Optional:--> <PurchasingOrganization/> </RequestPreamble> <PriceAndAvailabilityRequest> <!--Optional:--> <DistributionChannel>10</DistributionChannel>  <!-- Número de canal de distribución --> <!--Optional:--> <Division>10</Division>  <!-- Número de división --> <!--Optional:--> <CustomerPOType>ZWEB</CustomerPOType>  <!-- Canal web --> <!--Optional:--> <IsPricingRequired>true</IsPricingRequired> <!--Optional:--> <IsAvailabilityRequired>true</IsAvailabilityRequired> <!--Optional:--> <CurrencyCode>CLP</CurrencyCode>  <!-- Modena USD dolar CLP pesos --> <!--Optional:--> <ShipToCustomerNumber>244873</ShipToCustomerNumber>  <!-- Acá va el mismo Número del cliente (CustomerNumber) --> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <SourceMode/> <!--1 or more repetitions: MATERIALES 2774119  1000324 2774122 2774125 2774126 MATERIALES --> <Item> <!--Optional:--> <ItemNumber>1</ItemNumber> <!--Optional:--> <IngramPartNumber>2774126</IngramPartNumber>  <!-- Número de material --> <!--Optional:--> <EANUPCCode/> <!--Optional:--> <RequestedQuantity>1</RequestedQuantity> <!--Optional:--> <UnitOfMeasure/> <!--Optional:--> <BidNumber/> <!--Optional:--> <EndUserNumber/> <!--Optional:--> <ShipToCustomerNumber/> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <PlantForPricing/> <!--Optional:--> <StorageLocationForPricing/> <!--Optional:--> <IsReserveInventoryRequired>false</IsReserveInventoryRequired> <!--Zero or more repetitions:--> <VariantKey/> <!--Zero or more repetitions:--> <VariantCondition> <!--Optional:--> <Key/> <!--Optional:--> <Factor/> </VariantCondition> </Item> <!--Zero or more repetitions:--> <PlantForAvailability> <Plant/> <!--Optional:--> <IncludeAvailabilityForAllStorageLocations>true</IncludeAvailabilityForAllStorageLocations>  <!-- Si es true traera en el response la información de los almacenes --> <!--Zero or more repetitions:--> <StorageLocation>8100</StorageLocation>  <!-- Esto es opcional, este es el almacen que importa --> </PlantForAvailability> </PriceAndAvailabilityRequest> </typ1:ServiceRequest> </soapenv:Body> </soapenv:Envelope>";
            var request = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types\" xmlns:typ1=\"http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types\"> <soapenv:Header> <typ:ServiceRequestHeader> <ApplicationCredential> <ID>{0}</ID> <Credential>{1}</Credential> </ApplicationCredential> <ClientTransactionID>1</ClientTransactionID> <ISOLanguageCode>ES</ISOLanguageCode> <PurposeCode>1</PurposeCode> <TargetSystem>2</TargetSystem> <TransactionID>3</TransactionID> <TransactionModel>  <SynchronousRequest>true</SynchronousRequest> <typ:AsynchronousRequest> <CallbackServiceBinding/> <FireAndForget>true</FireAndForget> <TopicSubscription>true</TopicSubscription>  <MessageTTLMinutes>?</MessageTTLMinutes> </typ:AsynchronousRequest> </TransactionModel> <UserCredential> <ID>{0}</ID> <Credential>{1}</Credential> </UserCredential> </typ:ServiceRequestHeader> </soapenv:Header> <soapenv:Body> <typ1:ServiceRequest> <RequestPreamble> <!--Optional:  147121   147543  244873--> <CustomerNumber>{2}</CustomerNumber>   <VendorNumber/>  <AssociateID/> <CompanyCode/>  <SalesOrganization>6310</SalesOrganization>  <PurchasingOrganization/> </RequestPreamble> <PriceAndAvailabilityRequest>  <DistributionChannel>10</DistributionChannel>  <Division>10</Division><CustomerPOType>ZWEB</CustomerPOType>  <IsPricingRequired>true</IsPricingRequired>  <IsAvailabilityRequired>true</IsAvailabilityRequired>  <CurrencyCode>USD</CurrencyCode>  <ShipToCustomerNumber>{2}</ShipToCustomerNumber>  <ShipToRegionCode/>  <SourceMode/>  <Item> <ItemNumber>1</ItemNumber>  <IngramPartNumber>{3}</IngramPartNumber> <EANUPCCode/> <RequestedQuantity>1</RequestedQuantity> <UnitOfMeasure/>  <BidNumber/> <EndUserNumber/> <ShipToCustomerNumber/>  <ShipToRegionCode/> <PlantForPricing/>  <StorageLocationForPricing/>  <IsReserveInventoryRequired>false</IsReserveInventoryRequired>  <VariantKey/>  <VariantCondition>  <Key/>  <Factor/> </VariantCondition> </Item>  <PlantForAvailability> <Plant/>  <IncludeAvailabilityForAllStorageLocations>true</IncludeAvailabilityForAllStorageLocations>  <StorageLocation>8100</StorageLocation>  </PlantForAvailability> </PriceAndAvailabilityRequest> </typ1:ServiceRequest> </soapenv:Body> </soapenv:Envelope>";
            var complete = string.Format(request, Utilities.Parameter.GetValue("ID"), Utilities.Parameter.GetValue("PASSWORD"), Utilities.Parameter.GetValue("N-CLIENTE"), sku);

            soapEnvelopeDocument.LoadXml(complete);

            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        public static Response QueryStock(string vdr, int sku)
        {
            try
            {
                var xml = CallWebService(sku.ToString());
                XmlDocument xmlDcument = new XmlDocument();
                xmlDcument.LoadXml(xml);

                var RequestStatus = xmlDcument.GetElementsByTagName("RequestStatus")[0].InnerText;
                if (RequestStatus == "SUCCESS")
                {
                    var ItemStatus = xmlDcument.GetElementsByTagName("ItemStatus")[0].InnerText;

                    if (ItemStatus == "SUCCESS")
                    {
                        try
                        {
                            var IngramPartNumber = xmlDcument.GetElementsByTagName("IngramPartNumber")[0].InnerText;
                            var AvailableQuantity = "0";
                        //    var CurrencyCode = xmlDcument.GetElementsByTagName("CurrencyCode")[0].InnerText;
                            var UnitNetAmount = xmlDcument.GetElementsByTagName("UnitNetAmount")[0].InnerText;
                            var TaxAmount = xmlDcument.GetElementsByTagName("TaxAmount")[0].InnerText;

                            var netAmount = decimal.Parse(UnitNetAmount.Replace('.', ','));
                            var taxAmount = decimal.Parse(TaxAmount.Replace('.', ','));

                            var ChildNodes = xmlDcument.GetElementsByTagName("PlantAvailability")[0].ChildNodes;

                            for (int i = 0; i < ChildNodes.Count; i++)
                            {
                                if (ChildNodes[i].Name == "Location")
                                {
                                    for (int j = 0; j < ChildNodes[i].ChildNodes.Count; j++)
                                    {
                                        if (ChildNodes[i].ChildNodes[j].Name == "StorageLocation")
                                        {
                                            if (ChildNodes[i].ChildNodes[j].InnerText == "8100")
                                            {
                                                AvailableQuantity = GetValueParameter(ChildNodes[i], j);
                                            }
                                        }
                                    }
                                }
                            }

                            var quantity = decimal.Parse(AvailableQuantity.Replace('.', ','));

                            return new Response()
                            {
                                Error = (byte)Response.ErrorType.CORRECTO,
                                Success = true,
                                NetAmount = netAmount,
                                TaxAmount = taxAmount,
                                TotalAmount = netAmount + taxAmount,
                                Stock = quantity
                            };
                        }
                        catch (Exception exc)
                        {
                            Data.Management.TBL_ERROR.Create(xml, "Xml de Respuesta no tiene el formato esperado.", exc.StackTrace, Utilities.Basic.GetCurrentMethod(), "Inventory.Business.Services.TBL_LOG");
                            return new Response()
                            {
                                Error = (byte)Response.ErrorType.ERROR,
                                Success = false,
                                Message = "Formato de Xml Respuesta invalido"
                        };
                    }
                }
                else
                {
                    return new Response()
                    {
                        Error = (byte)Response.ErrorType.ERROR,
                        Success = false,
                        Message = "Producto no encontrado"
                    };
                }
            }
                else
                {
                return new Response()
                {
                    Error = (byte)Response.ErrorType.ERROR,
                    Success = false,
                    Message = "Solicitud no realizada"
                };
            }
        }
            catch (Exception ex)
            {
                Data.Management.TBL_ERROR.Create(ex, Utilities.Basic.GetCurrentMethod(), "Inventory.Business.Services.TBL_LOG");
                return new Response()
        {
            Error = (byte)Response.ErrorType.EXCEPCION,
                    Success = false,
                    Message = ex.ToString()
                };
    }
}


private static string GetValueParameter(XmlNode node, int child)
{
    var value = "";

    for (int j = child; j < node.ChildNodes.Count; j++)
    {
        if (node.ChildNodes[j].Name == "AvailableQuantity")
        {
            value = node.ChildNodes[j].InnerText;
        }
    }

    return value;
}


    }
}








