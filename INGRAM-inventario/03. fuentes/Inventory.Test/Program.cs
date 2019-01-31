using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Inventory.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient client = new WebClient();
            //var request1 = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types\" xmlns:typ1=\"http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types\"> <soapenv:Header> <typ:ServiceRequestHeader> <!--You may enter the following 8 items in any order--> <ApplicationCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </ApplicationCredential> <!--Optional:--> <ClientTransactionID>1</ClientTransactionID> <!--Optional:--> <ISOLanguageCode>ES</ISOLanguageCode> <!--Optional:--> <PurposeCode>1</PurposeCode> <!--Optional:--> <TargetSystem>2</TargetSystem> <!--Optional:--> <TransactionID>3</TransactionID> <TransactionModel> <!--You have a CHOICE of the next 2 items at this level--> <!--Optional:--> <SynchronousRequest>true</SynchronousRequest> <typ:AsynchronousRequest> <!--You have a CHOICE of the next 3 items at this level--> <CallbackServiceBinding/> <FireAndForget>true</FireAndForget> <TopicSubscription>true</TopicSubscription> <!--Optional:--> <MessageTTLMinutes>?</MessageTTLMinutes> </typ:AsynchronousRequest> </TransactionModel> <UserCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </UserCredential> </typ:ServiceRequestHeader> </soapenv:Header> <soapenv:Body> <typ1:ServiceRequest> <RequestPreamble> <!--Optional:  147121   147543  244873--> <CustomerNumber>244873</CustomerNumber>   <!-- Número de cliente--> <!--Optional:--> <VendorNumber/> <!--Optional:--> <AssociateID/> <!--Optional:--> <CompanyCode/> <!--Optional:--> <SalesOrganization>6310</SalesOrganization>  <!--Número de organización de ventas --> <!--Optional:--> <PurchasingOrganization/> </RequestPreamble> <PriceAndAvailabilityRequest> <!--Optional:--> <DistributionChannel>10</DistributionChannel>  <!-- Número de canal de distribución --> <!--Optional:--> <Division>10</Division>  <!-- Número de división --> <!--Optional:--> <CustomerPOType>ZWEB</CustomerPOType>  <!-- Canal web --> <!--Optional:--> <IsPricingRequired>true</IsPricingRequired> <!--Optional:--> <IsAvailabilityRequired>true</IsAvailabilityRequired> <!--Optional:--> <CurrencyCode>CLP</CurrencyCode>  <!-- Modena USD dolar CLP pesos --> <!--Optional:--> <ShipToCustomerNumber>244873</ShipToCustomerNumber>  <!-- Acá va el mismo Número del cliente (CustomerNumber) --> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <SourceMode/> <!--1 or more repetitions: MATERIALES 2774119  1000324 2774122 2774125 2774126 MATERIALES --> <Item> <!--Optional:--> <ItemNumber>1</ItemNumber> <!--Optional:--> <IngramPartNumber>2774126</IngramPartNumber>  <!-- Número de material --> <!--Optional:--> <EANUPCCode/> <!--Optional:--> <RequestedQuantity>1</RequestedQuantity> <!--Optional:--> <UnitOfMeasure/> <!--Optional:--> <BidNumber/> <!--Optional:--> <EndUserNumber/> <!--Optional:--> <ShipToCustomerNumber/> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <PlantForPricing/> <!--Optional:--> <StorageLocationForPricing/> <!--Optional:--> <IsReserveInventoryRequired>false</IsReserveInventoryRequired> <!--Zero or more repetitions:--> <VariantKey/> <!--Zero or more repetitions:--> <VariantCondition> <!--Optional:--> <Key/> <!--Optional:--> <Factor/> </VariantCondition> </Item> <!--Zero or more repetitions:--> <PlantForAvailability> <Plant/> <!--Optional:--> <IncludeAvailabilityForAllStorageLocations>true</IncludeAvailabilityForAllStorageLocations>  <!-- Si es true traera en el response la información de los almacenes --> <!--Zero or more repetitions:--> <StorageLocation>8100</StorageLocation>  <!-- Esto es opcional, este es el almacen que importa --> </PlantForAvailability> </PriceAndAvailabilityRequest> </typ1:ServiceRequest> </soapenv:Body> </soapenv:Envelope>";
            //Console.WriteLine(request1);
            //// string request1 = "<soap:Envelope\r\n  xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'\r\n  xmlns:xsd='http://www.w3.org/2001/XMLSchema'\r\n  xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>\r\n <soap:Body><HelloWorld xmlns=\"http://tempuri.org/\"><name>Karthik mushyam</name></HelloWorld></soap:Body></soap:Envelope>";
            //client.Headers.Add(HttpRequestHeader.ContentType, "text/xml;charset=utf-8");
            ////client.Headers.Add("SOAPAction", soapMessage.SoapAction)
            //client.UploadStringCompleted += new UploadStringCompletedEventHandler(client_UploadStringCompleted);
            //client.UploadStringAsync(new Uri("https://api-beta.ingrammicro.com/PriceAndAvailability_v2_6_vse0"), request1);
            //Console.ReadLine();

            // var xml = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types\" xmlns:typ1=\"http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types\"> <soapenv:Header> <typ:ServiceRequestHeader> <!--You may enter the following 8 items in any order--> <ApplicationCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </ApplicationCredential> <!--Optional:--> <ClientTransactionID>1</ClientTransactionID> <!--Optional:--> <ISOLanguageCode>ES</ISOLanguageCode> <!--Optional:--> <PurposeCode>1</PurposeCode> <!--Optional:--> <TargetSystem>2</TargetSystem> <!--Optional:--> <TransactionID>3</TransactionID> <TransactionModel> <!--You have a CHOICE of the next 2 items at this level--> <!--Optional:--> <SynchronousRequest>true</SynchronousRequest> <typ:AsynchronousRequest> <!--You have a CHOICE of the next 3 items at this level--> <CallbackServiceBinding/> <FireAndForget>true</FireAndForget> <TopicSubscription>true</TopicSubscription> <!--Optional:--> <MessageTTLMinutes>?</MessageTTLMinutes> </typ:AsynchronousRequest> </TransactionModel> <UserCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </UserCredential> </typ:ServiceRequestHeader> </soapenv:Header> <soapenv:Body> <typ1:ServiceRequest> <RequestPreamble> <!--Optional:  147121   147543  244873--> <CustomerNumber>244873</CustomerNumber>   <!-- Número de cliente--> <!--Optional:--> <VendorNumber/> <!--Optional:--> <AssociateID/> <!--Optional:--> <CompanyCode/> <!--Optional:--> <SalesOrganization>6310</SalesOrganization>  <!--Número de organización de ventas --> <!--Optional:--> <PurchasingOrganization/> </RequestPreamble> <PriceAndAvailabilityRequest> <!--Optional:--> <DistributionChannel>10</DistributionChannel>  <!-- Número de canal de distribución --> <!--Optional:--> <Division>10</Division>  <!-- Número de división --> <!--Optional:--> <CustomerPOType>ZWEB</CustomerPOType>  <!-- Canal web --> <!--Optional:--> <IsPricingRequired>true</IsPricingRequired> <!--Optional:--> <IsAvailabilityRequired>true</IsAvailabilityRequired> <!--Optional:--> <CurrencyCode>CLP</CurrencyCode>  <!-- Modena USD dolar CLP pesos --> <!--Optional:--> <ShipToCustomerNumber>244873</ShipToCustomerNumber>  <!-- Acá va el mismo Número del cliente (CustomerNumber) --> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <SourceMode/> <!--1 or more repetitions: MATERIALES 2774119  1000324 2774122 2774125 2774126 MATERIALES --> <Item> <!--Optional:--> <ItemNumber>1</ItemNumber> <!--Optional:--> <IngramPartNumber>2774126</IngramPartNumber>  <!-- Número de material --> <!--Optional:--> <EANUPCCode/> <!--Optional:--> <RequestedQuantity>1</RequestedQuantity> <!--Optional:--> <UnitOfMeasure/> <!--Optional:--> <BidNumber/> <!--Optional:--> <EndUserNumber/> <!--Optional:--> <ShipToCustomerNumber/> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <PlantForPricing/> <!--Optional:--> <StorageLocationForPricing/> <!--Optional:--> <IsReserveInventoryRequired>false</IsReserveInventoryRequired> <!--Zero or more repetitions:--> <VariantKey/> <!--Zero or more repetitions:--> <VariantCondition> <!--Optional:--> <Key/> <!--Optional:--> <Factor/> </VariantCondition> </Item> <!--Zero or more repetitions:--> <PlantForAvailability> <Plant/> <!--Optional:--> <IncludeAvailabilityForAllStorageLocations>true</IncludeAvailabilityForAllStorageLocations>  <!-- Si es true traera en el response la información de los almacenes --> <!--Zero or more repetitions:--> <StorageLocation>8100</StorageLocation>  <!-- Esto es opcional, este es el almacen que importa --> </PlantForAvailability> </PriceAndAvailabilityRequest> </typ1:ServiceRequest> </soapenv:Body> </soapenv:Envelope>";
           // CallWebService();
            Business.Services.LoadData.QueryStock("661-00002", 2774125);
        }


        public static void CallWebService()
        {
            var _url = "https://api-beta.ingrammicro.com:443/PriceAndAvailability_v2_6_vse0";
            var _action = "/product/PriceAndAvailability";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
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
                Console.Write(soapResult);
            }
            Console.ReadKey();
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

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            //var request1 = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types\" xmlns:typ1=\"http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types\"> <soapenv:Header> <typ:ServiceRequestHeader> <!--You may enter the following 8 items in any order--> <ApplicationCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </ApplicationCredential> <!--Optional:--> <ClientTransactionID>1</ClientTransactionID> <!--Optional:--> <ISOLanguageCode>ES</ISOLanguageCode> <!--Optional:--> <PurposeCode>1</PurposeCode> <!--Optional:--> <TargetSystem>2</TargetSystem> <!--Optional:--> <TransactionID>3</TransactionID> <TransactionModel> <!--You have a CHOICE of the next 2 items at this level--> <!--Optional:--> <SynchronousRequest>true</SynchronousRequest> <typ:AsynchronousRequest> <!--You have a CHOICE of the next 3 items at this level--> <CallbackServiceBinding/> <FireAndForget>true</FireAndForget> <TopicSubscription>true</TopicSubscription> <!--Optional:--> <MessageTTLMinutes>?</MessageTTLMinutes> </typ:AsynchronousRequest> </TransactionModel> <UserCredential> <ID>APPCHPORTAL</ID> <!--Optional:--> <Credential>APPCHPORTAL12345</Credential> </UserCredential> </typ:ServiceRequestHeader> </soapenv:Header> <soapenv:Body> <typ1:ServiceRequest> <RequestPreamble> <!--Optional:  147121   147543  244873--> <CustomerNumber>244873</CustomerNumber>   <!-- Número de cliente--> <!--Optional:--> <VendorNumber/> <!--Optional:--> <AssociateID/> <!--Optional:--> <CompanyCode/> <!--Optional:--> <SalesOrganization>6310</SalesOrganization>  <!--Número de organización de ventas --> <!--Optional:--> <PurchasingOrganization/> </RequestPreamble> <PriceAndAvailabilityRequest> <!--Optional:--> <DistributionChannel>10</DistributionChannel>  <!-- Número de canal de distribución --> <!--Optional:--> <Division>10</Division>  <!-- Número de división --> <!--Optional:--> <CustomerPOType>ZWEB</CustomerPOType>  <!-- Canal web --> <!--Optional:--> <IsPricingRequired>true</IsPricingRequired> <!--Optional:--> <IsAvailabilityRequired>true</IsAvailabilityRequired> <!--Optional:--> <CurrencyCode>CLP</CurrencyCode>  <!-- Modena USD dolar CLP pesos --> <!--Optional:--> <ShipToCustomerNumber>244873</ShipToCustomerNumber>  <!-- Acá va el mismo Número del cliente (CustomerNumber) --> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <SourceMode/> <!--1 or more repetitions: MATERIALES 2774119  1000324 2774122 2774125 2774126 MATERIALES --> <Item> <!--Optional:--> <ItemNumber>1</ItemNumber> <!--Optional:--> <IngramPartNumber>2774126</IngramPartNumber>  <!-- Número de material --> <!--Optional:--> <EANUPCCode/> <!--Optional:--> <RequestedQuantity>1</RequestedQuantity> <!--Optional:--> <UnitOfMeasure/> <!--Optional:--> <BidNumber/> <!--Optional:--> <EndUserNumber/> <!--Optional:--> <ShipToCustomerNumber/> <!--Optional:--> <ShipToRegionCode/> <!--Optional:--> <PlantForPricing/> <!--Optional:--> <StorageLocationForPricing/> <!--Optional:--> <IsReserveInventoryRequired>false</IsReserveInventoryRequired> <!--Zero or more repetitions:--> <VariantKey/> <!--Zero or more repetitions:--> <VariantCondition> <!--Optional:--> <Key/> <!--Optional:--> <Factor/> </VariantCondition> </Item> <!--Zero or more repetitions:--> <PlantForAvailability> <Plant/> <!--Optional:--> <IncludeAvailabilityForAllStorageLocations>true</IncludeAvailabilityForAllStorageLocations>  <!-- Si es true traera en el response la información de los almacenes --> <!--Zero or more repetitions:--> <StorageLocation>8100</StorageLocation>  <!-- Esto es opcional, este es el almacen que importa --> </PlantForAvailability> </PriceAndAvailabilityRequest> </typ1:ServiceRequest> </soapenv:Body> </soapenv:Envelope>";
            var request1 = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:typ=\"http://www.ingrammicro.com/common/ServiceRequestHeader_v2_2/types\" xmlns:typ1=\"http://www.ingrammicro.com/product/PriceAndAvailabilityRequest_v2_6/types\"> <soapenv:Header> <typ:ServiceRequestHeader> <ApplicationCredential> <ID>{0}</ID> <Credential>{1}</Credential> </ApplicationCredential> <ClientTransactionID>1</ClientTransactionID> <ISOLanguageCode>ES</ISOLanguageCode> <PurposeCode>1</PurposeCode> <TargetSystem>2</TargetSystem> <TransactionID>3</TransactionID> <TransactionModel>  <SynchronousRequest>true</SynchronousRequest> <typ:AsynchronousRequest> <CallbackServiceBinding/> <FireAndForget>true</FireAndForget> <TopicSubscription>true</TopicSubscription>  <MessageTTLMinutes>?</MessageTTLMinutes> </typ:AsynchronousRequest> </TransactionModel> <UserCredential> <ID>{0}</ID> <Credential>{1}</Credential> </UserCredential> </typ:ServiceRequestHeader> </soapenv:Header> <soapenv:Body> <typ1:ServiceRequest> <RequestPreamble> <!--Optional:  147121   147543  244873--> <CustomerNumber>{2}</CustomerNumber>   <VendorNumber/>  <AssociateID/> <CompanyCode/>  <SalesOrganization>6310</SalesOrganization>  <PurchasingOrganization/> </RequestPreamble> <PriceAndAvailabilityRequest>  <DistributionChannel>10</DistributionChannel>  <Division>10</Division><CustomerPOType>ZWEB</CustomerPOType>  <IsPricingRequired>true</IsPricingRequired>  <IsAvailabilityRequired>true</IsAvailabilityRequired>  <CurrencyCode>CLP</CurrencyCode>  <ShipToCustomerNumber>{2}</ShipToCustomerNumber>  <ShipToRegionCode/>  <SourceMode/>  <Item> <!--Optional:--> <ItemNumber>1</ItemNumber>  <IngramPartNumber>{3}</IngramPartNumber> <EANUPCCode/> <RequestedQuantity>1</RequestedQuantity> <UnitOfMeasure/>  <BidNumber/> <EndUserNumber/> <ShipToCustomerNumber/>  <ShipToRegionCode/> <PlantForPricing/>  <StorageLocationForPricing/>  <IsReserveInventoryRequired>false</IsReserveInventoryRequired>  <VariantKey/>  <VariantCondition>  <Key/>  <Factor/> </VariantCondition> </Item>  <PlantForAvailability> <Plant/>  <IncludeAvailabilityForAllStorageLocations>true</IncludeAvailabilityForAllStorageLocations>  <StorageLocation>8100</StorageLocation>  </PlantForAvailability> </PriceAndAvailabilityRequest> </typ1:ServiceRequest> </soapenv:Body> </soapenv:Envelope>";
            var complete = string.Format(request1, "APPCHPORTAL", "APPCHPORTAL12345", "244873", "3236812");
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
        //static void client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        //{
        //    Console.WriteLine("UploadStringCompleted: {0}", e.Result);
        //}

        //static void Main(string[] args)
        //{

        //    //var r = Inventory.Business.Web.Query.GetData("923","403");

        //    //var mc = "";
        //    //string route = (@"c:\FolderIn\test.csv");

        //    //FileStream fs = new FileStream(route, FileMode.Open, FileAccess.Read);

        //    ////var result = Business.Load.GetDataCsv(fs);

        //    //var c = "";

        //}
    }
}
